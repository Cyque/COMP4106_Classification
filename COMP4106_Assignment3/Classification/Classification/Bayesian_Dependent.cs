using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMP4106_Assignment3.Classification.Classification.Dependent;

namespace COMP4106_Assignment3.Classification.Classification
{
    public class Bayesian_Dependent : Bayesian_Independent
    {

        //base.featureProbablities

        SingleDependeceNode classDependenceTree;
        Dictionary<string, double> weightedGraph;


        public Bayesian_Dependent()
        {

        }

        public override void train(List<ClassInstance> trainingSet)
        {
            List<string> featureNames = new List<string>();
            foreach (KeyValuePair<string, int> sampleFeature in trainingSet[0].features)
            {
                featureNames.Add(sampleFeature.Key);
            }

            //@@@ generate independent probabilities
            base.train(trainingSet);

            //@@@ create fully connected, weighted, undirected graph

            //key format: <string>(featureName-i:featureName-j) = <double>(weight/EMIM)
            weightedGraph = new Dictionary<string, double>();

            foreach (string featureName1 in featureNames)
                foreach (string featureName2 in featureNames)
                    if (!featureName1.Equals(featureName2) && !weightedGraph.ContainsKey(featureName2 + ":" + featureName1)) //must not already be contained
                    {//for each featureName combination
                        double weightEMIM = 0;

                        double Pr_00 = 0;
                        double Pr_01 = 0;
                        double Pr_10 = 0;
                        double Pr_11 = 0;

                        foreach (ClassInstance sample in trainingSet)
                        {
                            if (sample.features[featureName1] == 0 && sample.features[featureName2] == 0) Pr_00++; //00
                            if (sample.features[featureName1] == 0 && sample.features[featureName2] == 1) Pr_01++; //01
                            if (sample.features[featureName1] == 1 && sample.features[featureName2] == 0) Pr_10++; //10
                            if (sample.features[featureName1] == 1 && sample.features[featureName2] == 1) Pr_11++; //11
                        }

                        //scale to probablity
                        Pr_00 /= (double)trainingSet.Count;
                        Pr_01 /= (double)trainingSet.Count;
                        Pr_10 /= (double)trainingSet.Count;
                        Pr_11 /= (double)trainingSet.Count;

                        double Pr_0x0 = (1 - featureProbabilities[featureName1]) * (1 - featureProbabilities[featureName2]);
                        double Pr_0x1 = (1 - featureProbabilities[featureName1]) * (featureProbabilities[featureName2]);
                        double Pr_1x0 = (featureProbabilities[featureName1]) * (1 - featureProbabilities[featureName2]);
                        double Pr_1x1 = (featureProbabilities[featureName1]) * (featureProbabilities[featureName2]);

                        //EMIM equations. 
                        weightEMIM += Pr_00 * (Pr_0x0 == 0 ? 0 : Math.Log(Pr_00 / Pr_0x0));
                        weightEMIM += Pr_01 * (Pr_0x1 == 0 ? 0 : Math.Log(Pr_01 / Pr_0x1));
                        weightEMIM += Pr_10 * (Pr_1x0 == 0 ? 0 : Math.Log(Pr_10 / Pr_1x0));
                        weightEMIM += Pr_11 * (Pr_1x1 == 0 ? 0 : Math.Log(Pr_11 / Pr_1x1));

                        weightedGraph.Add(featureName1 + ":" + featureName2, weightEMIM);
                    }



            //@@@ compute maximim spanning tree

            makeMaxSpanTree(featureNames);

            //Console.WriteLine(classDependenceTree.ToString());
        }

        private void makeMaxSpanTree(List<string> featureNames)
        {
            //featureNames
            //n0 will be graph head
            List<string> featuresTodo = featureNames;
            List<string> featuresDone = new List<string>();
            featuresTodo.Remove("n0");
            featuresDone.Add("n0");
            classDependenceTree = new SingleDependeceNode(null, 0, "n0");


            //  A  B     BCD,  A
            //  C  D

            while (featureNames.Count > 0) //while features remain
            {
                double bestValue = double.MinValue;
                string bestFeatureName = "";
                string bestFeatureComesFrom = "";

                foreach (string feature1 in featuresDone)
                    foreach (string feature2 in featuresTodo)
                    {
                        double weightEMIM;
                        if (weightedGraph.ContainsKey(feature1 + ":" + feature2)) weightEMIM = weightedGraph[feature1 + ":" + feature2];
                        else weightEMIM = weightedGraph[feature2 + ":" + feature1];

                        if (weightEMIM > bestValue)
                        {
                            bestValue = weightEMIM;
                            bestFeatureName = feature2;
                            bestFeatureComesFrom = feature1;
                        }
                    }


                SingleDependeceNode parent = classDependenceTree.getNodeWithFeatureName(bestFeatureComesFrom);
                new SingleDependeceNode(parent, bestValue, bestFeatureName);

                featuresTodo.Remove(bestFeatureName);
                featuresDone.Add(bestFeatureName);
            }
        }


        public override double classify(ClassInstance sample)
        {
            return classDependenceTree.evaluate(sample);
        }

        public override Classification average(Classification[] list)
        {
            //average all the weighted graphs
            Bayesian_Dependent[] listN = Array.ConvertAll(list, item => (Bayesian_Dependent)item);
            Bayesian_Dependent first = (Bayesian_Dependent)list[0];

            List<string> features = new List<string>(first.weightedGraph.Keys);
            for (int i = 0; i < listN.Length; i++)
            {
                for (int j = 0; j < features.Count; j++)
                {
                    first.weightedGraph[features[j]] += listN[i].weightedGraph[features[j]];
                }
            }


            for (int j = 0; j < features.Count; j++)
                first.weightedGraph[features[j]] /= (double)listN.Length;


            return first;
        }
    }
}

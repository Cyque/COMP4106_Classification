using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMP4106_Assignment3.Classification.Classification.DecTree;

namespace COMP4106_Assignment3.Classification.Classification
{
    public class DecisionTree_Classification
    {
        List<List<ClassInstance>> dataSets;
        List<string> featureNames;
        DecisionNode rootTree;

        public DecisionTree_Classification(List<List<ClassInstance>> dataSets)
        {
            this.dataSets = dataSets;
            featureNames = new List<string>();
            foreach (KeyValuePair<string, int> sampleFeature in dataSets[0][0].features)
                featureNames.Add(sampleFeature.Key);
        }

        //first double is the entropy, second double is the proportion of the subset (Sv / S)
        private Tuple<double, double> entropyOf(List<List<ClassInstance>> dataSets, string featureName, int hasValue)
        {

            double totalDataSetsLength = 0;
            foreach (List<ClassInstance> classSamples in dataSets)
                totalDataSetsLength += classSamples.Count;


            // subset of dataSets where each sample satisfies featurname=hasValue
            List<List<ClassInstance>> subset;


            double SvLength = 0;

            if (featureName == null || hasValue == -1)
            {
                subset = new List<List<ClassInstance>>(dataSets);
                SvLength = totalDataSetsLength;
            }
            else
            {
                subset = new List<List<ClassInstance>>(dataSets);

                for (int i = 0; i < subset.Count; i++)
                {
                    subset[i] = new List<ClassInstance>(subset[i]);

                    for (int j = 0; j < subset[i].Count; j++)
                    {
                        if (!subset[i][j].features[featureName].Equals(hasValue))
                        {
                            subset[i].RemoveAt(j);
                            j--;
                        }
                        else
                            SvLength++;
                    }
                }

            }



            double entropy = 0;
            foreach (List<ClassInstance> classSamples in subset)
            {

                //proportionBelongingToThisClass
                double p = (double)classSamples.Count / SvLength;
                entropy += -p * (p == 0 ? 0 : Math.Log(p, 2)); //log 0 is considered 0
            }

            return new Tuple<double, double>(entropy, SvLength / totalDataSetsLength);
        }


        /// <summary>
        /// Creates a subset of S where each sample[featureName] = hasValue
        /// </summary>
        /// <param name="S"></param>
        /// <param name="featureName"></param>
        /// <param name="hasValue"></param>
        /// <returns></returns>
        public static List<List<ClassInstance>> getSubset(List<List<ClassInstance>> S, string featureName, int hasValue)
        {
            if (featureName == null)
                return null;
            List<List<ClassInstance>> subset = new List<List<ClassInstance>>(S);

            for (int i = 0; i < subset.Count; i++)
            {
                subset[i] = new List<ClassInstance>(subset[i]);

                for (int j = 0; j < subset[i].Count; j++)
                {
                    if (!subset[i][j].features[featureName].Equals(hasValue))
                    {
                        subset[i].RemoveAt(j);
                        j--;
                    }
                }
            }

            return subset;
        }



        /*
          * 
          * function
         * 
          * start with full set S
          *  - get feature with best information gain
          *  - make that feature the head
          *  - create subset Sv for each feature value 0 and 1
          *  - repeat function with Sv
          *  
          * 
          * -> done until no features left to explore
          * -> will have a full decision tree when complete
          * -> what about leaf nodes? how to determine class identifier
          *      -> resulting class is given by Sv class proportions.
          */
        public void train()
        {

            double entropyS = entropyOf(dataSets, null, -1).Item1;

            List<string> excludeFeatures = new List<string>();



            DecisionNode root = new DecisionNode(dataSets, getBestGainFrom(entropyS, excludeFeatures), null);
            excludeFeatures.Add(root.featureName);

            Queue<DecisionNode> baseLayer = new Queue<DecisionNode>();
            baseLayer.Enqueue(root);

            while (baseLayer.Count > 0)
            {
                DecisionNode thisNode = baseLayer.Dequeue();

                //create subsets for feature == 0 & 1
                List<List<ClassInstance>> subset0 = getSubset(thisNode.workingSet, thisNode.featureName, 0);
                List<List<ClassInstance>> subset1 = getSubset(thisNode.workingSet, thisNode.featureName, 1);

                //TODO: check entropyS is valid here
                string bestGainFeatureName0 = getBestGainFrom(entropyS, excludeFeatures);
                DecisionNode newNode0 = new DecisionNode(subset0, bestGainFeatureName0, thisNode);
                excludeFeatures.Add(newNode0.featureName);
                if (bestGainFeatureName0 != null)
                {
                    thisNode.addChild(newNode0);
                    baseLayer.Enqueue(newNode0);
                }

                string bestGainFeatureName1 = getBestGainFrom(entropyS, excludeFeatures);
                DecisionNode newNode1 = new DecisionNode(subset1, bestGainFeatureName1, thisNode);
                excludeFeatures.Add(newNode1.featureName);
                if (bestGainFeatureName1 != null)
                {
                    thisNode.addChild(newNode1);
                    baseLayer.Enqueue(newNode1);
                }
            }

            root.finalizeTree();
            rootTree = root;
            Console.WriteLine(root);

        }

        public string getBestGainFrom(double entropyS, List<string> excludeFeatures)
        {
            string bestFeatureGainName = null;
            double bestFeatureGain = double.MinValue;

            if (excludeFeatures.Count >= featureNames.Count)
                return null;

            foreach (string featureName in featureNames)
            {
                if (!excludeFeatures.Contains(featureName))
                {
                    double infGain = 0;

                    infGain += entropyS;

                    Tuple<double, double> entropy0 = entropyOf(dataSets, featureName, 0);
                    infGain -= entropy0.Item1 * entropy0.Item2;
                    Tuple<double, double> entropy1 = entropyOf(dataSets, featureName, 1);
                    infGain -= entropy1.Item1 * entropy1.Item2;


                    if (infGain > bestFeatureGain)
                    {
                        bestFeatureGainName = featureName;
                        bestFeatureGain = infGain;
                    }
                }
            }

            return bestFeatureGainName;
        }



        public int classify(ClassInstance sample)
        {
            return rootTree.classify(sample);
        }


        public void test()
        {
            int totalCorrect = 0;
            int total = 0;


            int totalSamples = 0;
            for (int i = 0; i < dataSets.Count; i++)
                totalSamples += dataSets[i].Count;


            for (int classIndex = 0; classIndex < dataSets.Count; classIndex++)
            {
                foreach (ClassInstance sample in dataSets[classIndex])
                {   //for every sample

                    int chosenClass = classify(sample);
                    if (chosenClass == -1)
                        throw new Exception();

                    if (chosenClass == classIndex)
                        totalCorrect++;
                    total++;
                }
            }

            Console.WriteLine("Test for classification type " + 3 + ".");
            Console.WriteLine("\tResults:");
            Console.WriteLine("\t\tCorrect/Incorrect: " + totalCorrect + "/" + total);
            Console.WriteLine("\t\tPercentage: " + ((double)totalCorrect / (double)total));

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COMP4106_Assignment3.Classification.Classification.DecTree
{
    public class DecisionNode
    {

        public DecisionNode parent;
        public List<DecisionNode> children = new List<DecisionNode>();

        public string featureName;

        public List<List<ClassInstance>> workingSet;

        protected double[] classCounts0;
        protected int maxClass0 = -1;

        protected double[] classCounts1;
        protected int maxClass1 = -1;

        public void finalizeTree()
        {
            for (int i = 0; i < children.Count; i++)
            {
                children[i].finalizeTree();
            }

            if (children.Count <= 1)
            {
                classCounts1 = new double[workingSet.Count];
                List<List<ClassInstance>> set1 = DecisionTree_Classification.getSubset(workingSet, featureName, 1);

                int maxj = 0;
                for (int j = 0; j < set1.Count; j++)
                {
                    classCounts1[j] = set1[j].Count;
                    if (classCounts1[j] > classCounts1[maxj])
                        maxj = j;
                }
                maxClass1 = maxj;
            }

            if (children.Count == 0)
            {
                classCounts0 = new double[workingSet.Count];
                List<List<ClassInstance>> set0 = DecisionTree_Classification.getSubset(workingSet, featureName, 0);

                int maxj = 0;
                for (int j = 0; j < set0.Count; j++)
                {
                    classCounts0[j] = set0[j].Count;
                    if (classCounts0[j] > classCounts0[maxj])
                        maxj = j;
                }
                maxClass0 = maxj;
            }

        }

        public int classify(ClassInstance sample)
        {
            if (children.Count == 2)
            {
                if (sample.features[featureName].Equals(0))
                    return children[0].classify(sample); //classify for featurename == 0
                else
                    return children[1].classify(sample); //classify for featurename == 1
            }
            else if (children.Count == 1)
            {
                if (sample.features[featureName].Equals(0))
                    return children[0].classify(sample);
            }

            //otherwise check workingSet Data
            if (sample.features[featureName].Equals(0))
                return maxClass0; //classify for featurename == 0
            else
                return maxClass1;
        }

        public DecisionNode(List<List<ClassInstance>> workingSet, string featureName, DecisionNode parent)
        {
            this.parent = parent;
            this.workingSet = workingSet;
            this.featureName = featureName;
        }

        public void addChild(DecisionNode child)
        {
            child.parent = this;
            if (!children.Contains(child))
                children.Add(child);
        }


        public override string ToString()
        {
            return ToStringTabbed("");
        }

        public string ToStringTabbed(string tabs)
        {
            String s = featureName;

            if (maxClass0 != -1)
                s += "  end0=" + maxClass0;
            if (maxClass1 != -1)
                s += "  end1=" + maxClass1;
            s += "\n";

            for (int i = 0; i < children.Count; i++)
            {
                s += tabs + i + ": " + children[i].ToStringTabbed(tabs + "\t");
            }

            return s;
        }
    }
}

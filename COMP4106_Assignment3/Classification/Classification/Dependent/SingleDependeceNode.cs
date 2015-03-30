using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COMP4106_Assignment3.Classification.Classification.Dependent
{
    public class SingleDependeceNode
    {

        public string featureName = "";
        public SingleDependeceNode parent;

        public List<SingleDependeceNode> children;

        double probabilityMatchingParent;

        public SingleDependeceNode getNodeWithFeatureName(string featureName)
        {
            if (this.featureName.Equals(featureName))
                return this;
            else
            {
                for (int i = 0; i < children.Count; i++)
                {
                    SingleDependeceNode n = children[i].getNodeWithFeatureName(featureName);
                    if (n != null)
                        return n;
                }
                return null;
            }

        }


        public double evaluate(ClassInstance sample)
        {
            double value = 1;
            
            if(parent != null)
            {
                if (sample.features[parent.featureName].Equals(sample.features[featureName]))
                    value = probabilityMatchingParent;
                else
                    value = 1 - probabilityMatchingParent;
            }

            for (int i = 0; i < children.Count; i++)
            {
                value *= children[i].evaluate(sample);
            }

            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="p_p1">probability of value=1 given parent.value=1</param>
        /// <param name="p_p2">probability of value=1 given parent.value=0</param>
        public SingleDependeceNode(SingleDependeceNode parent, double probablityGivenParent, String name)
        {
            children = new List<SingleDependeceNode>();
            this.parent = parent;
            if (parent != null)
                parent.addChild(this);
            this.featureName = name;

            this.probabilityMatchingParent = probablityGivenParent;
        }

        public void addChild(SingleDependeceNode dn)
        {
            children.Add(dn);
        }


        public override string ToString()
        {
            return toStringInd("");
        }

        private string toStringInd(string indent)
        {
            string s = indent + featureName + "( " + probabilityMatchingParent + " )" + "\n";

            for (int i = 0; i < children.Count; i++)
                s += children[i].toStringInd(indent + "\t");

            return s;
        }

    }
}

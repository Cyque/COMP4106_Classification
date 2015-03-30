using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COMP4106_Assignment3.Classification.Classification.Dependent
{
    //decisionNode is a feature
    public class DependenceNode4
    {
        public static Random rndGen = new Random();

        public string featureName = "";
        public DependenceNode4 parent;

        public List<DependenceNode4> children;

        double p_p1_1;
        double p_p0_1;

        double p_p1_0;
        double p_p0_0;

        public DependenceNode4 getNodeWithFeatureName(string featureName)
        {
            if (this.featureName.Equals(featureName))
                return this;
            else
            {
                for (int i = 0; i < children.Count; i++)
                {
                    DependenceNode4 n = children[i].getNodeWithFeatureName(featureName);
                    if (n != null)
                        return n;
                }
                return null;
            }

        }

        public double evaluate(ClassInstance sample)
        {
            double value = 1;

            if (parent != null)
            {
                if (sample.features[parent.featureName].Equals(1)) //parent == 1
                {
                    if (sample.features[featureName].Equals(1)) //this == 1
                        value = p_p1_1;
                    else //this = 0
                        value = p_p1_0;
                }
                else //parent == 0
                {
                    if (sample.features[featureName].Equals(1)) //this == 1
                        value = p_p0_1;
                    else //this == 0
                        value = p_p0_0;
                }
            }

            for (int i = 0; i < children.Count; i++)            
                value *= children[i].evaluate(sample);

            return value;
        }




      

     

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="p_p1">probability of value=1 given parent.value=1</param>
        /// <param name="p_p2">probability of value=1 given parent.value=0</param>
        public DependenceNode4(DependenceNode4 parent, double p_p0_1, double p_p1_1, double p_p0_0, double p_p1_0, String name)
        {
            children = new List<DependenceNode4>();
            this.parent = parent;
            if (parent != null)
                parent.addChild(this);
            this.featureName = name;

            this.p_p0_0 = p_p0_0;
            this.p_p0_1 = p_p0_1;
            this.p_p1_0 = p_p1_0;
            this.p_p1_1 = p_p1_1;
        }

        public void addChild(DependenceNode4 dn)
        {
            children.Add(dn);
        }

    
        public override string ToString()
        {
            return toStringInd("");
        }

        private string toStringInd(string indent)
        {
            string s = indent + featureName + "( " + p_p0_1 + ", " + p_p1_1 + ", " + p_p0_0 + ", " + p_p1_0 + " )" + "\n";

            for (int i = 0; i < children.Count; i++)
                s += children[i].toStringInd(indent + "\t");

            return s;
        }
    }
}

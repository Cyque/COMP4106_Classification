using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COMP4106_Assignment3.Classification
{
    //decisionNode is a feature
    public class DecisionNode
    {
        public static Random rndGen = new Random();

        public string featureName = "";
        public DecisionNode parent;

        public List<DecisionNode> children;

        double p_p1;
        double p_p0;



        public FeatureClass generateClass()
        {
            FeatureClass newClass = new FeatureClass();

            addToClassRecursive(newClass, 0);

            return newClass;
        }

        private void addToClassRecursive(FeatureClass fClass, int parentValue)
        {
            int newValue = createR(parentValue);
            fClass.setFeature(featureName, newValue);

            for (int i = 0; i < children.Count; i++)
                children[i].addToClassRecursive(fClass, newValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="p_p1">probability of value=1 given parent.value=1</param>
        /// <param name="p_p2">probability of value=1 given parent.value=0</param>
        public DecisionNode(DecisionNode parent, double p_p0, double p_p1, String name)
        {
            children = new List<DecisionNode>();
            this.parent = parent;
            if (parent != null)
                parent.addChild(this);
            this.featureName = name;

            this.p_p0 = p_p0;
            this.p_p1 = p_p1;
        }

        public void addChild(DecisionNode dn)
        {
            children.Add(dn);
        }

        public int createR(int parentValue)
        {
            double rnd = rndGen.NextDouble();
            if (parentValue == 0)
            {
                return (rnd <= p_p0) ? 1 : 0;
            }
            else
            {
                return (rnd <= p_p1) ? 1 : 0;
            }
        }

    }
}

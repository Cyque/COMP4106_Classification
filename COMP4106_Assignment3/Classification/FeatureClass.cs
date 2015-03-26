using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COMP4106_Assignment3.Classification
{
    public class FeatureClass
    {
        public Dictionary<String, int> features;

        public FeatureClass()
        {
            features = new Dictionary<string, int>();
        }

        public void setFeature(String featureName, int value)
        {
            if (features.ContainsKey(featureName))
                features[featureName] = value;
            else
                features.Add(featureName, value);
        }


        public override string ToString()
        {
            String s = "";

            foreach(KeyValuePair<string, int> entry in features){
                s += entry.Key + ": " + entry.Value + "\n";
            }

            return s;
        }



    }
}

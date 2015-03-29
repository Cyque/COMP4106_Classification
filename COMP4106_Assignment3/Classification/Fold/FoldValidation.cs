﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COMP4106_Assignment3.Classification.Classification;

namespace COMP4106_Assignment3.Classification.Fold
{
    public class FoldValidation
    {
        List<ClassInstance> samples;
        List<ClassInstance> samples_testing;
        List<ClassInstance> samples_training;

        int maxFolds;


        public FoldValidation(List<ClassInstance> samples, int maxFolds)
        {
            this.samples = samples;
            this.maxFolds = maxFolds;
        }

        private void setFold(int foldIndex)
        {
            int trainingSize = samples.Count * (maxFolds - 1) / maxFolds;
            int testingSize = samples.Count - trainingSize;



            samples_testing = samples.GetRange(foldIndex * testingSize, testingSize);

            samples_training = samples.GetRange(0, foldIndex * testingSize);
            samples_training.AddRange(samples.GetRange(foldIndex * testingSize + testingSize, samples.Count - (foldIndex * testingSize + testingSize)));

        }


        public void runClassification(int classificationType)
        {
            Classification.Classification[] folds = new Classification.Classification[maxFolds]; //one classification per fold
            if (classificationType == 0)
            {
                for (int i = 0; i < folds.Length; i++)
                    folds[i] = new Bayesian_Independent();
            }



            for (int i = 0; i < maxFolds; i++)
            {
                setFold(i);
                folds[i].train(samples_training); //train for each fold

                folds[i].test(samples_testing);
            }

            //average the classifications

            Classification.Classification conclusion = folds[0].average(folds);
        }



    }
}

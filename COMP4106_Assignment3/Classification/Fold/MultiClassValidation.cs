using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COMP4106_Assignment3.Classification.Fold
{
    public class MultiClassValidation
    {
        int classificationType;
        FoldValidation[] classValidation;

        public MultiClassValidation(int classificationType)
        {
            this.classificationType = classificationType;
        }


        public void runFullClassification(List<List<ClassInstance>> classSamples, int maxFolds)
        {
            //one fold validation for each class
            classValidation = new FoldValidation[classSamples.Count];

            for (int i = 0; i < classSamples.Count; i++)
            {
                classValidation[i] = new FoldValidation(classSamples[i], maxFolds);
                classValidation[i].runClassification(classificationType);
            }
        }


        public void runFullTests(List<List<ClassInstance>> testSamples)
        {


            int totalCorrect = 0;
            int total = 0;


            int totalSamples = 0;
            for (int i = 0; i < testSamples.Count; i++)
                totalSamples += testSamples[i].Count;


            for (int classIndex = 0; classIndex < testSamples.Count; classIndex++)
            {
                foreach (ClassInstance sample in testSamples[classIndex])
                {//for every sample

                    int chosenClass = -1;
                    double highestScore = double.MinValue;

                    //check against each class validator and pick the one with the highest return
                    for (int i = 0; i < classValidation.Length; i++)
                    {
                        double score = classValidation[i].conclusion.classify(sample);

                        //p(Ci) factor
                        score *= ((double)testSamples[classIndex].Count / (double)totalSamples);

                        if (score > highestScore)
                        {
                            highestScore = score;
                            chosenClass = i;
                        }
                    }

                    if (chosenClass == classIndex)
                        totalCorrect++;
                    total++;
                }
            }

            Console.WriteLine("Test for classification type " + classificationType + ".");
            Console.WriteLine("\tResults:");
            Console.WriteLine("\t\tCorrect/Incorrect: " + totalCorrect + "/" + total);
            Console.WriteLine("\t\tPercentage: " + ((double)totalCorrect / (double)total));
        }

    }
}

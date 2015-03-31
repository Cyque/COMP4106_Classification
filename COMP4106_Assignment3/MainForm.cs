using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using COMP4106_Assignment3.Classification;
using COMP4106_Assignment3.Classification.Classification;
using COMP4106_Assignment3.Classification.Fold;

namespace COMP4106_Assignment3
{
    public partial class MainForm : Form
    {
        List<DependenceNode> classes = new List<DependenceNode>();
        List<List<ClassInstance>> generatedData = new List<List<ClassInstance>>();

        public MainForm()
        {
            
            InitializeComponent();
        }

        private void btnGenerateData_Click(object sender, EventArgs e)
        {
           

           // MultiClassValidation validator;

            //validator = new MultiClassValidation(0);
            //validator.runFullClassification(generatedData, 8);
            //validator.runFullTests(generatedData);

            //validator = new MultiClassValidation(1);
            //validator.runFullClassification(generatedData, 8);
            //validator.runFullTests(generatedData);


            DecisionTree_Classification DTC = new DecisionTree_Classification(generatedData);
            DTC.train();
            DTC.test();

        }

        private void btnGenerateRandom_Click(object sender, EventArgs e)
        {
            /*                  0    1
            *             n1 (0.9, 0.9)
            *     n2 (0.9, 0.1)    n3 (0.1, 0.9)
            * 
            *  n1=1 -> n2 will prob be 1, n2 -> 0, n2 will prob be 1
            */
            classes = new List<DependenceNode>();
            generatedData = new List<List<ClassInstance>>();

            //create the classes
            for (int i = 0; i < (int)nudClasses.Value; i++)
            {
                classes.Add(DependenceNode.generateRandomTree((int)nudFeatures.Value));
                Console.WriteLine("Class " + i + ":");
                Console.WriteLine(classes[i].ToString());


                //create the data for this class:
                List<ClassInstance> classData = new List<ClassInstance>();
                for (int n = 0; n < 2000; n++)
                    classData.Add(classes[i].generateClass());

                generatedData.Add(classData);
            }
        }

        private void btnHeart_Click(object sender, EventArgs e)
        {
            generatedData = new List<List<ClassInstance>>();
            generatedData.Add(new List<ClassInstance>());
            generatedData.Add(new List<ClassInstance>());
            generatedData.Add(new List<ClassInstance>());
            generatedData.Add(new List<ClassInstance>());
            generatedData.Add(new List<ClassInstance>());

            string[] lines = System.IO.File.ReadAllLines("heartDisease.csv");

            for (int i = 0; i < lines.Length; i++)
            {
                string[] split = lines[i].Split(',');

                ClassInstance newCI = new ClassInstance();
                newCI.setFeature("Age", Double.Parse(split[0]) < 53 ? 0 : 1);
                newCI.setFeature("Gender", Double.Parse(split[1]) < 0.5 ? 0 : 1);
                newCI.setFeature("Cp", Double.Parse(split[2]) < 2.5 ? 0 : 1);
                newCI.setFeature("Trestpbs", Double.Parse(split[3]) < 147 ? 0 : 1);
                newCI.setFeature("Chol", Double.Parse(split[4]) < 345 ? 0 : 1);
                newCI.setFeature("Fbs", Double.Parse(split[5]) < 0.5 ? 0 : 1);
                newCI.setFeature("Restecg", Double.Parse(split[6]) < 1 ? 0 : 1);
                newCI.setFeature("Thalach", Double.Parse(split[7]) < 136.5 ? 0 : 1);
                newCI.setFeature("Exang", Double.Parse(split[8]) < 0.5 ? 0 : 1);
                newCI.setFeature("Oldpeak", Double.Parse(split[9]) < 3.1 ? 0 : 1);
                newCI.setFeature("Dlope", Double.Parse(split[10]) < 2 ? 0 : 1);
                newCI.setFeature("Ca", Double.Parse(split[11]) < 1.5 ? 0 : 1);
                newCI.setFeature("Thal", Double.Parse(split[12]) < 5 ? 0 : 1);
                generatedData[Int32.Parse(split[13])].Add(newCI);
            }

        }

        private void btnIris_Click(object sender, EventArgs e)
        {
            generatedData = new List<List<ClassInstance>>();
            generatedData.Add(new List<ClassInstance>());
            generatedData.Add(new List<ClassInstance>());
            generatedData.Add(new List<ClassInstance>());

            string[] lines = System.IO.File.ReadAllLines("iris.csv");

            for (int i = 0; i < lines.Length; i++)
            {
                string[] split = lines[i].Split(',');

                ClassInstance newCI = new ClassInstance();
                newCI.setFeature("Sepal length", Double.Parse(split[0]) < 6.1 ? 0 : 1);
                newCI.setFeature("Sepal width", Double.Parse(split[1]) < 3.2 ? 0 : 1);
                newCI.setFeature("Petal length", Double.Parse(split[2]) < 3.95 ? 0 : 1);
                newCI.setFeature("Petal width", Double.Parse(split[3]) < 1.3 ? 0 : 1);

                if (split[4].Equals("Iris-setosa"))
                    generatedData[0].Add(newCI);
                else if(split[4].Equals("Iris-versicolor"))
                    generatedData[1].Add(newCI);
                else if(split[4].Equals("Iris-virginica"))
                    generatedData[2].Add(newCI);

            }
        }


        private void btnWine_Click(object sender, EventArgs e)
        {
            generatedData = new List<List<ClassInstance>>();
            generatedData.Add(new List<ClassInstance>());
            generatedData.Add(new List<ClassInstance>());
            generatedData.Add(new List<ClassInstance>());

            string[] lines = System.IO.File.ReadAllLines("wine.csv");

            for (int i = 0; i < lines.Length; i++)
            {
                string[] split = lines[i].Split(',');

                ClassInstance newCI = new ClassInstance();
                newCI.setFeature("Alcohol", Double.Parse(split[1]) < 12.705 ? 0 : 1);
                newCI.setFeature("Malic acid", Double.Parse(split[2]) < 3.27 ? 0 : 1);
                newCI.setFeature("Ash", Double.Parse(split[3]) < 2.295 ? 0 : 1);
                newCI.setFeature("Alcalinity of ash", Double.Parse(split[4]) < 20.3 ? 0 : 1);
                newCI.setFeature("Magnesium", Double.Parse(split[5]) < 116 ? 0 : 1);
                newCI.setFeature("Total phenols", Double.Parse(split[6]) < 2.43 ? 0 : 1);
                newCI.setFeature("Flavanoids", Double.Parse(split[7]) < 2.71 ? 0 : 1);
                newCI.setFeature("Nonavanoid phenols", Double.Parse(split[8]) < 0.395 ? 0 : 1);
                newCI.setFeature("Proanthocyanins", Double.Parse(split[9]) < 1.995 ? 0 : 1);
                newCI.setFeature("Color intensity", Double.Parse(split[10]) < 7.14 ? 0 : 1);
                newCI.setFeature("Hue", Double.Parse(split[11]) < 1.095 ? 0 : 1);
                newCI.setFeature("OD280/OD315 of diluted wines", Double.Parse(split[12]) < 2.48 ? 0 : 1);
                newCI.setFeature("Proline", Double.Parse(split[13]) < 896.5 ? 0 : 1);

                generatedData[Int32.Parse(split[0]) - 1].Add(newCI);
            }
        }


   

        private void btnNaive_Click(object sender, EventArgs e)
        {
            MultiClassValidation validator = new MultiClassValidation(0);
            validator.runFullClassification(generatedData, 8);
            validator.runFullTests(generatedData);
        }
        private void btnDepend_Click(object sender, EventArgs e)
        {
            MultiClassValidation validator = new MultiClassValidation(1);
            validator.runFullClassification(generatedData, 8);
            validator.runFullTests(generatedData);
        }

        private void btnDec_Click(object sender, EventArgs e)
        {
            DecisionTree_Classification DTC = new DecisionTree_Classification(generatedData);
            DTC.train();
            DTC.test();
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            btnNaive_Click(null, null);
            btnDepend_Click(null, null);
            btnDec_Click(null, null);
        }
    }
}

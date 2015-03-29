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


            //validation for class 0
            FoldValidation validation = new FoldValidation(generatedData[0], 8);

            validation.runClassification(0);





            //System.IO.StreamWriter file = new System.IO.StreamWriter(@"data.txt");

            //for (int i = 0; i < generatedData.Count; i++)
            //    for (int j = 0; j < generatedData[i].Count; j++)
            //        file.WriteLine(generatedData[i][j].ToStringFlat());



        }
    }
}

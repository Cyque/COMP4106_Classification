using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using COMP4106_Assignment3.Classification;

namespace COMP4106_Assignment3
{
    public partial class MainForm : Form
    {
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
             * 
             */

            DecisionNode n1 = new DecisionNode(null, 0d, 0.9d, "n1");
            DecisionNode n2 = new DecisionNode(n1, 1d, 0.0d, "n2");
            DecisionNode n3 = new DecisionNode(n1, 1d, 0d, "n3");

            FeatureClass fClass = n1.generateClass();

            Console.WriteLine(fClass.ToString());
        }
    }
}

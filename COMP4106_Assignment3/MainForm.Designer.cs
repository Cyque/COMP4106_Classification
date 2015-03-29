namespace COMP4106_Assignment3
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGenerateData = new System.Windows.Forms.Button();
            this.nudClasses = new System.Windows.Forms.NumericUpDown();
            this.nudFeatures = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudClasses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFeatures)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerateData
            // 
            this.btnGenerateData.Location = new System.Drawing.Point(12, 87);
            this.btnGenerateData.Name = "btnGenerateData";
            this.btnGenerateData.Size = new System.Drawing.Size(188, 23);
            this.btnGenerateData.TabIndex = 0;
            this.btnGenerateData.Text = "Generate. ";
            this.btnGenerateData.UseVisualStyleBackColor = true;
            this.btnGenerateData.Click += new System.EventHandler(this.btnGenerateData_Click);
            // 
            // nudClasses
            // 
            this.nudClasses.Location = new System.Drawing.Point(135, 35);
            this.nudClasses.Name = "nudClasses";
            this.nudClasses.Size = new System.Drawing.Size(65, 20);
            this.nudClasses.TabIndex = 1;
            this.nudClasses.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // nudFeatures
            // 
            this.nudFeatures.Location = new System.Drawing.Point(135, 61);
            this.nudFeatures.Name = "nudFeatures";
            this.nudFeatures.Size = new System.Drawing.Size(65, 20);
            this.nudFeatures.TabIndex = 2;
            this.nudFeatures.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number Of Classes (c)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Number Of Features (d)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 382);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudFeatures);
            this.Controls.Add(this.nudClasses);
            this.Controls.Add(this.btnGenerateData);
            this.Name = "MainForm";
            this.Text = "COMP4106 - Assignment 3: Classification";
            ((System.ComponentModel.ISupportInitialize)(this.nudClasses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFeatures)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateData;
        private System.Windows.Forms.NumericUpDown nudClasses;
        private System.Windows.Forms.NumericUpDown nudFeatures;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}


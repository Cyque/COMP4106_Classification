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
            this.nudClasses = new System.Windows.Forms.NumericUpDown();
            this.nudFeatures = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHeart = new System.Windows.Forms.Button();
            this.btnIris = new System.Windows.Forms.Button();
            this.btnWine = new System.Windows.Forms.Button();
            this.btnNaive = new System.Windows.Forms.Button();
            this.btnDepend = new System.Windows.Forms.Button();
            this.btnDec = new System.Windows.Forms.Button();
            this.btnGenerateRandom = new System.Windows.Forms.Button();
            this.btnALL = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudClasses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFeatures)).BeginInit();
            this.SuspendLayout();
            // 
            // nudClasses
            // 
            this.nudClasses.Location = new System.Drawing.Point(138, 61);
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
            this.nudFeatures.Location = new System.Drawing.Point(138, 87);
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
            this.label1.Location = new System.Drawing.Point(15, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number Of Classes (c)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Number Of Features (d)";
            // 
            // btnHeart
            // 
            this.btnHeart.Location = new System.Drawing.Point(306, 58);
            this.btnHeart.Name = "btnHeart";
            this.btnHeart.Size = new System.Drawing.Size(270, 23);
            this.btnHeart.TabIndex = 6;
            this.btnHeart.Text = "DataSet HeartDisease";
            this.btnHeart.UseVisualStyleBackColor = true;
            this.btnHeart.Click += new System.EventHandler(this.btnHeart_Click);
            // 
            // btnIris
            // 
            this.btnIris.Location = new System.Drawing.Point(306, 87);
            this.btnIris.Name = "btnIris";
            this.btnIris.Size = new System.Drawing.Size(270, 23);
            this.btnIris.TabIndex = 7;
            this.btnIris.Text = "DataSet Iris";
            this.btnIris.UseVisualStyleBackColor = true;
            this.btnIris.Click += new System.EventHandler(this.btnIris_Click);
            // 
            // btnWine
            // 
            this.btnWine.Location = new System.Drawing.Point(306, 116);
            this.btnWine.Name = "btnWine";
            this.btnWine.Size = new System.Drawing.Size(270, 23);
            this.btnWine.TabIndex = 8;
            this.btnWine.Text = "DataSet Wine";
            this.btnWine.UseVisualStyleBackColor = true;
            this.btnWine.Click += new System.EventHandler(this.btnWine_Click);
            // 
            // btnNaive
            // 
            this.btnNaive.Location = new System.Drawing.Point(18, 223);
            this.btnNaive.Name = "btnNaive";
            this.btnNaive.Size = new System.Drawing.Size(182, 23);
            this.btnNaive.TabIndex = 9;
            this.btnNaive.Text = "Naive";
            this.btnNaive.UseVisualStyleBackColor = true;
            this.btnNaive.Click += new System.EventHandler(this.btnNaive_Click);
            // 
            // btnDepend
            // 
            this.btnDepend.Location = new System.Drawing.Point(206, 223);
            this.btnDepend.Name = "btnDepend";
            this.btnDepend.Size = new System.Drawing.Size(182, 23);
            this.btnDepend.TabIndex = 10;
            this.btnDepend.Text = "Dependent";
            this.btnDepend.UseVisualStyleBackColor = true;
            this.btnDepend.Click += new System.EventHandler(this.btnDepend_Click);
            // 
            // btnDec
            // 
            this.btnDec.Location = new System.Drawing.Point(394, 223);
            this.btnDec.Name = "btnDec";
            this.btnDec.Size = new System.Drawing.Size(182, 23);
            this.btnDec.TabIndex = 11;
            this.btnDec.Text = "Decision Tree";
            this.btnDec.UseVisualStyleBackColor = true;
            this.btnDec.Click += new System.EventHandler(this.btnDec_Click);
            // 
            // btnGenerateRandom
            // 
            this.btnGenerateRandom.Location = new System.Drawing.Point(18, 113);
            this.btnGenerateRandom.Name = "btnGenerateRandom";
            this.btnGenerateRandom.Size = new System.Drawing.Size(185, 23);
            this.btnGenerateRandom.TabIndex = 12;
            this.btnGenerateRandom.Text = "DataSet Generate";
            this.btnGenerateRandom.UseVisualStyleBackColor = true;
            this.btnGenerateRandom.Click += new System.EventHandler(this.btnGenerateRandom_Click);
            // 
            // btnALL
            // 
            this.btnALL.Location = new System.Drawing.Point(18, 252);
            this.btnALL.Name = "btnALL";
            this.btnALL.Size = new System.Drawing.Size(558, 23);
            this.btnALL.TabIndex = 13;
            this.btnALL.Text = "ALL";
            this.btnALL.UseVisualStyleBackColor = true;
            this.btnALL.Click += new System.EventHandler(this.btnALL_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 296);
            this.Controls.Add(this.btnALL);
            this.Controls.Add(this.btnGenerateRandom);
            this.Controls.Add(this.btnDec);
            this.Controls.Add(this.btnDepend);
            this.Controls.Add(this.btnNaive);
            this.Controls.Add(this.btnWine);
            this.Controls.Add(this.btnIris);
            this.Controls.Add(this.btnHeart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudFeatures);
            this.Controls.Add(this.nudClasses);
            this.Name = "MainForm";
            this.Text = "COMP4106 - Assignment 3: Classification";
            ((System.ComponentModel.ISupportInitialize)(this.nudClasses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFeatures)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudClasses;
        private System.Windows.Forms.NumericUpDown nudFeatures;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnHeart;
        private System.Windows.Forms.Button btnIris;
        private System.Windows.Forms.Button btnWine;
        private System.Windows.Forms.Button btnNaive;
        private System.Windows.Forms.Button btnDepend;
        private System.Windows.Forms.Button btnDec;
        private System.Windows.Forms.Button btnGenerateRandom;
        private System.Windows.Forms.Button btnALL;
    }
}


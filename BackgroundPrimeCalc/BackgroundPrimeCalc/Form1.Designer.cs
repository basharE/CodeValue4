namespace BackgroundPrimeCalc
{
    partial class Form1
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
            this.firstTxtbox = new System.Windows.Forms.TextBox();
            this.secondTxtbox = new System.Windows.Forms.TextBox();
            this.CalcBtn = new System.Windows.Forms.Button();
            this.CanBtn = new System.Windows.Forms.Button();
            this.ourListBox = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // firstTxtbox
            // 
            this.firstTxtbox.Location = new System.Drawing.Point(101, 45);
            this.firstTxtbox.Name = "firstTxtbox";
            this.firstTxtbox.Size = new System.Drawing.Size(100, 20);
            this.firstTxtbox.TabIndex = 0;
            // 
            // secondTxtbox
            // 
            this.secondTxtbox.Location = new System.Drawing.Point(101, 89);
            this.secondTxtbox.Name = "secondTxtbox";
            this.secondTxtbox.Size = new System.Drawing.Size(100, 20);
            this.secondTxtbox.TabIndex = 1;
            // 
            // CalcBtn
            // 
            this.CalcBtn.Location = new System.Drawing.Point(66, 139);
            this.CalcBtn.Name = "CalcBtn";
            this.CalcBtn.Size = new System.Drawing.Size(75, 23);
            this.CalcBtn.TabIndex = 2;
            this.CalcBtn.Text = "Calculate";
            this.CalcBtn.UseVisualStyleBackColor = true;
            this.CalcBtn.Click += new System.EventHandler(this.CalcBtn_Click);
            // 
            // CanBtn
            // 
            this.CanBtn.Location = new System.Drawing.Point(170, 139);
            this.CanBtn.Name = "CanBtn";
            this.CanBtn.Size = new System.Drawing.Size(75, 23);
            this.CanBtn.TabIndex = 3;
            this.CanBtn.Text = "Cancel";
            this.CanBtn.UseVisualStyleBackColor = true;
            this.CanBtn.Click += new System.EventHandler(this.CanBtn_Click);
            // 
            // ourListBox
            // 
            this.ourListBox.FormattingEnabled = true;
            this.ourListBox.Location = new System.Drawing.Point(286, 45);
            this.ourListBox.Name = "ourListBox";
            this.ourListBox.Size = new System.Drawing.Size(120, 121);
            this.ourListBox.TabIndex = 4;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(420, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = " ";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(42, 195);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(364, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 450);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ourListBox);
            this.Controls.Add(this.CanBtn);
            this.Controls.Add(this.CalcBtn);
            this.Controls.Add(this.secondTxtbox);
            this.Controls.Add(this.firstTxtbox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstTxtbox;
        private System.Windows.Forms.TextBox secondTxtbox;
        private System.Windows.Forms.Button CalcBtn;
        private System.Windows.Forms.Button CanBtn;
        private System.Windows.Forms.ListBox ourListBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}


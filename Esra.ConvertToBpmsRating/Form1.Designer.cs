namespace Esra.ConvertToBpmsRating
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
            this.rchResult = new System.Windows.Forms.RichTextBox();
            this.btnStartConvert = new System.Windows.Forms.Button();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rchResult
            // 
            this.rchResult.Location = new System.Drawing.Point(12, 252);
            this.rchResult.Name = "rchResult";
            this.rchResult.Size = new System.Drawing.Size(668, 222);
            this.rchResult.TabIndex = 4;
            this.rchResult.Text = "";
            // 
            // btnStartConvert
            // 
            this.btnStartConvert.Location = new System.Drawing.Point(12, 19);
            this.btnStartConvert.Name = "btnStartConvert";
            this.btnStartConvert.Size = new System.Drawing.Size(143, 25);
            this.btnStartConvert.TabIndex = 3;
            this.btnStartConvert.Text = "شروع تبدیل اطلاعات";
            this.btnStartConvert.UseVisualStyleBackColor = true;
            this.btnStartConvert.Click += new System.EventHandler(this.btnStartConvert_Click);
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(12, 72);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(100, 20);
            this.txtCount.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 486);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.rchResult);
            this.Controls.Add(this.btnStartConvert);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchResult;
        private System.Windows.Forms.Button btnStartConvert;
        private System.Windows.Forms.TextBox txtCount;
    }
}


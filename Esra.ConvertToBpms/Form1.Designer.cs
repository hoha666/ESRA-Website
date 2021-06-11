namespace Esra.ConvertToBpms
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
            this.btnStartConvert = new System.Windows.Forms.Button();
            this.rchResult = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnStartConvert
            // 
            this.btnStartConvert.Location = new System.Drawing.Point(12, 12);
            this.btnStartConvert.Name = "btnStartConvert";
            this.btnStartConvert.Size = new System.Drawing.Size(143, 25);
            this.btnStartConvert.TabIndex = 0;
            this.btnStartConvert.Text = "شروع تبدیل اطلاعات";
            this.btnStartConvert.UseVisualStyleBackColor = true;
            this.btnStartConvert.Click += new System.EventHandler(this.btnStartConvert_Click);
            // 
            // rchResult
            // 
            this.rchResult.Location = new System.Drawing.Point(12, 245);
            this.rchResult.Name = "rchResult";
            this.rchResult.Size = new System.Drawing.Size(668, 222);
            this.rchResult.TabIndex = 2;
            this.rchResult.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 479);
            this.Controls.Add(this.rchResult);
            this.Controls.Add(this.btnStartConvert);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartConvert;
        private System.Windows.Forms.RichTextBox rchResult;
    }
}


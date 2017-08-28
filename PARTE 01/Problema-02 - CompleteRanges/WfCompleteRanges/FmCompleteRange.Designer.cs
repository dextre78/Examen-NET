namespace WfCompleteRanges
{
    partial class FmCompleteRange
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
            this.btnTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtinrange = new System.Windows.Forms.TextBox();
            this.txtoutrange = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(122, 214);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(217, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Complete";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Input Range:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Out Range:";
            // 
            // txtinrange
            // 
            this.txtinrange.Location = new System.Drawing.Point(97, 36);
            this.txtinrange.Name = "txtinrange";
            this.txtinrange.Size = new System.Drawing.Size(272, 20);
            this.txtinrange.TabIndex = 0;
            this.txtinrange.Text = "2, 1, 4, 5";
            // 
            // txtoutrange
            // 
            this.txtoutrange.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtoutrange.Location = new System.Drawing.Point(97, 92);
            this.txtoutrange.Name = "txtoutrange";
            this.txtoutrange.Size = new System.Drawing.Size(272, 91);
            this.txtoutrange.TabIndex = 5;
            this.txtoutrange.Text = "";
            // 
            // FmCompleteRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 261);
            this.Controls.Add(this.txtoutrange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.txtinrange);
            this.Name = "FmCompleteRange";
            this.Text = "Exam- Complete Range";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtinrange;
        private System.Windows.Forms.RichTextBox txtoutrange;
    }
}
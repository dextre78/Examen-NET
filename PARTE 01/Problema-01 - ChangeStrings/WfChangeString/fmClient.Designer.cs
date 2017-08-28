namespace WfChangeString
{
    partial class fmClient
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnchange = new System.Windows.Forms.Button();
            this.txtinput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtout = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnchange
            // 
            this.btnchange.Location = new System.Drawing.Point(60, 172);
            this.btnchange.Name = "btnchange";
            this.btnchange.Size = new System.Drawing.Size(173, 23);
            this.btnchange.TabIndex = 0;
            this.btnchange.Text = "Procesar";
            this.btnchange.UseVisualStyleBackColor = true;
            this.btnchange.Click += new System.EventHandler(this.btnchange_Click);
            // 
            // txtinput
            // 
            this.txtinput.Location = new System.Drawing.Point(90, 46);
            this.txtinput.Name = "txtinput";
            this.txtinput.Size = new System.Drawing.Size(143, 20);
            this.txtinput.TabIndex = 1;
            this.txtinput.Text = "123 abcd*3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Text Entrada:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Text Salida:";
            // 
            // txtout
            // 
            this.txtout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtout.Location = new System.Drawing.Point(90, 100);
            this.txtout.Name = "txtout";
            this.txtout.Size = new System.Drawing.Size(143, 43);
            this.txtout.TabIndex = 4;
            this.txtout.Text = "";
            // 
            // fmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 211);
            this.Controls.Add(this.txtout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtinput);
            this.Controls.Add(this.btnchange);
            this.Name = "fmClient";
            this.Text = "Exam- Change String";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnchange;
        private System.Windows.Forms.TextBox txtinput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtout;
    }
}


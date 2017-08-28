using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompleteRanges;



namespace WfCompleteRanges
{
    public partial class FmCompleteRange : Form
    {
        public FmCompleteRange()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string input = this.txtinrange.Text;

            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Ingrese un rango: 1,2,3,8,9 ; el valor no puede estar vacio:");
                return;
            }
            
            CompleteRange objc = new CompleteRange();
            var txt = objc.build(input);
            this.txtoutrange.Text = txt;

            foreach (int i in objc.colorange) {

                txtoutrange.SelectionStart = txtoutrange.Find(i.ToString(), 1, txtoutrange.TextLength - 1, RichTextBoxFinds.MatchCase);
                txtoutrange.SelectionColor = Color.Red;
            }
        }
    }
}

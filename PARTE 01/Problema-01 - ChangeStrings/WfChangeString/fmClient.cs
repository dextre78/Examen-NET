using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ChangeStrings;
namespace WfChangeString
{
    public partial class fmClient : Form
    {
        public fmClient()
        {
            InitializeComponent();
        }

        private void btnchange_Click(object sender, EventArgs e)
        {
            string input = this.txtinput.Text;            
            if (string.IsNullOrEmpty(input)) {
                MessageBox.Show("Ingrese un texto, no puede estar vacio");
                return;
            }

            ChangeString objc = new ChangeString();
            this.txtout.Text = objc.build(input);
           
            foreach (string i in objc.lStrings)
            {
                txtout.SelectionStart = txtout.Find(i.ToString(), 1, txtout.TextLength, RichTextBoxFinds.MatchCase);
                txtout.SelectionColor = Color.Red;
            }

            
        }
    }
}

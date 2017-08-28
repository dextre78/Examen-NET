using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MoneyParts;

namespace ClientMoneyParts
{
    public partial class Procesar : Form
    {
        public Procesar()
        {
            InitializeComponent();
        }

        MoneyPart objMoneyParts = new MoneyPart();
        private void BtnEjecutar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtEntrada.Text))
            {
                MessageBox.Show("Ingrese un valor");
                return;
            }

            double entrada;
            if (!double.TryParse(this.txtEntrada.Text, out entrada))
            {
                MessageBox.Show("Ingrese un valor valido");
                return;
            }
            this.txtSalida.Clear();
           
            this.txtSalida.Text = objMoneyParts.build(entrada);
        }        
       
    }
}

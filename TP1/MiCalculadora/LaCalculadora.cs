using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
namespace MiCalculadora

{
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            lblResultado.Text = string.Empty;
            textNumero1.Text = string.Empty;
            textNumero2.Text = string.Empty;
            cmbOperador.Text = string.Empty;

        }



        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = Operar(textNumero1.Text, textNumero2.Text, cmbOperador.SelectedItem.ToString());
            lblResultado.Text = resultado.ToString();
        }
        private static double Operar(string numero1, string numero2, string operador)
        {
           return Calculadora.Operar(new Numero(numero1), new Numero(numero2), operador);

            
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero(textNumero1.Text);
            lblResultado.Text = numero1.DecimalBinario(textNumero1.Text);

        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero(textNumero1.Text);
            lblResultado.Text = numero1.BinarioDecimal(textNumero1.Text);
        }

       
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            lblResultado.Text = "";
            textNumero1.Text = "";
            textNumero2.Text = "";
            cmbOperador.Text = "";

        }



        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resutlado = Operar(textNumero1.Text, textNumero2.Text, cmbOperador.SelectedItem.ToString());
            lblResultado.Text = resutlado.ToString();
        }
        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado = Entidades.Calculadora.Operar(new Entidades.Numero(numero1), new Entidades.Numero(numero2), operador);

            return resultado;
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Entidades.Numero numero1 = new Entidades.Numero(textNumero1.Text);
            lblResultado.Text = numero1.DecimalBinario(textNumero1.Text);

        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Entidades.Numero numero1 = new Entidades.Numero(textNumero1.Text);
            lblResultado.Text = numero1.BinarioDecimal(textNumero1.Text);
        }
        


    }
}

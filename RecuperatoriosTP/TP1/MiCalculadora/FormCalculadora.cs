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
    public partial class FormCalculadora : Form
    {
        #region Constructor
        public FormCalculadora()
        {
            InitializeComponent();
        }

        #endregion

        #region Botones
        /// <summary>
        /// Cierra la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Invoca al metodo Limpiar, al hacer click en el boton se limpian los campos correspondientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Al hacer click en operar, se efectua la operacion correspondiente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado = Operar(textNumero1.Text, textNumero2.Text, cmbOperador.SelectedItem.ToString());
            lblResultado.Text = resultado.ToString();
        }
        /// <summary>
        /// Convertirá el resultado, de existir a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero(lblResultado.Text);
            string msj = "Error";
            if (!(string.IsNullOrEmpty(lblResultado.Text)))
            {
                msj = numero1.DecimalBinario(lblResultado.Text);
            }
            lblResultado.Text = msj;


        }
        /// <summary>
        /// Convertirá el resultado, de existir y ser binario, a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero(lblResultado.Text);
            string msj = "Error";
            if (!string.IsNullOrEmpty(lblResultado.Text))
            {
                msj = numero1.BinarioDecimal(lblResultado.Text);
            }
            lblResultado.Text = msj;

        }
        #endregion

        #region Metodos
        /// <summary>
        /// Limpia el label, los textbox y el comboBox
        /// </summary>
        private void Limpiar()
        {
            lblResultado.Text = "";
            textNumero1.Text = "";
            textNumero2.Text = "";
            cmbOperador.Text = "";

        }
        /// <summary>
        /// Invoca al método Operar de Calculadora y retornar el resultado al método de evento
        /// </summary>
        /// <param name="numero1">Primer numero recibido como parametro</param>
        /// <param name="numero2">Segundo numero recibido como parametro</param>
        /// <param name="operador">Operador elegido por el usuario recibido como parametro</param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double retorno = 0;
            if (!(object.ReferenceEquals(numero1, null)) && !(object.ReferenceEquals(numero2, null)))
            {
                retorno = Calculadora.Operar(new Numero(numero1), new Numero(numero2), operador);
            }

            return retorno;
        }
        #endregion
    }
}

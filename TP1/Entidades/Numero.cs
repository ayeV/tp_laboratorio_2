using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double _numero;

        #region Constructores
        public Numero()
        {
            this._numero = 0;
        }
        public Numero(double numero)
        {
            this._numero = numero;
        }

        public Numero(string numero)
        {
            SetNumero = numero;
        }
        #endregion

        #region Propiedades


        public string SetNumero
        {
            set
            {
                this._numero = ValidarNumero(value);
            }
        }


        #endregion

        #region Metodos
        /// <summary>
        /// Valida que el valor recibido sea numerico.
        /// </summary>
        /// <param name="strNumero">Valor recibido</param>
        /// <returns>Si strNumero es numerico, lo retorna en formato double, sino retorna 0</returns>
        private static double ValidarNumero(string strNumero)
        {
            double dbNumero;
            if (double.TryParse(strNumero, out dbNumero))
            {
                return dbNumero;
            }
           

            return 0;


        }
        /// <summary>
        /// Convierte un binario a decimal
        /// </summary>
        /// <param name="binario">string recibido</param>
        /// <returns>Retorna un string decimal en caso favorable, sino retorna "Valor invalido"</returns>
        public string BinarioDecimal(string binario)
        {
            double numDecimal = 0;
            int exponente = 0;
            int nro = 0;
            for (int i = binario.Length - 1; i >= 0; i--)
            {
                string posibleNumero = binario.Substring(i, 1);
                if (int.TryParse(posibleNumero, out nro))
                {
                    numDecimal += (nro * Math.Pow(2, exponente));
                    exponente++;
                }
                else
                {
                    return "Valor invalido";
                }
            }
            return numDecimal.ToString();


        }



        /// <summary>
        /// Convierte un decimal a binario
        /// </summary>
        /// <param name="numero">valor recibido</param>
        /// <returns>Retorna un string binario </returns>
        public string DecimalBinario(double numero)
        {
            string nroBin = "";
            int numero1 = (int)numero;

            do
            {
                double resto = numero1 % 2;
                double parteBinaria = (resto % 2 == 0) ? 0 : 1;
                nroBin = parteBinaria.ToString() + nroBin.ToString();
                numero1 =  numero1 / 2;

            } while (numero1 != 1 && numero1 != 0);
            nroBin = numero1.ToString() + nroBin.ToString();
            return nroBin;
        }
        /// <summary>
        /// Convierte un decimal a binario
        /// </summary>
        /// <param name="numero">valor recibido</param>
        /// <returns>Retorna el nro en binario si es posible, sino retorna "valor invalido"</returns>
        public string DecimalBinario(string numero)
        {
            double nroDecimal;
            string retorno = "Valor invalido";
            if (double.TryParse(numero, out nroDecimal))
            {
                return DecimalBinario(nroDecimal);
            }
            return retorno;
        }

        #endregion

        #region Operadores
        public static double operator -(Numero n1, Numero n2)
        {

            double resultado = n1._numero - n2._numero;
            return resultado;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            double resultado = n1._numero + n2._numero;
            return resultado;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double resultado = n1._numero * n2._numero;
            return resultado;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            double resultado = 0;
            if (n2._numero != 0)
            {
                resultado =  n1._numero / n2._numero;
            }
            return resultado;
        }
        #endregion
    }
}

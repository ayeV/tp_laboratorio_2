using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        #region "Constructor"
        public Dulce(EMarca marca, string patente, ConsoleColor color) : base(patente, marca, color)
        {

        }
        #endregion
        #region "Propiedad"
        /// <summary>
        /// Retorna la cantidad de calorias de un Dulce
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }
        #endregion
        #region "Metodo"
        /// <summary>
        /// Muestra los atributos de Dulce
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}

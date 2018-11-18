using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;

        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }
        #region Atributos
        string direccionEntrega;
        EEstado estado;
        string trackingID;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura y escritura
        /// </summary>
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }
        /// <summary>
        /// Propiedad de lectura y escritura
        /// </summary>
        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }
        /// <summary>
        /// Propiedad de lectura y escritura
        /// </summary>
        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor publico de instancia
        /// </summary>
        /// <param name="direccionEntrega">Direccion de entrega</param>
        /// <param name="trackingID">ID</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Dos paquetes son iguales si sus trackingID lo son
        /// </summary>
        /// <param name="p1">Paquete</param>
        /// <param name="p2">Paquete</param>
        /// <returns>retorna true si son iguales, false si no</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;
            if(p1.trackingID == p2.trackingID)
            {
                retorno = true;
            }
            return retorno;
            
        }
        /// <summary>
        /// Dos paquetes son distintos si sus trackingID lo son
        /// </summary>
        /// <param name="p1">Paquete</param>
        /// <param name="p2">Paquete</param>
        /// <returns>retorna true si son distintos, false si no</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Sobrecarga que retorna los datos del paquete
        /// </summary>
        /// <returns>Retornba un string con dichos datos</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        /// <summary>
        /// Retorna los datos del paquete
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>Retorna una cadena con dichos datos</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", this.trackingID, this.direccionEntrega);
        }
        /// <summary>
        /// Hace que el paquete cambie de estado
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.estado != EEstado.Entregado)
            {
                Thread.Sleep(10000);
                this.Estado++;
                this.InformaEstado(this.Estado, EventArgs.Empty);
            }
            PaqueteDAO.Insertar(this);
        }
        #endregion

    }
}

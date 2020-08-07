using Facturas.Dominio.Importacion;
using Facturas.Lector.Mensajes;
using System.Collections.Generic;

namespace Facturas.Negocio.Mensajes
{
    public class ObtieneMensajes
    {
        // Atributos
        public List<VentaDTO> VentasMessage { get; set; }

        // Constructor.
        private ObtieneMensajes()
        {
            obtenerLosMensajes();
        }

        // Creador del objeto.
        public static ObtieneMensajes leer()
        {
            return new ObtieneMensajes();
        }

        // Obtener los mensajes de la cola.
        private void obtenerLosMensajes()
        {
            MessageIn myMsgIn = MessageIn.create();
            VentasMessage = myMsgIn.getMensaje();
        }
    }
}
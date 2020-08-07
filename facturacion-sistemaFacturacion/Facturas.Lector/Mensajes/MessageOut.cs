using Apache.NMS;
using Facturas.Dominio.Importacion;
using Newtonsoft.Json;

namespace Facturas.Lector.Mensajes
{
    public class MessageOut : Message
    {
       // Constructor.
        private MessageOut() : base()
        {
            abrirConexion();
        }

        // Creador del objeto.
        public static MessageOut create()
        {
            return new MessageOut();
        }

        // Enviar un mensaje a la cola.
        public void setMensaje(VentaDTO ventaDTO)
        {
            IDestination myDestination = mySession.GetQueue(myQueue);
            using (IMessageProducer myMessageProducer = mySession.CreateProducer(myDestination))
            {
                var myJson = JsonConvert.SerializeObject(ventaDTO);
                var myMessage = myMessageProducer.CreateTextMessage(myJson);

                myMessageProducer.Send(myMessage);
            }
            cerrarConexion();
        }
    }
}
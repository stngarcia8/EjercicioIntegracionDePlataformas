using Apache.NMS;
using Facturas.Dominio.Importacion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Facturas.Lector.Mensajes
{
    public class MessageIn : Message
    {
        // Constructor.
        private MessageIn() : base()
        {
            abrirConexion();
        }

        // Creador del objeto.
        public static MessageIn create()
        {
            return new MessageIn();
        }

        // Enviar un mensaje a la cola.
        public List<VentaDTO> getMensaje()
        {
            List<VentaDTO> myVentaList = new List<VentaDTO>();
            IDestination myDestination = mySession.GetQueue(myQueue);
            using (IMessageConsumer myMessageConsumer = mySession.CreateConsumer(myDestination))
            {
                IMessage myMessage;
                while ((myMessage = myMessageConsumer.Receive(TimeSpan.FromMilliseconds(2000))) != null)
                {
                    var myText = myMessage as ITextMessage;
                    if (myText != null)
                    {
                        var myObject = JsonConvert.DeserializeObject<VentaDTO>(myText.Text);
                        myVentaList.Add(myObject as VentaDTO);
                    }
                }
            }
            cerrarConexion();
            return myVentaList;
        }
    }
}
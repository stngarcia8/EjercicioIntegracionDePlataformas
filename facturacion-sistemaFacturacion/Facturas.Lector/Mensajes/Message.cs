using Apache.NMS;
using Apache.NMS.ActiveMQ;

namespace Facturas.Lector.Mensajes
{
    public abstract class Message
    {
        // Variables de la clase.
        protected string myUrl = "tcp://localhost:61616";
        protected string myQueue = "libros.facturas";
        protected IConnection myConnection;
        protected ISession mySession;

        // Abriendo coneccion de ActiveMQ.
        protected void abrirConexion()
        {
            IConnectionFactory myFactory = new ConnectionFactory(myUrl);
            myConnection = myFactory.CreateConnection();
            myConnection.Start();
            mySession = myConnection.CreateSession();
        }

        // Cerrar la coneccion de ActiveMQ.
        protected void cerrarConexion()
        {
            mySession.Close();
            myConnection.Close();
        }
    }
}
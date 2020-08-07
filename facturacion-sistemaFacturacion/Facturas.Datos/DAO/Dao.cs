using Facturas.Datos.Conexion;

namespace Facturas.Datos.DAO
{
    public abstract class Dao
    {
        protected IConectarOracle myConnection;

        protected Dao() { }

        protected IConsultaSeleccion DefinirObjetoConsultaSeleccion(string sql)
        {
            myConnection = ConectarOracle.crearConexion();
            return myConnection.CrearConsultaSeleccion(sql);
        }

        protected IConsultaAccion DefinirObjetoConsultaAccion(string nombreProcedimientoAlmacenado)
        {
            myConnection = ConectarOracle.crearConexion();
            return myConnection.CrearConsultaAccion(nombreProcedimientoAlmacenado);
        }
    }
}
using Oracle.ManagedDataAccess.Client;

namespace Facturas.Datos.Conexion
{
    public interface IConectarOracle
    {
        OracleConnection ObtenerConexion();

        OracleTransaction ObtenerTransaccion();

        void Commit();

        void RollBack();

        IConsultaSeleccion CrearConsultaSeleccion(string sql);

        IConsultaAccion CrearConsultaAccion(string nombreProcedimientoAlmacenado);

        void cerrarConexion();
    }
}
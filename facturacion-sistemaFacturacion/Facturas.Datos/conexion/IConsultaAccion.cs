using System.Data;

namespace Facturas.Datos.Conexion
{
    public interface IConsultaAccion
    {
        void AgregarParametro(string nombreParametro, object valorParametro, DbType tipoValorParametro);

        void LimpiarParametros();

        int EjecutarConsulta();
    }
}
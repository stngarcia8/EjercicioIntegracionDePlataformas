using System.Data;

namespace Facturas.Datos.Conexion
{
    public interface IConsultaSeleccion
    {
        void AgregarParametro(string nombreParametro, object valorParametro, DbType tipoValorParametro);

        void LimpiarParametros();

        DataTable EjecutarConsulta();
    }
}
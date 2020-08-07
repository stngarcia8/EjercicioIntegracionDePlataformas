using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Facturas.Datos.Conexion
{
    public abstract class Consulta
    {
        protected OracleCommand comando;

        protected Consulta(OracleCommand comando)
        {
            this.comando = comando;
        }

        public virtual void AgregarParametro(string nombreParametro, object valorParametro, DbType tipoValorParametro)
        {
            OracleParameter parametro = new OracleParameter();
            parametro.ParameterName = nombreParametro;
            parametro.Value = valorParametro;
            parametro.DbType = tipoValorParametro;
            comando.Parameters.Add(parametro);
        }

        protected void ClearParameters()
        {
            comando.Parameters.Clear();
        }
    }
}
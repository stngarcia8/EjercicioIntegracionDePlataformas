using System.IO;

namespace Facturas.Lector.Helper
{
    public class Directorio
    {
        // Constructor
        private Directorio() { }

        // Creador del objeto
        public static Directorio Crear()
        {
            return new Directorio();
        }

        public bool CrearDirectorio(string directorio)
        {
            var Resultado = false;

            try
            {
                if (Directory.Exists(directorio)) { return true; }

                Directory.CreateDirectory(directorio);

                Resultado =  true;
            }
            catch (IOException)
            {
                Resultado = false;
            }

            return Resultado;
        }
    }
}
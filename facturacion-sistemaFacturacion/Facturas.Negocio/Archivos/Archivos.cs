using System.IO;

namespace Facturas.Negocio.Archivos
{
    public class Archivos
    {
        // Constructor
        private Archivos() { }

        // Creador del objeto
        public static Archivos Crear()
        {
            return new Archivos();
        }

        // Mueve un archivo en caso de que este no exista en el destino
        public void MoverArchivo(string nombreArchivo, string formato, string origen, string destino)
        {
            var directorioActual = origen + nombreArchivo + formato;
            var directorioDestino = destino + nombreArchivo + formato;

            if (!File.Exists(directorioActual)) { return; }

            try
            {
                File.Copy(directorioActual, directorioDestino, true);
                File.Delete(directorioActual);
            }
            catch (IOException)
            {
                throw;
            }
        }
    }
}
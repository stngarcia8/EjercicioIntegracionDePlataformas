using System.Xml.Linq;

namespace Facturas.Lector.Secciones
{
    interface IAgregarSeccion
    {
        void AgregarElemento<TObjeto>(XElement unNodoPadre, string unNombreParaNodoHijo, TObjeto unObjetoDeConfiguracion) where TObjeto : class;
    }
}
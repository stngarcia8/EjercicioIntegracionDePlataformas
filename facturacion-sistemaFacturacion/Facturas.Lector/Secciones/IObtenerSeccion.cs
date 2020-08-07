using System.Xml.Linq;

namespace Facturas.Lector.Secciones
{
    interface IObtenerSeccion
    {
        TObjeto LeerSeccion<TObjeto>(XDocument unDocumentoXML, string unNombreDeSeccion) where TObjeto : class;
    }
}
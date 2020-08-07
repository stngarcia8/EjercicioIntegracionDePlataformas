using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace Facturas.Lector.Secciones
{
    class ObtenerSeccion: IObtenerSeccion
    {
        public TObjeto LeerSeccion<TObjeto>(XDocument unDocumentoXML, string unNombreDeSeccion) where TObjeto : class
        {
            var nodoActual = (from x in unDocumentoXML.Root.Elements(unNombreDeSeccion)
                              select x).ToList();
            Type tipo = typeof(TObjeto);
            PropertyInfo[] propiedades = tipo.GetProperties();
            var unaEntidad = Activator.CreateInstance<TObjeto>();
            string valor = string.Empty;
            foreach (PropertyInfo propiedad in propiedades)
            {
                valor = (from x in nodoActual.Elements()
                         where x.Name.ToString() == propiedad.Name.ToString()
                         select x.Value).FirstOrDefault();
                propiedad.SetValue(unaEntidad, Convert.ChangeType(valor, propiedad.PropertyType), null);
            }
            return unaEntidad;
        }
    }
}
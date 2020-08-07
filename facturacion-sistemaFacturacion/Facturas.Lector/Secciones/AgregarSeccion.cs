using System;
using System.Reflection;
using System.Xml.Linq;

namespace Facturas.Lector.Secciones
{
    class AgregarSeccion : IAgregarSeccion
    {
        public void AgregarElemento<TObjeto>(XElement unNodoPadre, string unNombreParaNodoHijo, TObjeto unObjetoDeConfiguracion) where TObjeto : class
        {
            XElement nuevoElementoXML = new XElement(unNombreParaNodoHijo);
            AsignarValores(nuevoElementoXML, unObjetoDeConfiguracion);
            unNodoPadre.Add(nuevoElementoXML);
        }

        private void AsignarValores<TObjeto>(XElement unElementoXML, TObjeto unObjeto)
        {
            Type tipoObjeto = typeof(TObjeto);
            PropertyInfo[] propiedades = tipoObjeto.GetProperties();
            foreach (PropertyInfo propiedad in propiedades)
            {
                XElement elementoHijo = new XElement(propiedad.Name.ToString());
                elementoHijo.Add((propiedad.GetValue(unObjeto, null) == null ? string.Empty : propiedad.GetValue(unObjeto, null)));
                unElementoXML.Add(elementoHijo);
            }
        }
    }
}
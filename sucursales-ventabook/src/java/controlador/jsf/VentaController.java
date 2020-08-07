package controlador.jsf;

import ejb.VentaFacade;
import controlador.jsf.util.JsfUtil;
import controlador.jsf.util.JsfUtil.PersistAction;
import java.io.Serializable;
import java.util.List;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.ejb.EJBException;
import javax.enterprise.context.SessionScoped;
import javax.faces.component.UIComponent;
import javax.faces.context.FacesContext;
import javax.faces.convert.Converter;
import javax.faces.convert.FacesConverter;
import javax.inject.Named;
import modelo.DetVenta;
import modelo.Libro;
import modelo.Venta;
import org.primefaces.event.RowEditEvent;


@Named("ventaController")
@SessionScoped
public class VentaController implements Serializable {

    @EJB
    private ejb.VentaFacade ejbFacade;
    private List<Venta> items = null;
    private Venta selected;
    private boolean mostrar;
    private boolean skip;

    public VentaController() {
    }


    @PostConstruct
    public void init() {
        this.selected = new Venta();
    }


    public Venta getSelected() {
        return selected;
    }


    public void setSelected(Venta selected) {
        this.selected = selected;
    }


    protected void setEmbeddableKeys() {
    }


    protected void initializeEmbeddableKey() {
    }


    private VentaFacade getFacade() {
        return ejbFacade;
    }


    public Venta prepareCreate() {
        selected = new Venta();
        initializeEmbeddableKey();
        return selected;
    }


    public void create() {
        persist(PersistAction.CREATE, ResourceBundle.getBundle("/Bundle").getString("VentaCreated"));
        if (!JsfUtil.isValidationFailed()) {
            items = null;    // Invalidate list of items to trigger re-query.
        }
    }


    public void update() {
        persist(PersistAction.UPDATE, ResourceBundle.getBundle("/Bundle").getString("VentaUpdated"));
    }


    public void destroy() {
        persist(PersistAction.DELETE, ResourceBundle.getBundle("/Bundle").getString("VentaDeleted"));
        if (!JsfUtil.isValidationFailed()) {
            selected = null; // Remove selection
            items = null;    // Invalidate list of items to trigger re-query.
        }
    }


    public List<Venta> getItems() {
        if (items == null) {
            items = getFacade().findAll();
        }
        return items;
    }


    private void persist(PersistAction persistAction, String successMessage) {
        if (selected != null) {
            setEmbeddableKeys();
            try {
                if (persistAction != PersistAction.DELETE) {
                    getFacade().edit(selected);
                } else {
                    getFacade().remove(selected);
                }
                JsfUtil.addSuccessMessage(successMessage);
            } catch (EJBException ex) {
                String msg = "";
                Throwable cause = ex.getCause();
                if (cause != null) {
                    msg = cause.getLocalizedMessage();
                }
                if (msg.length() > 0) {
                    JsfUtil.addErrorMessage(msg);
                } else {
                    JsfUtil.addErrorMessage(ex, ResourceBundle.getBundle("/Bundle").getString("PersistenceErrorOccured"));
                }
            } catch (Exception ex) {
                Logger.getLogger(this.getClass().getName()).log(Level.SEVERE, null, ex);
                JsfUtil.addErrorMessage(ex, ResourceBundle.getBundle("/Bundle").getString("PersistenceErrorOccured"));
            }
        }
    }


    public Venta getVenta(java.lang.String id) {
        return getFacade().find(id);
    }


    public List<Venta> getItemsAvailableSelectMany() {
        return getFacade().findAll();
    }


    public List<Venta> getItemsAvailableSelectOne() {
        return getFacade().findAll();
    }


    public void mostrarDatosFactura() {
        if (this.selected.getIdTipoDoc().getIdTipoDoc().intValue() == 2) {
            this.mostrar = true;
        } else {
            this.mostrar = false;
        }
    }


    public boolean getMostrar() {
        return this.mostrar;
    }


    public boolean isSkip() {
        return skip;
    }


    public void setSkip(boolean skip) {
        this.skip = skip;
    }


    public void limpiarDatosFacturacion(Venta miVenta) {
        miVenta.limpiarDatosFacturacion();
    }


    public long totalCompra() {
        long total = this.selected.getDetVentaList().stream().mapToLong(o -> o.getCantidad() * o.getLibro().getPrecioLibro()).sum();
        return total;
    }


    @FacesConverter(forClass = Venta.class)
    public static class VentaControllerConverter implements Converter {

        @Override
        public Object getAsObject(FacesContext facesContext, UIComponent component, String value) {
            if (value == null || value.length() == 0) {
                return null;
            }
            VentaController controller = (VentaController) facesContext.getApplication().getELResolver().
                    getValue(facesContext.getELContext(), null, "ventaController");
            return controller.getVenta(getKey(value));
        }


        java.lang.String getKey(String value) {
            java.lang.String key;
            key = value;
            return key;
        }


        String getStringKey(java.lang.String value) {
            StringBuilder sb = new StringBuilder();
            sb.append(value);
            return sb.toString();
        }


        @Override
        public String getAsString(FacesContext facesContext, UIComponent component, Object object) {
            if (object == null) {
                return null;
            }
            if (object instanceof Venta) {
                Venta o = (Venta) object;
                return getStringKey(o.getIdVenta());
            } else {
                Logger.getLogger(this.getClass().getName()).log(Level.SEVERE, "object {0} is of type {1}; expected type: {2}", new Object[]{object, object.getClass().getName(), Venta.class.getName()});
                return null;
            }
        }


    }

    public void onRowEdit(RowEditEvent event) {
    }


    public void onRowCancel(RowEditEvent event) {
    }


    public void onAddNew() {
        this.selected.getDetVentaList().add(new DetVenta());
    }


    public void agregarLibro(Libro libro) {
        DetVenta miDetalle = new DetVenta();
        this.selected.getDetVentaList().add(miDetalle);
    }


}

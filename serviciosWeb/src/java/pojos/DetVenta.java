package pojos;
// Generated 13-06-2019 3:33:06 by Hibernate Tools 4.3.1

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;




/**
 * DetVenta generated by hbm2java
 */
@JsonIgnoreProperties(value = { "libro","venta" })
public class DetVenta  implements java.io.Serializable {


     private DetVentaId id;
     private Libro libro;
     private Venta venta;
     private short cantidad;

    public DetVenta() {
    }

    public DetVenta(DetVentaId id, Libro libro, Venta venta, short cantidad) {
       this.id = id;
       this.libro = libro;
       this.venta = venta;
       this.cantidad = cantidad;
    }
   
    public DetVentaId getId() {
        return this.id;
    }
    
    public void setId(DetVentaId id) {
        this.id = id;
    }
    public Libro getLibro() {
        return this.libro;
    }
    
    public void setLibro(Libro libro) {
        this.libro = libro;
    }
    public Venta getVenta() {
        return this.venta;
    }
    
    public void setVenta(Venta venta) {
        this.venta = venta;
    }
    public short getCantidad() {
        return this.cantidad;
    }
    
    public void setCantidad(short cantidad) {
        this.cantidad = cantidad;
    }




}



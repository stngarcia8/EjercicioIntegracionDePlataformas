package pojos;
// Generated 13-06-2019 3:33:06 by Hibernate Tools 4.3.1


import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import java.math.BigDecimal;
import java.util.HashSet;
import java.util.Set;

/**
 * Sucursal generated by hbm2java
 */
@JsonIgnoreProperties(value = { "usuarios" })
public class Sucursal  implements java.io.Serializable {


     private BigDecimal idSucursal;
     private String nombreSucursal;
     private String direccionSucursal;
     private Set<Usuario> usuarios = new HashSet<Usuario>(0);

    public Sucursal() {
    }

	
    public Sucursal(BigDecimal idSucursal, String nombreSucursal, String direccionSucursal) {
        this.idSucursal = idSucursal;
        this.nombreSucursal = nombreSucursal;
        this.direccionSucursal = direccionSucursal;
    }
    public Sucursal(BigDecimal idSucursal, String nombreSucursal, String direccionSucursal, Set<Usuario> usuarios) {
       this.idSucursal = idSucursal;
       this.nombreSucursal = nombreSucursal;
       this.direccionSucursal = direccionSucursal;
       this.usuarios = usuarios;
    }
   
    public BigDecimal getIdSucursal() {
        return this.idSucursal;
    }
    
    public void setIdSucursal(BigDecimal idSucursal) {
        this.idSucursal = idSucursal;
    }
    public String getNombreSucursal() {
        return this.nombreSucursal;
    }
    
    public void setNombreSucursal(String nombreSucursal) {
        this.nombreSucursal = nombreSucursal;
    }
    public String getDireccionSucursal() {
        return this.direccionSucursal;
    }
    
    public void setDireccionSucursal(String direccionSucursal) {
        this.direccionSucursal = direccionSucursal;
    }
    public Set<Usuario> getUsuarios() {
        return this.usuarios;
    }
    
    public void setUsuarios(Set<Usuario> usuarios) {
        this.usuarios = usuarios;
    }




}



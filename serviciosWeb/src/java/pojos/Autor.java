package pojos;
// Generated 13-06-2019 3:33:06 by Hibernate Tools 4.3.1

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import java.math.BigDecimal;
import java.util.HashSet;
import java.util.Set;

/**
 * Autor generated by hbm2java
 */
@JsonIgnoreProperties(value = { "libros" })
public class Autor implements java.io.Serializable {

    private BigDecimal idAutor;
    private String nombreAutor;
    private Set<Libro> libros = new HashSet<Libro>(0);

    public Autor() {

    }

    public Autor(BigDecimal idAutor, String nombreAutor) {
        this.idAutor = idAutor;
        this.nombreAutor = nombreAutor;
    }

    public Autor(BigDecimal idAutor, String nombreAutor, Set<Libro> libros) {
        this.idAutor = idAutor;
        this.nombreAutor = nombreAutor;
        this.libros = libros;
    }

    public BigDecimal getIdAutor() {
        return this.idAutor;
    }

    public void setIdAutor(BigDecimal idAutor) {
        this.idAutor = idAutor;
    }

    public String getNombreAutor() {
        return this.nombreAutor;
    }

    public void setNombreAutor(String nombreAutor) {
        this.nombreAutor = nombreAutor;
    }

    public Set<Libro> getLibros() {
        return this.libros;
    }

    public void setLibros(Set<Libro> libros) {
        this.libros = libros;
    }

}
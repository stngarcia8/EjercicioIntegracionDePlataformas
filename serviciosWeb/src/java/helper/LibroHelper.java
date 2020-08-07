/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package helper;

import java.util.List;
import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.Transaction;
import pojos.Libro;
import utility.HibernateUtil;

/**
 *
 * @author floup
 */
public class LibroHelper {

    public LibroHelper() {
    }

    public List<Libro> listLibro() {

        Session session = HibernateUtil.getSessionFactory().openSession();
        Transaction tx = session.beginTransaction();

        List<Libro> lista = null;
        Query q = session.createQuery("from Libro as L inner join fetch L.autor");
        lista = q.list();
        tx.commit();
        session.close();
        return lista;

    }

    public List<Libro> listLibroPorAutor(String autor) {

        Session session = HibernateUtil.getSessionFactory().openSession();
        Transaction tx = session.beginTransaction();

        List<Libro> lista = null;
        Query q = session.createQuery("from Libro as L inner join fetch L.autor where L.autor.nombreAutor='" + autor + "'");
        lista = q.list();
        tx.commit();
        session.close();
        return lista;

    }

    public List<Libro> listLibroPorTitulo(String titulo) {

        Session session = HibernateUtil.getSessionFactory().openSession();
        Transaction tx = session.beginTransaction();

        List<Libro> lista = null;
        Query q = session.createQuery("from Libro as L inner join fetch L.autor where lower(L.tituloLibro) like lower('%" + titulo + "%')");
        lista = q.list();
        tx.commit();
        session.close();
        return lista;

    }
    
        public List<Libro> listLibroPorTituloCompleto(String titulo) {

        Session session = HibernateUtil.getSessionFactory().openSession();
        Transaction tx = session.beginTransaction();

        List<Libro> lista = null;
        Query q = session.createQuery("from Libro as L inner join fetch L.autor where lower(L.tituloLibro)='" + titulo + "'");
        lista = q.list();
        tx.commit();
        session.close();
        return lista;

    }

}

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
import pojos.Autor;
import utility.HibernateUtil;

/**
 *
 * @author floup
 */
public class AutorHelper {

    public AutorHelper() {

    }

    public List<Autor> listAutor() {

        Session session = HibernateUtil.getSessionFactory().openSession();
        Transaction tx = session.beginTransaction();

        List<Autor> lista = null;
        Query q = session.createQuery("FROM  Autor");
        lista = q.list();
        tx.commit();
        session.close();
        return lista;

    }

}

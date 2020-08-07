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
import pojos.Venta;
import utility.HibernateUtil;

/**
 *
 * @author floup
 */
public class VentaHelper {
          public VentaHelper(){
    }
    
    public List<Venta> listVenta() {

        Session session = HibernateUtil.getSessionFactory().openSession();
        Transaction tx = session.beginTransaction();

        List<Venta> lista = null;
        Query q = session.createQuery("FROM Venta");
        lista = q.list();
        tx.commit();
        session.close();
        return lista;

    }
}

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
import pojos.DetVenta;
import utility.HibernateUtil;

/**
 *
 * @author floup
 */
public class DetVentaHelper {

    public DetVentaHelper() {
    }

    public List<DetVenta> listDetVenta() {

        Session session = HibernateUtil.getSessionFactory().openSession();
        Transaction tx = session.beginTransaction();

        List<DetVenta> lista = null;
        Query q = session.createQuery("FROM DetVenta");
        lista = q.list();
        tx.commit();
        session.close();
        return lista;

    }

}

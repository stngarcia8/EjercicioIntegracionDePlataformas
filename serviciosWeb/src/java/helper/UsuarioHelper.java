package helper;

import java.util.List;
import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.Transaction;
import pojos.Usuario;
import utility.HibernateUtil;


/**
 * @author floup
 */
public class UsuarioHelper {

    public UsuarioHelper() {
    }


    public List<Usuario> listUsuario() {

        Session session = HibernateUtil.getSessionFactory().openSession();
        Transaction tx = session.beginTransaction();

        List<Usuario> lista = null;
        Query q = session.createQuery("from Usuario as U inner join fetch U.sucursal inner join fetch U.tipoUs");
        lista = q.list();
        tx.commit();
        session.close();
        return lista;
    }


    public Usuario getUsuario(String rut, String pwd) {
        Session session = HibernateUtil.getSessionFactory().openSession();
        Transaction tx = session.beginTransaction();
        List<Usuario> lista = null;
        String hql = "from Usuario as U inner join fetch U.sucursal inner join fetch U.tipoUs ";
        String hqlWhere = "WHERE U.rutUsuario = :rut AND U.contrasenaUsuario = :pwd ";
        Usuario usuario = null;
        Query q = session.createQuery(hql + hqlWhere);
        q.setParameter("rut", rut);
        q.setParameter("pwd", pwd);
        lista = q.list();
        if (!lista.isEmpty()) {
            usuario = lista.get(0);
        }
        tx.commit();
        session.close();
        return usuario;
    }


}

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ejb;


import ejb.AbstractFacade;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import modelo.Usuario;


/**
 *
 * @author asathor
 */
@Stateless
public class UsuarioFacade extends AbstractFacade<Usuario> {
        

    @PersistenceContext(unitName = "VentaBookPU")
    private EntityManager em;

    @Override
    protected EntityManager getEntityManager() {
        return em;
    }


    public UsuarioFacade() {
        super(Usuario.class);
    }



}

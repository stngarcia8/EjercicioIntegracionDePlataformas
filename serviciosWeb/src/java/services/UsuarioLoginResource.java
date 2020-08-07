package services;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import helper.UsuarioHelper;
import java.util.ArrayList;
import java.util.List;
import javax.ws.rs.core.Context;
import javax.ws.rs.core.UriInfo;
import javax.ws.rs.Produces;
import javax.ws.rs.Consumes;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PUT;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;
import pojos.Usuario;


/**
 * REST Web Service
 *
 * @author asathor
 */
@Path("/login")
public class UsuarioLoginResource {

    UsuarioHelper usuarioHelper = new UsuarioHelper();
    @Context
    private UriInfo context;

    public UsuarioLoginResource() {
    }


    @GET
    @Produces("application/json")
    public String getUsuarioLogin(@QueryParam("rut") String rut, @QueryParam("pwd") String pwd) throws JsonProcessingException {
        ObjectMapper objectMapper = new ObjectMapper();
        String jsonString = "";
        try {
            Usuario usuario = usuarioHelper.getUsuario(rut, pwd);
            jsonString = objectMapper.writeValueAsString(usuario);

        } catch (Exception e) {
            jsonString = "Error de carga " + e.getMessage();
        }
        return jsonString;
    }


}

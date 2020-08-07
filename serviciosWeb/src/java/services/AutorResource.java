package services;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import helper.AutorHelper;
import java.util.ArrayList;
import java.util.List;

import javax.ws.rs.core.Context;
import javax.ws.rs.core.UriInfo;

import javax.ws.rs.Consumes;
import javax.ws.rs.Produces;

import javax.ws.rs.GET;

import javax.ws.rs.PUT;

import javax.ws.rs.Path;

import javax.ws.rs.core.MediaType;

import pojos.Autor;

/**
 * REST Web Service
 *
 * @author floup
 */
@Path("autor")
public class AutorResource {

    private AutorHelper autorHelper;

    @Context
    private UriInfo context;

    /**
     * Creates a new instance of AutorResource
     */
    public AutorResource() {
        autorHelper = new AutorHelper();
    }

    /**
     * Retrieves representation of an instance of services.AutorResource
     *
     * @return an instance of java.lang.String
     */
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public String getJson() {
        //TODO return proper representation object
        throw new UnsupportedOperationException();
    }

    /**
     * PUT method for updating or creating an instance of AutorResource
     *
     * @param content representation for the resource
     */
    @PUT
    @Consumes(MediaType.APPLICATION_JSON)
    public void putJson(String content) {
    }

    @GET
    @Path("getAutorList")
    @Produces("application/json")
    public String getAutorList() throws JsonProcessingException {

        ObjectMapper objectMapper = new ObjectMapper();
        List<Autor> lista = null;
        try {
            lista = new ArrayList(autorHelper.listAutor());

        } catch (Exception e) {
            e.printStackTrace();
        }
        String jsonString = objectMapper.writeValueAsString(lista);
        return jsonString;
    }

}

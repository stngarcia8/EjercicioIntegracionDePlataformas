/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package services;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import helper.TipoDocHelper;
import java.util.ArrayList;
import java.util.List;
import javax.ws.rs.core.Context;
import javax.ws.rs.core.UriInfo;
import javax.ws.rs.Produces;
import javax.ws.rs.Consumes;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PUT;
import javax.ws.rs.core.MediaType;
import pojos.TipoDoc;


/**
 * REST Web Service
 *
 * @author floup
 */
@Path("tipoDoc")
public class TipoDocResource {
    
    TipoDocHelper tipoDocHelper = new TipoDocHelper();

    @Context
    private UriInfo context;

    /**
     * Creates a new instance of TipoDocResource
     */
    public TipoDocResource() {
    }

    /**
     * Retrieves representation of an instance of services.TipoDocResource
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
     * PUT method for updating or creating an instance of TipoDocResource
     *
     * @param content representation for the resource
     */
    @PUT
    @Consumes(MediaType.APPLICATION_JSON)
    public void putJson(String content) {
    }

    @GET
    @Path("getTipoDocList")
    @Produces("application/json")
    public String getTipoDocList() throws JsonProcessingException {

        ObjectMapper objectMapper = new ObjectMapper();
        List<TipoDoc> lista = null;
        try {
            lista = new ArrayList(tipoDocHelper.listTipoDoc());

        } catch (Exception e) {
            e.printStackTrace();
        }
        String jsonString = objectMapper.writeValueAsString(lista);
        return jsonString;
    }
}

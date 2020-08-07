/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package services;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import helper.DetVentaHelper;
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
import pojos.DetVenta;

/**
 * REST Web Service
 *
 * @author floup
 */
@Path("detVenta")
public class DetVentaResource {
    
    DetVentaHelper detVentaHelper=new DetVentaHelper();
    
    @Context
    private UriInfo context;

    /**
     * Creates a new instance of DetVentaResource
     */
    public DetVentaResource() {
    }

    /**
     * Retrieves representation of an instance of services.DetVentaResource
     *
     * @return an instance of java.lang.String
     */
    @GET
    @Produces(MediaType.APPLICATION_XML)
    public String getXml() {
        //TODO return proper representation object
        throw new UnsupportedOperationException();
    }

    /**
     * PUT method for updating or creating an instance of DetVentaResource
     *
     * @param content representation for the resource
     */
    @PUT
    @Consumes(MediaType.APPLICATION_XML)
    public void putXml(String content) {
    }

    @GET
    @Path("getDetVentaList")
    @Produces("application/json")
    public String getDetVentaList() throws JsonProcessingException {

        ObjectMapper objectMapper = new ObjectMapper();
        List<DetVenta> lista = null;
        try {
            lista = new ArrayList(detVentaHelper.listDetVenta());

        } catch (Exception e) {
            e.printStackTrace();
        }
        String jsonString = objectMapper.writeValueAsString(lista);
        return jsonString;
    }

}

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package services;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import helper.LibroHelper;
import java.util.ArrayList;
import java.util.List;
import javax.ws.rs.core.Context;
import javax.ws.rs.core.UriInfo;
import javax.ws.rs.Consumes;
import javax.ws.rs.Produces;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PUT;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;
import pojos.Autor;

/**
 * REST Web Service
 *
 * @author floup
 */
@Path("libro")
public class LibroResource {

    LibroHelper libroHelper = new LibroHelper();
    @Context
    private UriInfo context;

    /**
     * Creates a new instance of LibroResource
     */
    public LibroResource() {
    }

    /**
     * Retrieves representation of an instance of services.LibroResource
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
     * PUT method for updating or creating an instance of LibroResource
     *
     * @param content representation for the resource
     */
    @PUT
    @Consumes(MediaType.APPLICATION_JSON)
    public void putJson(String content) {
    }

    @GET
    @Path("getLibroList")
    @Produces("application/json")
    public String getLibroList() throws JsonProcessingException {

        ObjectMapper objectMapper = new ObjectMapper();
        List<Autor> lista = null;
        try {
            lista = new ArrayList(libroHelper.listLibro());

        } catch (Exception e) {
            e.printStackTrace();
        }
        String jsonString = objectMapper.writeValueAsString(lista);
        return jsonString;
    }

    @GET
    @Path("getLibroBus")
    @Produces("application/json")
    public String getLibroBus(@QueryParam("autor") String autor) throws JsonProcessingException {
        ObjectMapper objectMapper = new ObjectMapper();
        List<Autor> lista = null;
        try {
            lista = new ArrayList(libroHelper.listLibroPorAutor(autor));

        } catch (Exception e) {
            e.printStackTrace();
        }
        String jsonString = objectMapper.writeValueAsString(lista);
        return jsonString;
    }

    @GET
    @Path("getLibroBusPorTitu")
    @Produces("application/json")
    public String getLibroBusPorTitu(@QueryParam("titulo") String titulo) throws JsonProcessingException {
        ObjectMapper objectMapper = new ObjectMapper();
        List<Autor> lista = null;
        try {
            lista = new ArrayList(libroHelper.listLibroPorTitulo(titulo));

        } catch (Exception e) {
            e.printStackTrace();
        }
        String jsonString = objectMapper.writeValueAsString(lista);
        return jsonString;
    }

    @GET
    @Path("getLibroBusPorTituCommpleto")
    @Produces("application/json")
    public String getLibroBusPorTituCommpleto(@QueryParam("titulo") String titulo) throws JsonProcessingException {
        ObjectMapper objectMapper = new ObjectMapper();
        List<Autor> lista = null;
        try {
            lista = new ArrayList(libroHelper.listLibroPorTituloCompleto(titulo));

        } catch (Exception e) {
            e.printStackTrace();
        }
        String jsonString = objectMapper.writeValueAsString(lista);
        return jsonString;
    }
}

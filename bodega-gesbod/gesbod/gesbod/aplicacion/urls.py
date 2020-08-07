from django.conf.urls import url
from gesbod.aplicacion.views import inicio, login, usuarios, editoriales, categorias, autores, sucursales, libros


urlpatterns = [
    # Rutas de la pantalla de inicio.
    url(r'^$', inicio.irInicio, name='irInicio'),

    # Rutas de las sesiones.
    url(r'^login/iniciarSesion/$', login.iniciarSesion, name='iniciarSesion'),
    url(r'^login/cerrarSesion/$', login.cerrarSesion, name='cerrarSesion'),
    url(r'^login/denegarAcceso/$', login.denegarAcceso, name='denegarAcceso'),
    url(r'^login/restringirAcceso/$',
        login.restringirAcceso, name='restringirAcceso'),

    # Rutas para las cuentas de usuario.
    url(r'^lista/usuario/$', usuarios.ListaDeUsuarios.as_view(),
        name='listaDeUsuarios'),
    url(r'^registrar/usuario/$', usuarios.RegistrarUsuario.as_view(),
        name='registrarUsuario'),
    url(r'^editar/usuario/(?P<pk>\d+)$',
        usuarios.EditarUsuario.as_view(), name='editarUsuario'),
    url(r'^eliminar/usuario/(?P<pk>\d+)$',
        usuarios.EliminarUsuario.as_view(), name='eliminarUsuario'),
    url(r'^ver/usuario/(?P<pk>\d+)$',
        usuarios.VerUsuario.as_view(), name='verUsuario'),

    # Rutas para las editoriales.
    url(r'^lista/editorial/$', editoriales.ListaDeEditoriales.as_view(),
        name='listaDeEditoriales'),
    url(r'^registrar/editorial/$',
        editoriales.RegistrarEditorial.as_view(), name='registrarEditorial'),
    url(r'^editar/editorial/(?P<pk>\d+)$',
        editoriales.EditarEditorial.as_view(), name='editarEditorial'),
    url(r'^eliminar/editorial/(?P<pk>\d+)$',
        editoriales.EliminarEditorial.as_view(), name='eliminarEditorial'),
    url(r'^ver/editorial/(?P<pk>\d+)$',
        editoriales.VerEditorial.as_view(), name='verEditorial'),

    # Rutas para las categorias.
    url(r'^lista/categoria/$', categorias.ListaDeCategorias.as_view(),
        name='listaDeCategorias'),
    url(r'^registrar/categoria/$', categorias.RegistrarCategoria.as_view(),
        name='registrarCategoria'),
    url(r'^editar/categoria/(?P<pk>\d+)$',
        categorias.EditarCategoria.as_view(), name='editarCategoria'),
    url(r'^eliminar/categoria/(?P<pk>\d+)$',
        categorias.EliminarCategoria.as_view(), name='eliminarCategoria'),
    url(r'^ver/categoria/(?P<pk>\d+)$',
        categorias.VerCategoria.as_view(), name='verCategoria'),

    # Rutas para los autores.
    url(r'^lista/autor/$', autores.ListaDeAutores.as_view(),
        name='listaDeAutores'),
    url(r'^registrar/autor/$', autores.RegistrarAutor.as_view(),
        name='registrarAutor'),
    url(r'^editar/autor/(?P<pk>\d+)$',
        autores.EditarAutor.as_view(), name='editarAutor'),
    url(r'^eliminar/autor/(?P<pk>\d+)$',
        autores.EliminarAutor.as_view(), name='eliminarAutor'),
    url(r'^ver/autor/(?P<pk>\d+)$',
        autores.VerAutor.as_view(), name='verAutor'),

    # Rutas para las sucursales.
    url(r'^lista/sucursal/$', sucursales.ListaDeSucursales.as_view(),
        name='listaDeSucursales'),
    url(r'^registrar/sucursal/$', sucursales.RegistrarSucursal.as_view(),
        name='registrarSucursal'),
    url(r'^editar/sucursal/(?P<pk>\d+)$',
        sucursales.EditarSucursal.as_view(), name='editarSucursal'),
    url(r'^eliminar/sucursal/(?P<pk>\d+)$',
        sucursales.EliminarSucursal.as_view(), name='eliminarSucursal'),
    url(r'^ver/sucursal/(?P<pk>\d+)$',
        sucursales.VerSucursal.as_view(), name='verSucursal'),

    # Rutas para los libros.
    url(r'^lista/libro/$', libros.ListaDeLibros.as_view(),
        name='listaDeLibros'),
    url(r'^registrar/libro/$', libros.RegistrarLibro.as_view(),
        name='registrarLibro'),
    url(r'^editar/libro/(?P<pk>\d+)$',
        libros.EditarLibro.as_view(), name='editarLibro'),
    url(r'^eliminar/libro/(?P<pk>\d+)$',
        libros.EliminarLibro.as_view(), name='eliminarLibro'),
    url(r'^ver/libro/(?P<pk>\d+)$',
        libros.VerLibro.as_view(), name='verLibro'),

    # Rutas de los ejemplares de libros.
    url(r'^agregar/libro/ejemplar/(?P<pkLibro>\d+)$',
        libros.agregarEjemplar, name='agregarEjemplar'),
    url(r'^listar/libro/ejemplar/(?P<pkLibro>\d+)$',
        libros.listarEjemplares, name='listarEjemplares'),
]

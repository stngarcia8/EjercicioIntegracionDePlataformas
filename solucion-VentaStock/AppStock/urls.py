from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^logout/$', views.cerrarSesion, name="logout"),
    url(r'^login/$', views.iniciarSesion, name="login"),
    url(r'^index/$', views.index, name="index"),
    # url(r'^stock/$', views.verStock, name="stock"),


    url(r'^$', views.index, name=""),

    # Rutas para la lista de libros disponibles.
    url(r'^lista/libros/$', views.ListaDeLibros.as_view(),
        name='listaDeLibros'),
    url(r'^ver/libro/(?P<pk>\d+)$',
        views.VerLibro.as_view(), name='verLibro'),

    # Rutas de las reservas
    url(r'^lista/reserva/$', views.ListaDeReservas.as_view(),
        name='listaDeReservas'),
    url(r'^registrar/reserva/$', views.RegistrarReserva.as_view(),
        name='registrarReserva'),
    url(r'^editar/reserva/(?P<pk>\d+)$',
        views.EditarReserva.as_view(), name='editarReserva'),
    url(r'^eliminar/reservas/(?P<pk>\d+)$',
        views.EliminarReserva.as_view(), name='eliminarReserva'),
    url(r'^ver/reserva/(?P<pk>\d+)$',
        views.VerReserva.as_view(), name='verReserva'),

    # Rutas de las ventas
    url(r'^lista/venta/$', views.ListaDeVentas.as_view(),
        name='listaDeVentas'),
    url(r'^registrar/venta/$', views.RegistrarVenta.as_view(),
        name='registrarVenta'),
    url(r'^editar/venta/(?P<pk>\d+)$',
        views.EditarVenta.as_view(), name='editarVenta'),
    url(r'^eliminar/venta/(?P<pk>\d+)$',
        views.EliminarVenta.as_view(), name='eliminarVenta'),
    url(r'^ver/venta/(?P<pk>\d+)$',
        views.VerVenta.as_view(), name='verVenta'),
]

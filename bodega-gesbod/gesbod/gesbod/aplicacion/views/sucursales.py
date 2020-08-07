import operator
from django.conf import settings
from functools import reduce
from django.views.generic import CreateView, ListView, UpdateView, DeleteView, DetailView
from django.urls import reverse_lazy
from django.db.models import Q
from gesbod.aplicacion.models.sucursal import Sucursal
from gesbod.aplicacion.forms.sucursal import SucursalForm


# ListaDeSucursales
# Clase que permite el listado de las sucursales del sistema.
class ListaDeSucursales(ListView):
    model = Sucursal
    template_name = 'sucursales/listaDeSucursales.html'
    paginate_by = settings.REGISTROS_POR_PAGINA

    def get_queryset(self):
        result = super(ListaDeSucursales, self).get_queryset()
        query = self.request.GET.get('q')
        if query:
            query_list = query.split()
            result = result.filter(reduce(operator.and_,
                                          (Q(nombre__icontains=q) for q in query_list)) |
                                   reduce(operator.and_, (Q(nombre__icontains=q)
                                                          for q in query_list))
                                   )
        return result


# VerSucursal
# Clase que permite visualizar la informacion de una sucursal.
class VerSucursal(DetailView):
    model = Sucursal
    template_name = 'sucursales/verSucursal.html'


# RegistrarSucursal
# Clase que permite registrar una nueva sucursal.
class RegistrarSucursal(CreateView):
    model = Sucursal
    template_name = 'sucursales/registrarSucursal.html'
    form_class = SucursalForm
    success_url = reverse_lazy('listaDeSucursales')


# EditarSucursal
# Clase que permite editar la informacion de una sucursal.
class EditarSucursal(UpdateView):
    model = Sucursal
    form_class = SucursalForm
    template_name = 'sucursales/editarSucursal.html'
    success_url = reverse_lazy('listaDeSucursales')


# EliminarSucursal
# Clase que permite eliminar una sucursal.
class EliminarSucursal(DeleteView):
    model = Sucursal
    template_name = 'sucursales/eliminarSucursal.html'
    success_url = reverse_lazy('listaDeSucursales')

import operator
from django.conf import settings
from functools import reduce
from django.views.generic import CreateView, ListView, UpdateView, DeleteView, DetailView
from django.urls import reverse_lazy
from django.db.models import Q
from gesbod.aplicacion.models.categoria import Categoria
from gesbod.aplicacion.forms.categoria import CategoriaForm


# ListaDeCategorias
# Clase que permite el listado de las categorias del sistema.
class ListaDeCategorias(ListView):
    model = Categoria
    template_name = 'categorias/listaDeCategorias.html'
    paginate_by = settings.REGISTROS_POR_PAGINA

    def get_queryset(self):
        result = super(ListaDeCategorias, self).get_queryset()
        query = self.request.GET.get('q')
        if query:
            query_list = query.split()
            result = result.filter(reduce(operator.and_,
                                          (Q(nombre__icontains=q) for q in query_list)) |
                                   reduce(operator.and_, (Q(nombre__icontains=q)
                                                          for q in query_list))
                                   )
        return result


# VerCategoria
# Clase que permite visualizar la informacion de una categoria.
class VerCategoria(DetailView):
    model = Categoria
    template_name = 'categorias/verCategoria.html'


# RegistrarCategoria
# Clase que permite registrar una nueva categoria.
class RegistrarCategoria(CreateView):
    model = Categoria
    template_name = 'categorias/registrarCategoria.html'
    form_class = CategoriaForm
    success_url = reverse_lazy('listaDeCategorias')


# EditarCategoria
# Clase que permite editar la informacion de una categoria.
class EditarCategoria(UpdateView):
    model = Categoria
    form_class = CategoriaForm
    template_name = 'categorias/editarCategoria.html'
    success_url = reverse_lazy('listaDeCategorias')


# EliminarCategoria
# Clase que permite eliminar una categoria.
class EliminarCategoria(DeleteView):
    model = Categoria
    template_name = 'categorias/eliminarCategoria.html'
    success_url = reverse_lazy('listaDeCategorias')

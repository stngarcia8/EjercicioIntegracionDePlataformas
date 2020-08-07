import operator
from django.conf import settings
from functools import reduce
from django.views.generic import CreateView, ListView, UpdateView, DeleteView, DetailView
from django.urls import reverse_lazy
from django.db.models import Q
from gesbod.aplicacion.models.autor import Autor
from gesbod.aplicacion.forms.autor import AutorForm


# ListaDeAutores
# Clase que permite el listado de los autores del sistema.
class ListaDeAutores(ListView):
    model = Autor
    template_name = 'autores/listaDeAutores.html'
    paginate_by = settings.REGISTROS_POR_PAGINA

    def get_queryset(self):
        result = super(ListaDeAutores, self).get_queryset()
        query = self.request.GET.get('q')
        if query:
            query_list = query.split()
            result = result.filter(reduce(operator.and_,
                                          (Q(nombre__icontains=q) for q in query_list)) |
                                   reduce(operator.and_, (Q(apellidos__icontains=q)
                                                          for q in query_list))
                                   )
        return result


# VerAutor
# Clase que permite visualizar la informacion de un autor.
class VerAutor(DetailView):
    model = Autor
    template_name = 'autores/verAutor.html'


# RegistrarAutor
# Clase que permite registrar un nuevo autor.
class RegistrarAutor(CreateView):
    model = Autor
    template_name = 'autores/registrarAutor.html'
    form_class = AutorForm
    success_url = reverse_lazy('listaDeAutores')


# EditarAutor
# Clase que permite editar la informacion de un autor.
class EditarAutor(UpdateView):
    model = Autor
    form_class = AutorForm
    template_name = 'autores/editarAutor.html'
    success_url = reverse_lazy('listaDeAutores')


# EliminarAutor
# Clase que permite eliminar un autor.
class EliminarAutor(DeleteView):
    model = Autor
    template_name = 'autores/eliminarAutor.html'
    success_url = reverse_lazy('listaDeAutores')

import operator
from django.conf import settings
from functools import reduce
from django.views.generic import CreateView, ListView, UpdateView, DeleteView, DetailView
from django.urls import reverse_lazy
from django.db.models import Q
from gesbod.aplicacion.models.editorial import Editorial
from gesbod.aplicacion.forms.editorial import EditorialForm


# ListaDeEditoriales
# Clase que permite el listado de las editoriales del sistema.
class ListaDeEditoriales(ListView):
    model = Editorial
    template_name = 'editoriales/listaDeEditoriales.html'
    paginate_by = settings.REGISTROS_POR_PAGINA

    def get_queryset(self):
        result = super(ListaDeEditoriales, self).get_queryset()
        query = self.request.GET.get('q')
        if query:
            query_list = query.split()
            result = result.filter(reduce(operator.and_,
                                          (Q(nombre__icontains=q) for q in query_list)) |
                                   reduce(operator.and_, (Q(nombre__icontains=q)
                                                          for q in query_list))
                                   )
        return result


# VerEditorial
# Clase que permite visualizar la informacion de una editorial.
class VerEditorial(DetailView):
    model = Editorial
    template_name = 'editoriales/verEditorial.html'


# RegistrarEditorial
# Clase que permite registrar una nueva editorial.
class RegistrarEditorial(CreateView):
    model = Editorial
    template_name = 'editoriales/registrarEditorial.html'
    form_class = EditorialForm
    success_url = reverse_lazy('listaDeEditoriales')


# EditarEditorial
# Clase que permite editar la informacion de una editorial.
class EditarEditorial(UpdateView):
    model = Editorial
    form_class = EditorialForm
    template_name = 'editoriales/editarEditorial.html'
    success_url = reverse_lazy('listaDeEditoriales')


# EliminarEditorial
# Clase que permite eliminar una editorial.
class EliminarEditorial(DeleteView):
    model = Editorial
    template_name = 'editoriales/eliminarEditorial.html'
    success_url = reverse_lazy('listaDeEditoriales')

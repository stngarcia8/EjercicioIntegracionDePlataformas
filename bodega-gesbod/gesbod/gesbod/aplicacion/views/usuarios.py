from django.conf import settings
import operator
from functools import reduce
from django.views.generic import CreateView, ListView, UpdateView, DeleteView, DetailView
from django.contrib.auth.models import User
from django.urls import reverse_lazy
from django.db.models import Q
from gesbod.aplicacion.forms.usuario import UsuarioForm


# ListaDeUsuarios
# Clase que permite el listado de los usuarios del sistema.
class ListaDeUsuarios(ListView):
    model = User
    template_name = 'usuarios/listaDeUsuarios.html'
    paginate_by = settings.REGISTROS_POR_PAGINA

    def get_queryset(self):
        result = super(ListaDeUsuarios, self).get_queryset()
        query = self.request.GET.get('q')
        if query:
            query_list = query.split()
            result = result.filter(reduce(operator.and_,
                                          (Q(username__icontains=q) for q in query_list)) |
                                   reduce(operator.and_, (Q(first_name__icontains=q)
                                                          for q in query_list))
                                   )
        return result


# VerUsuario
# Clase que permite visualizar la informacion de un usuario.
class VerUsuario(DetailView):
    model = User
    template_name = 'usuarios/verUsuario.html'


# RegistrarUsuario
# Clase que permite registrar un nuevo usuario.
class RegistrarUsuario(CreateView):
    model = User
    form_class = UsuarioForm
    template_name = 'usuarios/registrarUsuario.html'
    success_url = reverse_lazy('listaDeUsuarios')


# EditarUsuario
# Clase que permite editar la informacion de un usuario.
class EditarUsuario(UpdateView):
    model = User
    form_class = UsuarioForm
    template_name = 'usuarios/editarUsuario.html'
    success_url = reverse_lazy('listaDeUsuarios')


# EliminarUsuario
# Clase que permite eliminar un usuario.
class EliminarUsuario(DeleteView):
    model = User
    template_name = 'usuarios/eliminarUsuario.html'
    success_url = reverse_lazy('listaDeUsuarios')

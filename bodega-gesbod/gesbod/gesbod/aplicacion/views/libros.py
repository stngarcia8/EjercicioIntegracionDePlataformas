import operator
from django.conf import settings
from django.http import HttpResponse
from django.template import loader
from django.shortcuts import redirect, render
from functools import reduce
from django.views.generic import CreateView, ListView, UpdateView, DeleteView, DetailView
from django.urls import reverse_lazy
from django.db.models import Q
from gesbod.aplicacion.models.libro import Libro, Ejemplar_libro
from gesbod.aplicacion.forms.libro import LibroForm, AgregarEjemplarForm
from django.contrib.auth.decorators import login_required


# ListaDeLibros
# Clase que permite el listado de los libros del sistema.
class ListaDeLibros(ListView):
    model = Libro
    template_name = 'libros/listaDeLibros.html'
    paginate_by = settings.REGISTROS_POR_PAGINA

    def get_queryset(self):
        result = super(ListaDeLibros, self).get_queryset()
        query = self.request.GET.get('q')
        if query:
            query_list = query.split()
            result = result.filter(reduce(operator.and_,
                                          (Q(titulo__icontains=q) for q in query_list)) |
                                   reduce(operator.and_, (Q(titulo__icontains=q)
                                                          for q in query_list))
                                   )
        return result


# VerLibro
# Clase que permite visualizar la informacion de un libro.
class VerLibro(DetailView):
    model = Libro
    template_name = 'libros/verLibro.html'


# RegistrarLibro
# Clase que permite registrar un nuevo libro.
class RegistrarLibro(CreateView):
    model = Libro
    template_name = 'libros/registrarLibro.html'
    form_class = LibroForm
    success_url = reverse_lazy('listaDeLibros')


# EditarLibro
# Clase que permite editar la informacion de un libro.
class EditarLibro(UpdateView):
    model = Libro
    form_class = LibroForm
    template_name = 'libros/editarLibro.html'
    success_url = reverse_lazy('listaDeLibros')


# EliminarLibro
# Clase que permite eliminar un libro.
class EliminarLibro(DeleteView):
    model = Libro
    template_name = 'libros/eliminarLibro.html'
    success_url = reverse_lazy('listaDeLibros')


# agregarEjemplar
# Vista que permite agregar ejemplares a un libro.
@login_required
def agregarEjemplar(request, pkLibro):
    form = AgregarEjemplarForm(request.POST)
    if form.is_valid():
        data = form.cleaned_data
        miLibro = Libro.objects.get(id=pkLibro)
        i = 1
        cant = int(data.get('cantidad_ejemplares'))
        while (i <= cant):
            miEjemplar = Ejemplar_libro()
            miEjemplar.libro = miLibro
            miEjemplar.orden_compra = data.get('orden_compra')
            miEjemplar.save()
            i = i+1
        miLibro.cantidad_ejemplares = miLibro.cantidad_ejemplares + \
            int(data.get('cantidad_ejemplares'))
        miLibro.save()
        return redirect('verLibro', pk=miLibro.id)
    else:
        miLibro = Libro.objects.get(id=pkLibro)
        form = AgregarEjemplarForm(request.POST)
    return render(request, "libros/agregarEjemplar.html", {
        'form': form,
        'libro': miLibro})


# listarEjemplares
# Vista que permite listar los ejemplares de un libro.
@login_required
def listarEjemplares(request, pkLibro):
    miLibro = Libro.objects.get(id=pkLibro)
    misEjemplares = Ejemplar_libro.objects.filter(libro=miLibro)
    miPlantilla = loader.get_template("libros/listaDeEjemplares.html")
    miContexto = {'libro': miLibro, 'ejemplares_list': misEjemplares}
    return HttpResponse(miPlantilla.render(miContexto, request))

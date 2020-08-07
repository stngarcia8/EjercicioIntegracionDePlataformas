import requests
from django.http.response import HttpResponseRedirect
from django.views.generic import CreateView, ListView, UpdateView, DeleteView, DetailView
from django.urls import reverse_lazy
from django.conf import settings
from django.contrib.auth.models import User
from django.template import loader
from django.http import HttpResponse
from django.shortcuts import redirect
from django.contrib.auth import authenticate, login, logout
from django.contrib.auth.decorators import login_required
from .forms import InicioSesionForm
from api.serializer import UsuarioSerializer
from api.models import Libro, Autor, Reserva, Venta, DetalleVenta
from .forms import ReservaForm, VentaForm, DetalleVentaFormSet


# index():
# Vista para la pagina principal del sistema.
@login_required(login_url='login')
def index(request):
    template = loader.get_template("index.html")
    context = {
        'title': "Pagina Principal",
    }
    __cargarAutores(request)
    __cargarLibros(request)
    return HttpResponse(template.render(context, request))


# iniciarSesion():
# Vista para el inicio de sesión en el sistema.
def iniciarSesion(request):
    if request.user.is_authenticated:
        return redirect('index')

    form = InicioSesionForm(request.POST or None)
    template = loader.get_template("login.html")
    title = "Inicio de Sesión"
    context = {'title': title, 'form': form, }
    if form.is_valid():
        data = form.cleaned_data
        username = data.get('username')
        password = data.get('password')
        json = None
        try:
            resultado = requests.get(settings.URL_LOGIN_SERVICE.format(un=username, pw=password))
            json = resultado.json()
        except Exception:
            template = loader.get_template("servicioLoginNoDisponible.html")
            return HttpResponse(template.render({}, request))

        if json is not None:
            serializador = UsuarioSerializer(data=json)
            serializador.is_valid()
            logout(request)
            eliminarUsuario(serializador.data.get('rutUsuario'))
            User.objects.create_user(
                username=serializador.data.get('rutUsuario'),
                password=serializador.data.get('contrasenaUsuario'),
                first_name=serializador.data.get('nombreUsuario'))
            user = authenticate(
                username=serializador.data.get('rutUsuario'),
                password=serializador.data.get('contrasenaUsuario'))
            if user is not None:
                login(request, user)
                return redirect('index')
    return HttpResponse(template.render(context, request))


# cerrarSesion():
# Vista para el cierre de la sesión en el sistema.
@login_required(login_url='login')
def cerrarSesion(request):
    logout(request)
    eliminarUsuario(request.user.username)
    return redirect('login')


# eliminarUsuario():
# funcion que elimina un usuario del sistema.
def eliminarUsuario(userName):
    try:
        u = User.objects.get(username=userName)
        u.delete()
        return
    except Exception:
        return


# librosDisponibles()
# Vista que muestra los libros disponibles en sucursal.
class ListaDeLibros(ListView):
    model = Libro
    template_name = 'libros/listaDeLibros.html'
    paginate_by = settings.REGISTROS_POR_PAGINA

    def get_queryset(self):
        result = super(ListaDeLibros, self).get_queryset()
        query = self.request.GET.get('q')
        if query:
            result = result.filter(tituloLibro__contains=query)
        return result


# VerLibro
# Clase que permite visualizar la informacion de un libro.
class VerLibro(DetailView):
    model = Libro
    template_name = 'libros/verLibro.html'


def __cargarLibros(request):
    libros = None
    try:
        resultado = requests.get(settings.URL_LIBRO_SERVICE)
        libros = resultado.json()
    except Exception:
        template = loader.get_template("servicioLibroNoDisponible.html")
        return HttpResponse(template.render({}, request))

    datos = []
    if libros:
        for libro in libros:
            miAutor = Autor()
            miAutor.idAutor = libro['autor']['idAutor']
            miAutor.nombreAutor = libro['autor']['nombreAutor']
            miLibro = Libro()
            miLibro.idLibro = libro['idLibro']
            miLibro.autor = miAutor
            miLibro.tituloLibro = libro['tituloLibro']
            miLibro.isbnLibro = libro['isbnLibro']
            miLibro.sinopsisLibro = libro['sinopsisLibro']
            miLibro.cantidadejemplaresLibro = libro['cantidadejemplaresLibro']
            miLibro.precioLibro = libro['precioLibro']
            miLibro.usuario = request.user
            datos.append(miLibro)

        if datos:
            Libro.objects.all().delete()
            Libro.objects.bulk_create(datos)


def __cargarAutores(request):
    autores = None
    try:
        resultado = requests.get(settings.URL_AUTOR_SERVICE)
        autores = resultado.json()
    except Exception:
        template = loader.get_template("servicioAutorNoDisponible.html")
        return HttpResponse(template.render({}, request))

    datos = []
    if autores:
        for autor in autores:
            miAutor = Autor()
            miAutor.idAutor = autor['idAutor']
            miAutor.nombreAutor = autor['nombreAutor']
            miAutor.usuario = request.user
            datos.append(miAutor)

        if datos:
            Autor.objects.all().delete()
            Autor.objects.bulk_create(datos)


# ListaDeReservas
# Clase que permite visualizar las reservas realizadas.
class ListaDeReservas(ListView):
    model = Reserva
    template_name = 'reservas/listaDeReservas.html'
    paginate_by = settings.REGISTROS_POR_PAGINA

    def get_queryset(self):
        result = super(ListaDeReservas, self).get_queryset()
        query = self.request.GET.get('q')
        if query:
            result = result.filter(nombre_cliente__contains=query)
        return result


# RegistrarReserva
# Clase que permite registrar una reserva.
class RegistrarReserva(CreateView):
    model = Reserva
    template_name = 'reservas/registrarReserva.html'
    form_class = ReservaForm
    success_url = reverse_lazy('listaDeReservas')


# EditarReserva
# Clase que permite editar una reserva.
class EditarReserva(UpdateView):
    model = Reserva
    form_class = ReservaForm
    template_name = 'reservas/editarReserva.html'
    success_url = reverse_lazy('listaDeReservas')


# EliminarReserva
# Clase que permite eliminar una reserva.
class EliminarReserva(DeleteView):
    model = Reserva
    template_name = 'reservas/eliminarReserva.html'
    success_url = reverse_lazy('listaDeReservas')


# VerReserva
# Clase que permite visualizar la informacion de una reserva realizada por un cliente..
class VerReserva(DetailView):
    model = Reserva
    template_name = 'reservas/verReserva.html'


# ListaDeVentas
# Clase que permite visualizar las ventas realizadas.
class ListaDeVentas(ListView):
    model = Venta
    template_name = 'ventas/listaDeVentas.html'
    paginate_by = settings.REGISTROS_POR_PAGINA

    def get_queryset(self):
        result = super(ListaDeVentas, self).get_queryset()
        query = self.request.GET.get('q')
        if query:
            result = result.filter(nombreCliente__contains=query)
        return result


# RegistrarVenta
# Clase que permite registrar una venta.
class RegistrarVenta(CreateView):
    model = Venta
    template_name = 'ventas/registrarVenta.html'
    form_class = VentaForm
    success_url = reverse_lazy('listaDeVentas')

    def get(self, request, *args, **kwargs):
        self.object = None
        # self.object = self.get_object()
        form_class = self.get_form_class()
        form = self.get_form(form_class)
        detalles = DetalleVenta.objects.filter(venta=self.object).order_by('pk')
        detalles_data = []
        for detalle in detalles:
            d = {'libro': detalle.libro,
                 'cantidad': detalle.cantidad,
                 'precio': detalle.precio}
            detalles_data.append(d)
        detalle_venta_form_set = DetalleVentaFormSet(initial=detalles_data)
        return self.render_to_response(self.get_context_data(form=form,
                                                             detalle_venta_form_set=detalle_venta_form_set))

    def post(self, request, *args, **kwargs):
        # self.object = self.get_object()
        form_class = self.get_form_class()
        form = self.get_form(form_class)
        detalle_venta_form_set = DetalleVentaFormSet(request.POST)
        if form.is_valid() and detalle_venta_form_set.is_valid():
            return self.form_valid(form, detalle_venta_form_set)
        else:
            return self.form_invalid(form, detalle_venta_form_set)

    def form_valid(self, form, detalle_venta_form_set):
        self.object = form.save(commit=False)
        self.object.nombreUsuario = self.request.user.first_name
        self.object.rutUsuario = self.request.user.username
        self.object.save()
        detalle_venta_form_set.instance = self.object
        DetalleVenta.objects.filter(venta=self.object).delete()
        detalle_venta_form_set.save()
        return HttpResponseRedirect(self.success_url)

    def form_invalid(self, form, detalle_venta_form_set):
        return self.render_to_response(self.get_context_data(form=form,
                                                             detalle_venta_form_set=detalle_venta_form_set))


# EditarVenta
# Clase que permite editar una venta.
class EditarVenta(UpdateView):
    model = Venta
    template_name = 'ventas/editarVenta.html'
    form_class = VentaForm
    success_url = reverse_lazy('listaDeVentas')

    def get(self, request, *args, **kwargs):
        self.object = self.get_object()
        form_class = self.get_form_class()
        form = self.get_form(form_class)
        detalles = DetalleVenta.objects.filter(venta=self.object).order_by('pk')
        detalles_data = []
        for detalle in detalles:
            d = {'libro': detalle.libro,
                 'cantidad': detalle.cantidad,
                 'precio': detalle.precio}
            detalles_data.append(d)
        detalle_venta_form_set = DetalleVentaFormSet(initial=detalles_data)
        return self.render_to_response(self.get_context_data(form=form,
                                                             detalle_venta_form_set=detalle_venta_form_set))

    def post(self, request, *args, **kwargs):
        self.object = self.get_object()
        form_class = self.get_form_class()
        form = self.get_form(form_class)
        detalle_venta_form_set = DetalleVentaFormSet(request.POST)
        if form.is_valid() and detalle_venta_form_set.is_valid():
            return self.form_valid(form, detalle_venta_form_set)
        else:
            return self.form_invalid(form, detalle_venta_form_set)

    def form_valid(self, form, detalle_venta_form_set):
        self.object = form.save(commit=False)
        self.object.nombreUsuario = self.request.user.first_name
        self.object.rutUsuario = self.request.user.username
        self.object.save()
        detalle_venta_form_set.instance = self.object
        DetalleVenta.objects.filter(venta=self.object).delete()
        detalle_venta_form_set.save()
        return HttpResponseRedirect(self.success_url)

    def form_invalid(self, form, detalle_venta_form_set):
        return self.render_to_response(self.get_context_data(form=form,
                                                             detalle_venta_form_set=detalle_venta_form_set))


# EliminarReserva
# Clase que permite eliminar una reserva.
class EliminarVenta(DeleteView):
    pass


# VerVenta
# Clase que permite visualizar la informacion de una venta.
class VerVenta(DetailView):
    pass

from django.shortcuts import redirect, render
from django.http import HttpResponse
from django.template import loader
from gesbod.aplicacion.forms.login import LoginForm
from django.contrib.auth import authenticate, login, logout
from django.contrib.auth.decorators import login_required


# iniciarSesion()
# Vista que permite el inicio de sesion.
def iniciarSesion(request):
    form = LoginForm(request.POST)
    if form.is_valid():
        data = form.cleaned_data
        user = authenticate(
            username=data.get("username"), password=data.get("password"))
        if user is not None:
            login(request, user)
            return redirect('irInicio')
        else:
            return redirect('denegarAcceso')
    return render(request, "login/login.html", {'form': form})


# cerrarSesion()
# Vista que permite el cierre de la sesion del usuario.
@login_required(login_url='iniciarSesion')
def cerrarSesion(request):
    logout(request)
    return redirect('/')


# denegarAcceso()
# Vista que muestra la pagina de acceso denegado.
def denegarAcceso(request):
    miPlantilla = loader.get_template("login/denegarAcceso.html")
    return HttpResponse(miPlantilla.render({}, request))


# restringirAcceso()
# Vista que muestra la pagina de acceso restringido.
def restringirAcceso(request):
    miPlantilla = loader.get_template("login/restringirAcceso.html")
    return HttpResponse(miPlantilla.render({}, request))

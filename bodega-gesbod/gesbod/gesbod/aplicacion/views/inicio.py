from django.shortcuts import redirect
from django.http import HttpResponse
from django.template import loader


# irInicio()
# Vista que permite carga la pagina de inicio.
def irInicio(request):
    if request.user.is_authenticated:
        miPlantilla = loader.get_template("inicio/index.html")
        return HttpResponse(miPlantilla.render({}, request))
    else:
        return redirect('iniciarSesion')

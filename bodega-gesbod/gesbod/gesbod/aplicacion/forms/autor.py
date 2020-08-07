from django.forms import ModelForm
from gesbod.aplicacion.models.autor import Autor


# AutorForm
# Formulario de autores.
class AutorForm(ModelForm):
    class Meta:
        model = Autor
        fields = ('nombre', 'apellidos', 'descripcion', 'habilitado')

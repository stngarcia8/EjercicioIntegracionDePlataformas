from django.forms import ModelForm
from gesbod.aplicacion.models.categoria import Categoria


# CategoriaForm
# Formulario de categorias.
class CategoriaForm(ModelForm):
    class Meta:
        model = Categoria
        fields = ('nombre', 'habilitado')

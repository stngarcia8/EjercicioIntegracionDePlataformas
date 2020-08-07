from django.forms import ModelForm
from gesbod.aplicacion.models.editorial import Editorial


# EditorialForm
# Formulario de editoriales.
class EditorialForm(ModelForm):
    class Meta:
        model = Editorial
        fields = ('nombre', 'habilitado')

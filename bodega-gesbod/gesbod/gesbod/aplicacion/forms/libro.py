from django.forms import ModelForm
from django import forms
from gesbod.aplicacion.models.libro import Libro


# LibroForm
# Formulario de libros.
class LibroForm(ModelForm):
    class Meta:
        model = Libro
        fields = ('titulo', 'isbn', 'autor', 'editorial',
                  'categoria', 'idioma', 'sinopsis')


# AgregarEjemplarForm
# Formulario para agregar ejemplares de libros.
class AgregarEjemplarForm(forms.Form):
    orden_compra = forms.CharField(
        widget=forms.TextInput(), label="Orden de compra nro.")
    cantidad_ejemplares = forms.CharField(
        widget=forms.TextInput(
            attrs={'class': 'form-control', 'pattern': '[0-9]+', 'title': 'Enter numbers Only'}),
        label="Cantidad ejemplares")

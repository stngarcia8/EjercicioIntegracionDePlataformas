from django import forms
from django.forms.models import modelformset_factory, inlineformset_factory
from django.forms import ModelForm
from api.models import Reserva, Venta, DetalleVenta


class InicioSesionForm(forms.Form):
    username = forms.CharField(widget=forms.TextInput(), label="RUT Usuario")
    password = forms.CharField(widget=forms.PasswordInput(), label="Contraseña")


# ReservaForm:
# Formulario de registro de reservas.
class ReservaForm(ModelForm):
    class Meta:
        model = Reserva
        fields = ('libro', 'nombre_cliente', 'email', 'tipoRetiro', 'lugar_retiro')


# VentaForm:
# Formulario de registro de ventas.
class VentaForm(ModelForm):
    class Meta:
        model = Venta
        fields = ('rutCliente', 'nombreCliente', 'tipoDocumento', 'formaPago')

    def __init__(self, *args, **kwargs):
        super(VentaForm, self).__init__(*args, **kwargs)
        for field in iter(self.fields):
            self.fields[field].widget.attrs.update({
                'class': 'form-control'
            })


# DetalleVentaForm:
# Formulario del detalle de la venta.
class DetalleVentaForm(ModelForm):
    class Meta:
        model = DetalleVenta
        fields = ('libro', 'cantidad', 'precio')

    def __init__(self, *args, **kwargs):
        super(DetalleVentaForm, self).__init__(*args, **kwargs)
        for field in iter(self.fields):
            self.fields[field].widget.attrs.update({
                'class': 'form-control'
            })


# Creando el formset del detalle de la venta.
DetalleVentaFormSet = inlineformset_factory(Venta, DetalleVenta, form=DetalleVentaForm, extra=4)

from api.models import TipoRetiro, TipoDocumento, FormaPago
from django.core.management.base import BaseCommand


class Command(BaseCommand):
    help = 'Ingresa valores de prueba para VentaStock.'

    def handle(self, *args, **kwargs):
        self.crearTipoRetiro()
        self.crearTipoDocumento()
        self.crearFormasDePagos()
        print('Base de datos poblada para pruebas!')

    # crearTipoRetiro()
    # Metodo para crear tipos de retiro de ejemplos.
    def crearTipoRetiro(self):
        print('Creando tipos de retiro...')
        TipoRetiro.objects.all().delete()
        myTipo = TipoRetiro(nombreTipoRetiro='Sucursal')
        myTipo.save()
        myTipo = TipoRetiro(nombreTipoRetiro='Domicilio')
        myTipo.save()

    # crearTipoDocumento()
    # Metodo para crear tipos de documentos de ejemplos.
    def crearTipoDocumento(self):
        print('Creando tipos de documentos...')
        TipoDocumento.objects.all().delete()
        myTipo = TipoDocumento(nombreTipoDocumento='Boleta')
        myTipo.save()
        myTipo = TipoDocumento(nombreTipoDocumento='Factura')
        myTipo.save()

    # crearFormaPago()
    # Metodo para crear formas de pagos de ejemplos.
    def crearFormasDePagos(self):
        print('Creando formas de pagos...')
        FormaPago.objects.all().delete()
        myFormaPago = FormaPago(nombreFormaPago='Efectivo')
        myFormaPago.save()
        myFormaPago = FormaPago(nombreFormaPago='Cheque')
        myFormaPago.save()
        myFormaPago = FormaPago(nombreFormaPago='Tarjeta de crédito')
        myFormaPago.save()
        myFormaPago = FormaPago(nombreFormaPago='Tarjeta de débito')
        myFormaPago.save()

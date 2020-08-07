from django.db import models
from django.urls import reverse
import datetime
import uuid
from django.core.validators import MaxValueValidator, MinValueValidator


# Autor# Clase que define un autor.
class Autor(models.Model):
    idAutor = models.AutoField(primary_key=True)
    nombreAutor = models.CharField(max_length=75)

    def __str__(self):
        return self.nombreAutor

    class meta:
        ordering = ['nombreAutor']


# Libro
# Clase para definir un libro de la libreria.
class Libro(models.Model):
    idLibro = models.AutoField(primary_key=True)
    autor = models.ForeignKey(
        Autor, on_delete=models.SET_NULL, null=True, help_text='Seleccione un autor')
    tituloLibro = models.CharField(max_length=50)
    isbnLibro = models.CharField(max_length=25)
    sinopsisLibro = models.TextField(max_length=1000, null=True, blank=True)
    cantidadejemplaresLibro = models.PositiveIntegerField(
        default=0, verbose_name='Cantidad ejemplares',
        validators=[MinValueValidator(0), MaxValueValidator(9999)])
    precioLibro = models.PositiveIntegerField(
        default=0, verbose_name='Precio',
        validators=[MinValueValidator(0), MaxValueValidator(9999999)])

    def get_absolute_url(self):
        return reverse('verLibro', args=[self.idLibro])

    class meta:
        ordering = ('tituloLibro',)

    def __str__(self):
        return self.tituloLibro


# tipoUs
# Clase que define un tipo de usuario de la libreria.
class TipoUs(models.Model):
    idTipo = models.AutoField(primary_key=True)
    nombreTipo = models.CharField(max_length=75)

    def __str__(self):
        return self.nombreTipo

    class meta:
        ordering = ['nombreTipo']


# Sucursal
# Clase que define una sucursal de la libreria.
class Sucursal(models.Model):
    idSucursal = models.AutoField(primary_key=True)
    nombreSucursal = models.CharField(max_length=75)

    def __str__(self):
        return self.nombreSucursal

    class meta:
        ordering = ['nombreSucursal']


# Usuario
# Clase que define un usuario del sistema.
class Usuario(models.Model):
    idUsuario = models.AutoField(primary_key=True)
    tipoUs = models.ForeignKey(
        TipoUs, on_delete=models.SET_NULL, null=True, help_text='Seleccione un tipo de usuario')
    sucursal = models.ForeignKey(
        Sucursal, on_delete=models.SET_NULL, null=True, help_text='Seleccione un tipo de usuario')
    nombreUsuario = models.CharField(max_length=50)
    rutUsuario = models.CharField(max_length=10)
    contrasenaUsuario = models.CharField(max_length=20)

    def __str__(self):
        return self.nombreUsuario

    class meta:
        ordering = ['nombreUsuario']


# TipoRetiro
# Clase que define un tipo de retiro.
class TipoRetiro(models.Model):
    nombreTipoRetiro = models.CharField(max_length=75)

    def __str__(self):
        return self.nombreTipoRetiro

    class meta:
        ordering = ['nombreTipoRetiro']


# TipoDocumento
# Clase que define un tipo de documento.
class TipoDocumento(models.Model):
    nombreTipoDocumento = models.CharField(max_length=20)

    def __str__(self):
        return self.nombreTipoDocumento

    class meta:
        ordering = ['nombreTipoDocumento']


# FormaPago
# Clase que define una forma de pago.
class FormaPago(models.Model):
    nombreFormaPago = models.CharField(max_length=20)

    def __str__(self):
        return self.nombreFormaPago

    class meta:
        ordering = ['nombreFormaPago']


# SucursalRetiro:
# Clase que define una sucursal.
class SucursalRetiro(models.Model):
    nombreSucursal = models.CharField(max_length=75)

    def __str__(self):
        return self.nombreSucursal

    class meta:
        ordering = ['nombreSucursal']


# Reserva:
# Clase que define una reserva de libro.
class Reserva(models.Model):
    libro = models.ForeignKey(
        Libro, on_delete=models.SET_NULL, null=True, help_text='Seleccione un libro')
    nombre_cliente = models.CharField(max_length=50)
    email = models.CharField(max_length=75)
    tipoRetiro = models.ForeignKey(
        TipoRetiro, on_delete=models.SET_NULL, null=True, help_text='Seleccione un autor')
    lugar_retiro = models.CharField(max_length=150)
    fecha_reserva = models.DateField(
        default=datetime.date.today,
        help_text='Formato: dd/mm/aaaa',
        verbose_name='Fecha reserva')

    def get_absolute_url(self):
        return reverse('verReserva', args=[self.id])

    def get_update_url(self):
        return reverse('editarReserva', args=[self.id])

    def get_delete_url(self):
        return reverse('eliminarReserva', args=[self.id])

    def __str__(self):
        return self.libro.tituloLibro + ' ' + self.libro.autor.nombreAutor

    class meta:
        ordering = ['fecha_reserva']


# Venta:
# Clase que define una venta de libro.
class Venta(models.Model):
    folioVenta = models.UUIDField(default=uuid.uuid4, editable=False)
    fechaVenta = models.DateField(
        default=datetime.date.today,
        help_text='Formato: dd/mm/aaaa',
        verbose_name='Fecha venta')
    rutCliente = models.CharField(max_length=10)
    nombreCliente = models.CharField(max_length=50)
    tipoDocumento = models.ForeignKey(
        TipoDocumento, on_delete=models.SET_NULL, null=True, help_text='Seleccione un tipo  de documento')
    formaPago = models.ForeignKey(
        FormaPago, on_delete=models.SET_NULL, null=True, help_text='Seleccione una forma de pago')

    def get_absolute_url(self):
        return reverse('verVenta', args=[self.id])

    def get_update_url(self):
        return reverse('editarVenta', args=[self.id])

    def get_delete_url(self):
        return reverse('eliminarVenta', args=[self.id])

    def __str__(self):
        return self.fechaVenta + ' ' + self.nombreCliente

    class meta:
        ordering = ['fechaVenta']


class DatosFacturacion(models.Model):
    razonSocial = models.CharField(max_length=100)
    rut = models.CharField(max_length=10)
    direccion = models.CharField(max_length=100)
    giro = models.CharField(max_length=50)
    contacto = models.CharField(max_length=50)
    ciudad = models.CharField(max_length=50)

    def __str__(self):
        return self.razonSocial + ' ' + self.rut

    class meta:
        ordering = ['razonSocial']


# DetalleVenta:
# Clase para el detalle de la venta.
class DetalleVenta(models.Model):
    venta = models.ForeignKey(Venta, on_delete=models.CASCADE)
    libro = models.ForeignKey(Libro, on_delete=models.CASCADE)
    cantidad = models.PositiveIntegerField(
        default=0, verbose_name='Cantidad',
        validators=[MinValueValidator(0), MaxValueValidator(999)])
    precio = models.PositiveIntegerField(
        default=0, verbose_name='Precio',
        validators=[MinValueValidator(0), MaxValueValidator(9999999)])

    def __str__(self):
        return self.id

    class meta:
        ordering = ['id']

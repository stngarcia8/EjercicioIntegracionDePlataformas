from django.db import models
from django.urls import reverse


# Sucursal
# Clase que define una sucursal.
class Sucursal(models.Model):
    nombre = models.CharField(max_length=30)
    encargado = models.CharField(max_length=50)
    direccion = models.CharField(max_length=100, verbose_name='Dirección')
    habilitado = models.BooleanField(default=True)

    class meta:
        ordering = ('nombre',)

    def get_absolute_url(self):
        return reverse('verSucursal', args=[self.id])

    def get_update_url(self):
        return reverse('editarSucursal', args=[self.id])

    def get_delete_url(self):
        return reverse('eliminarSucursal', args=[self.id])

    def __str__(self):
        return self.nombre

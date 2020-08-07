from django.db import models
from django.urls import reverse


# Autor
# Clase que define un autor.
class Autor(models.Model):
    nombre = models.CharField(max_length=30)
    apellidos = models.CharField(max_length=30)
    descripcion = models.TextField(
        verbose_name='Reseña', null=True, blank=True, max_length=100)
    habilitado = models.BooleanField(default=True)

    @property
    def nombre_completo(self):
        return self.nombre + ' ' + self.apellidos

    class meta:
        ordering = ('nombre', 'apellidos',)

    def get_absolute_url(self):
        return reverse('verAutor', args=[self.id])

    def get_update_url(self):
        return reverse('editarAutor', args=[self.id])

    def get_delete_url(self):
        return reverse('eliminarAutor', args=[self.id])

    def __str__(self):
        return self.nombre + ' ' + self.apellidos

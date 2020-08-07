from django.db import models
from django.urls import reverse


# Categoria
# Clase que define una categoria de libros.
class Categoria(models.Model):
    nombre = models.CharField(max_length=50)
    habilitado = models.BooleanField(default=True)

    class Meta:
        ordering = ('nombre',)

    def get_absolute_url(self):
        return reverse('verCategoria', args=[self.id])

    def get_update_url(self):
        return reverse('editarCategoria', args=[self.id])

    def get_delete_url(self):
        return reverse('eliminarCategoria', args=[self.id])

    def __str__(self):
        return self.nombre

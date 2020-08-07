from django.db import models
from django.urls import reverse


# Editorial
# Clase que define una editorial de libros.
class Editorial(models.Model):
    nombre = models.CharField(max_length=50)
    habilitado = models.BooleanField(default=True)

    class Meta:
        ordering = ('nombre',)

    def get_absolute_url(self):
        return reverse('verEditorial', args=[self.id])

    def get_update_url(self):
        return reverse('editarEditorial', args=[self.id])

    def get_delete_url(self):
        return reverse('eliminarEditorial', args=[self.id])

    def __str__(self):
        return self.nombre

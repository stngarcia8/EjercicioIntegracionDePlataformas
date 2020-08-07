from django.db import models


# Estado
# Clase que define un estado de un ejemplar.
class Estado(models.Model):
    nombre = models.CharField(max_length=50)

    class Meta:
        ordering = ('nombre',)

    def __str__(self):
        return self.nombre

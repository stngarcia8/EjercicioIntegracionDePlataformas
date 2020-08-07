from django.db import models


# Idioma
# Clase que define un idioma.
class Idioma(models.Model):
    nombre = models.CharField(max_length=50)
    iso_code = models.CharField(max_length=5)

    class Meta:
        ordering = ('nombre',)

    def __str__(self):
        return self.nombre + ' (' + self.iso_code + ')'

from django.contrib.auth.models import User
from gesbod.aplicacion.models.autor import Autor
from django.core.management.base import BaseCommand


class Command(BaseCommand):
    help = 'Crear usuarios para gesbod'

    def handle(self, *args, **kwargs):
        User.objects.create_user(first_name='Daniel', last_name='Garcia Asathor',
                                 username='d.garcia', email='stngarcia8@gmail.com', password='libros_user')
        User.objects.create_user(first_name='Elias', last_name='Garcia Carvajal',
                                 username='e.garcia', email='elias@gmail.com', password='libros_user')
        User.objects.create_user(first_name='Hector', last_name='Celis Villarroel',
                                 username='h.celis', email='hector@gmail.com', password='libros_user')
        User.objects.create_user(first_name='Pedro', last_name='Briceño Donoso',
                                 username='p.briceno', email='pedro@gmail.com', password='libros_user')
        User.objects.create_user(first_name='Ignacio', last_name='Salazar Garcia',
                                 username='i.salazar', email='ignacio@gmail.com', password='libros_user')
        print('Usuarios creados.')

        Autor()

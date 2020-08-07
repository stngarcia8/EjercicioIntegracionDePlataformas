from django.contrib.auth.models import User
from gesbod.aplicacion.models.autor import Autor
from gesbod.aplicacion.models.categoria import Categoria
from gesbod.aplicacion.models.editorial import Editorial
from gesbod.aplicacion.models.idioma import Idioma
from gesbod.aplicacion.models.estado import Estado
from gesbod.aplicacion.models.sucursal import Sucursal
from django.core.management.base import BaseCommand


class Command(BaseCommand):
    help = 'Ingresa valores de prueba para gesbod.'

    def handle(self, *args, **kwargs):
        self.crearUsuarios()
        self.crearAutores()
        self.crearCategorias()
        self.crearEditoriales()
        self.crearIdiomas()
        self.crearSucursales()
        self.crearEstados()
        print('Base de datos poblada para pruebas!')

    # crearUsuarios()
    # Metodo para crear los usuarios de ejemplo.
    def crearUsuarios(self):
        print('Creando usuarios...')
        User.objects.create_superuser(first_name='Daniel', last_name='Garcia Asathor',
                                      username='admin', email='stngarcia8@gmail.com', password='libros_admin')
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

    # crearAutores()
    # Metodo para crear autores de ejemplo.

    def crearAutores(self):
        print('Creando autores...')
        myAutor = Autor(nombre='Joe', apellidos='Abercrombie',
                        descripcion='', habilitado=True)
        myAutor.save()
        myAutor = Autor(nombre='Dan', apellidos='Abnett',
                        descripcion='', habilitado=True)
        myAutor.save()
        myAutor = Autor(nombre='Graham', apellidos='McNeill',
                        descripcion='', habilitado=True)
        myAutor.save()

    # crearCategorias()
    # Metodo para crear las categorias de ejemplo.
    def crearCategorias(self):
        print('Creando categorias...')
        myCategoria = Categoria(nombre='Ciencia ficción', habilitado=True)
        myCategoria.save()
        myCategoria = Categoria(nombre='Fantasía', habilitado=True)
        myCategoria.save()
        myCategoria = Categoria(nombre='Terror', habilitado=True)
        myCategoria.save()

    # crearEditoriales()
    # Metodo para crear editoriales de ejemplo.
    def crearEditoriales(self):
        print('Creando editoriales...')
        myEditorial = Editorial(nombre='Prentice Hall', habilitado=True)
        myEditorial.save()
        myEditorial = Editorial(nombre='Minotauro', habilitado=True)
        myEditorial.save()
        myEditorial = Editorial(nombre='Black library', habilitado=True)
        myEditorial.save()

    # crearIdiomas()
    # Metodo para crear idiomas de ejemplo.
    def crearIdiomas(self):
        print('Creando idiomas...')
        myIdioma = Idioma(nombre='Inglés', iso_code='en-us')
        myIdioma.save()
        myIdioma = Idioma(nombre='Español', iso_code='es-es')
        myIdioma.save()

    # crearSucursales()
    # Metodo para crear las sucursales de ejemplo.
    def crearSucursales(self):
        print('Creando sucursales...')
        mySucursal = Sucursal(nombre='Sucursal Plaza Norte', encargado='Ernesto mado',
                              direccion='Plaza norte 1456', habilitado=True)
        mySucursal.save()
        mySucursal = Sucursal(nombre='Sucursal Plaza oeste', encargado='Ana Lisa Melano',
                              direccion='Plaza oeste 6541', habilitado=True)
        mySucursal.save()

    # crearEstados()
    # Metodo para crear los estados de los libros.
    def crearEstados(self):
        print('Creando estados...')
        myEstado = Estado(nombre='Disponible')
        myEstado.save()
        myEstado = Estado(nombre='Destinado')
        myEstado.save()
        myEstado = Estado(nombre='Reservado')
        myEstado.save()

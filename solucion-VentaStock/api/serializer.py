from rest_framework import serializers
from .models import Usuario, TipoUs, Sucursal, Autor, Libro


# TipoUsuarioSerializer
# Serializador de los tipos de usuario.
class TipoUsSerializer(serializers.ModelSerializer):
    class Meta:
        model = TipoUs
        fields = ('__all__')


# SucursalSerializer:
# Serializador para las sucursales.
class SucursalSerializer(serializers.ModelSerializer):
    class Meta:
        model = Sucursal
        fields = ('__all__')


# UsuarioSerializer:
# Serializador de los usuarios.
class UsuarioSerializer(serializers.ModelSerializer):
    class Meta:
        model = Usuario
        fields = ('idUsuario', 'tipoUs', 'sucursal', 'nombreUsuario', 'rutUsuario', 'contrasenaUsuario')


# AutorSerializer:
# Serializador de los autores.
class AutorSerializer(serializers.ModelSerializer):
    class Meta:
        model = Autor
        fields = ('__all__')


# LibroSerializer:
# Serializador para los libros.
class LibroSerializer(serializers.ModelSerializer):
    class Meta:
        model = Libro
        fields = ('__all__')

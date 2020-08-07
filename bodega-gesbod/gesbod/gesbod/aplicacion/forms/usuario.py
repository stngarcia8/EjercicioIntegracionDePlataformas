from django.contrib.auth.forms import UserCreationForm
from django.contrib.auth.models import User


# UsuarioForm
# Formulario de usuarios.
class UsuarioForm(UserCreationForm):
    class Meta:
        model = User
        fields = ('first_name', 'last_name', 'email',
                  'is_superuser', 'is_active', 'username')

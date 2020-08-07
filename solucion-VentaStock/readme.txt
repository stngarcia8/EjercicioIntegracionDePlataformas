Preparación del ambiente para ventastock:
a. Opcional, actualizar gestores de paquetes y librerias base del entorno.
actualizar conda:
conda update conda --yes

actualizar pip:
python -m pip install --upgrade pip


Cargar librerias base (autopep y flake8)
cargar linters y formateadores.
pip install -r base-requirements.txt


b. crear el ambiente virtual.
conda create --name ventastock python=3.7 --yes

c. activar el ambiente virtual.
conda activate ventastock

d. Cargar las librerías necesarias, se debe estar dentro del ambiente virtual.
pip install -r requirements.txt

e. desactivar el ambiente virtual.
conda deactivate

f. Eliminar el ambiente virtual, primero debe desactivar el ambiente virtual antes de eliminarlo.
conda remove --yes --name ventastock --all


Notas de ejecucion:
prerequisito: tener los servicios web ejecutandose.

en la carpeta donde reside el archivo manage.py ejecutar los siguientes comandos, estando dentro del ambiente virtual si es que lo tiene.
- python manage.py makemigrations
python manage.py migrate
python manage.py poblarbase
python manage.py runserver

2. abrir un navegador y colocar lo siguiente en la barra de direcciones:
localhost:8000

el usuario es: 12345678-9
contraseña: 123456
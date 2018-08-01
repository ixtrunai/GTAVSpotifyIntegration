# GTAVSpotifyIntegration

Para usar este mod necesitas tener instalados (instrucciones de instalación en sus páginas):
1. [ScriptHookV](https://es.gta5-mods.com/tools/script-hook-v)
2. [ScriptHookV.Net](https://es.gta5-mods.com/tools/scripthookv-net)

Para instalar el mod, descarga el [GTAVSpotifyIntegration.dll](https://github.com/ixtrunai/GTAVSpotifyIntegration/raw/master/SpotifyIntegrationMod.dll) y metélo en la carpeta scripts, dentro de la carpeta del juego (si este es tu primer mod es probable que no la tengas, en ese caso creala).
Ejemplo de ruta correcta: D:\SteamLibrary\steamapps\common\Grand Theft Auto V\scripts\GTAVSpotifyIntegration.dll

### Notas de uso:
1. Asegúrate de que la reproducción está en pausa antes de entrar en un coche (si no lo haces, conseguirás el efecto contrario, al entrar parará spotify y al salir reproducirá canciones)
2. Requiere de conexión a internet para funcionar.


### Lo que hace el mod:
Al iniciar el singleplayer, ejecutará spotify si no está abierto (de todas formas, se recomienda tenerlo abierto antes).
Al entrar en un vehiculo, empezará a reproducir una canción.
Al salir de un vehiculo, parará la reproducción.
En caso de que haya una llamada teléfonica o conversación, se bajará el volumen de spotify un 40% y volverá a su estado original al finalizar la conversación/llamada.
NOTA: las radios no se podrán activar mientras el mod esté instalado (se pondrá en Radio Off automáticamente). Posiblemente haga modificaciones futuras respecto a esto.

### Lo que no hace el mod:
No saldrá la canción que se está reproduciendo en ninguna parte.
No permite cambiar canciones desde el juego.
No permite cambiar playlists desde el juego.
No silencia la música de misiones. Si estás en una misión y sale música ambiental, esta no se silencia. Para esto desactiva la música del juego desde el menú de opciones.

### Librerías utilizadas durante el desarrollo:
* [ScriptHookV.Net](https://es.gta5-mods.com/tools/scripthookv-net)  (requerida)
* [SpotifyAPI-NET](https://github.com/JohnnyCrazy/SpotifyAPI-NET) (incluida con el dll del mod, no hace falta descargarla.)

Otras:
* [NativeUI](https://github.com/Guad/NativeUI/releases): solo usada para mostrar información durante el desarrollo del mod. No se hace uso de ella en el mod y no es necesario instalarla para que el mod funcione.



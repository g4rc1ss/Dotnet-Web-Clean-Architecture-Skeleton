# Nombre

## Descripción
---
Skeleton de una Clean Architecture en .net
- Esta aplicacion se compone de una base de datos Mongodb para las operaciones CRUD
- Esta implementada mediante el patron CQRS, considero que mejora la legibilidad del codigo y permite tener mas definido el principio de responsabilidad unica
- La aplicacion esta configurada con OpenTelemetry para la recoleccion de metricas(uso de cpu, ram, request, etc.), traces(diferentes llamadas que va ejecutando el codigo) y logs(registros para almacenar errores, etc.)
    - Las librerias que se usan para todo esto son Prometheus(bbdd), Grafana(visualizador de metrics), Zipkin(trace) y Seq(logs)
 	
## Guía de instalación
---

Para ejecutar la aplicacion en un entorno localhost utilizamos el script en powershell
```powershell
./docker-compose.ps1 up local
```

Si queremos ejecutar el docker en un entorno dev, stagging o pro en un servidor que no es localhost, tendremos que crear las variables de entorno que hay en el archivo .env en el servidor VPS o cloud correspondiente
```powershell
./docker-compose.ps1 up dev
./docker-compose.ps1 up stagging
./docker-compose.ps1 up pro
```

Si queremos desmontar o eliminar los contenedores ejecutaremos el comando
```powershell
./docker-compose.ps1 down local
```
El comando con el parametro `down` solamente elimina los contenedores, pero este docker-compose contiene volumenes persistentes, si quieres eliminarlos se usa junto al parametro `v``

```powershell
./docker-compose.ps1 down local v
```
> Hay que tener en cuenta que con el parametro `v`se eliminan todos los volumenes persistentes, no es recomendable usarlo en despliegue, sobretodo en produccion.



## Autor/es
---
- [Asier García](https://github.com/g4rc1ss)


## Descripción
---
Skeleton de una Clean Architecture en .net
- Esta aplicacion se compone de una base de datos Mongodb para las operaciones CRUD
- Esta implementada mediante el patron CQRS, considero que mejora la legibilidad del codigo y permite tener mas definido el principio de responsabilidad unica
- La aplicacion esta configurada con OpenTelemetry para la recoleccion de metricas(uso de cpu, ram, request, etc.), traces(diferentes llamadas que va ejecutando el codigo) y logs(registros para almacenar errores, etc.)
    - Las librerias que se usan para todo esto son Prometheus(bbdd), Grafana(visualizador de metrics), Zipkin(trace) y Seq(logs)

![image](https://github.com/user-attachments/assets/67b58a75-81b1-4125-868d-2661ddf326c0)

## Guía de instalación
---

Para ejecutar la aplicacion en un entorno localhost utilizamos el script en powershell
```powershell
./docker-compose.ps1 up local
```

Si queremos desmontar los contenedores ejecutaremos el comando
```powershell
./docker-compose.ps1 down local
```
El comando con el parametro `down` solamente elimina los contenedores, pero este docker-compose contiene volumenes persistentes, si quieres eliminarlos se usa junto al parametro `v`

```powershell
./docker-compose.ps1 down local v
```
> Hay que tener en cuenta que con el parametro `v`se eliminan todos los volumenes persistentes, no es recomendable usarlo en despliegues, sobretodo en produccion.

## Continous Integration
[![.NET_CI](https://github.com/g4rc1ss/Dotnet-Web-Clean-Architecture-Skeleton/actions/workflows/dotnet.yml/badge.svg)](https://github.com/g4rc1ss/Dotnet-Web-Clean-Architecture-Skeleton/actions/workflows/dotnet.yml)
[![CodeQL](https://github.com/g4rc1ss/Dotnet-Web-Clean-Architecture-Skeleton/actions/workflows/codeql.yml/badge.svg)](https://github.com/g4rc1ss/Dotnet-Web-Clean-Architecture-Skeleton/actions/workflows/codeql.yml)
[![Docker_build](https://github.com/g4rc1ss/Dotnet-Web-Clean-Architecture-Skeleton/actions/workflows/docker-check.yml/badge.svg)](https://github.com/g4rc1ss/Dotnet-Web-Clean-Architecture-Skeleton/actions/workflows/docker-check.yml)

## Continous Delivery
[![Deploy Host Web API](https://github.com/g4rc1ss/Dotnet-Web-Clean-Architecture-Skeleton/actions/workflows/deploy-hostwebapi.yml/badge.svg)](https://github.com/g4rc1ss/Dotnet-Web-Clean-Architecture-Skeleton/actions/workflows/deploy-hostwebapi.yml)
[![Deploy Mongo Database](https://github.com/g4rc1ss/Dotnet-Web-Clean-Architecture-Skeleton/actions/workflows/deploy-mongodb.yml/badge.svg)](https://github.com/g4rc1ss/Dotnet-Web-Clean-Architecture-Skeleton/actions/workflows/deploy-mongodb.yml)
[![Deploy Open Telemetry](https://github.com/g4rc1ss/Dotnet-Web-Clean-Architecture-Skeleton/actions/workflows/deploy-opentelemetry.yml/badge.svg)](https://github.com/g4rc1ss/Dotnet-Web-Clean-Architecture-Skeleton/actions/workflows/deploy-opentelemetry.yml)


## Autor/es
---
- [Asier García](https://github.com/g4rc1ss)



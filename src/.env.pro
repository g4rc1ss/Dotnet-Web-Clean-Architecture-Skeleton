# env de local

# mongo
MONGO_INITDB_ROOT_USERNAME_SKELETON:root
MONGO_INITDB_ROOT_PASSWORD_SKELETON:contraseñafuerteproduccionentorno
MONGO_INITDB_DATABASE_SKELETON: CleanArchitecture

# Grafana 
GF_SECURITY_ADMIN_USER_SKELETON: admin
GF_SECURITY_ADMIN_PASSWORD_SKELETON: adminStrongPasswordProduction
GF_USERS_ALLOW_SIGN_UP_SKELETON: 'false'

# ASP
# Ruta del certificado en nuestra maquina(host, no docker)
ASPNETCORE_Kestrel_Certificate_From_Path_SKELETON: ./cert.pfx
ASPNETCORE_Kestrel__Certificates__Default__Path_SKELETON: /app/cert.pfx
ASPNETCORE_Kestrel__Certificates__Default__Password_SKELETON: password
ASPNETCORE_ENVIRONMENT_SKELETON: Production
ASPNETCORE_URLS_SKELETON: https://+:443;http://+:80
AppName_SKELETON: HostWebApiProduction
keysFolder_SKELETON: /keysFolder
ConnectionStrings__CleanArchitectureSkeletonMongoDb_SKELETON: mongodb://root:contrase%C3%B1afuerteproduccionentorno@localhost:27017/
ConnectionStrings__OpenTelemetry_SKELETON: http://opentelemetry_collector:4317
ConnectionStrings__SeqLogs_SKELETON: http://seq-logs:5341
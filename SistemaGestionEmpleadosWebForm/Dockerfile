# Usar una imagen base con IIS y ASP.NET Framework
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8 AS base
WORKDIR /inetpub/wwwroot

# Copiar los archivos de la aplicación al contenedor
COPY . .

# Exponer el puerto 80 para el servidor IIS
EXPOSE 80
# Crear una imagen con el SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SistemaGestionEmpleadosWebForm.csproj", "./"]
RUN dotnet restore "./SistemaGestionEmpleadosWebForm.csproj"
COPY . .
RUN dotnet publish -c Release -o /app/build

# Imagen final para ejecutar la aplicación
FROM base AS final
WORKDIR /app
COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "SistemaGestionEmpleadosWebForm.dll"]


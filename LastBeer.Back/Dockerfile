# Utilizar la imagen base de .NET 7 SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copiar archivos de proyecto y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto de los archivos y compilar
COPY . ./
RUN dotnet publish -c Release -o out

# Utilizar la imagen base de ASP.NET Core para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .

# Exponer el puerto que utilizará la aplicación
EXPOSE 80

# Definir el comando de inicio de la aplicación
ENTRYPOINT ["dotnet", "lastbeer.dll"]

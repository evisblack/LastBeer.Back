# Utilizar la imagen base de .NET 7 SDK para compilar la aplicaci�n
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copiar archivos de proyecto y restaurar dependencias
COPY LastBeer.Back.csproj ./
RUN dotnet restore

# Copiar el resto de los archivos y compilar
COPY . ./
RUN dotnet publish -c Release -o out

# Utilizar la imagen base de ASP.NET Core para ejecutar la aplicaci�n
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .

# Exponer el puerto que utilizar� la aplicaci�n
EXPOSE 80

# Definir el comando de inicio de la aplicaci�n
ENTRYPOINT ["dotnet", "lastbeer.dll"]



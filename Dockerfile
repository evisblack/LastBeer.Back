# Utiliza una imagen base de .NET 7 SDK para construir la aplicaci�n
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copia el archivo csproj y restaura las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copia el resto de los archivos y compila la aplicaci�n
COPY . ./
RUN dotnet publish -c Release -o out

# Utiliza una imagen base de .NET 7 ASP.NET Core para ejecutar la aplicaci�n
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .

# Exponer el puerto en el que la aplicaci�n correr�
EXPOSE 80

# Define el punto de entrada de la aplicaci�n
ENTRYPOINT ["dotnet", "LastBeer.Back.dll"]

# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar solución y proyectos
COPY ["Practica.csproj", "./"]
RUN dotnet restore "Practica.csproj"

COPY . .
RUN dotnet publish "Practica.csproj" -c Release -o /app/publish

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8081
ENTRYPOINT ["dotnet", "Practica.dll"]

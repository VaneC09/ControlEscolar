# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar toda la solución primero
COPY . ./

# Listar los directorios para depuración
RUN ls -la

# Intentar construir solo el proyecto API
RUN find . -name "API_Estudiantes_Test.csproj" -exec dotnet publish {} -c Release -o /app/out \;

# Si lo anterior falla, intentar buscar la API por nombre
RUN if [ ! -d /app/out ]; then \
    find . -name "*.csproj" | grep -i api | xargs -I {} dotnet publish {} -c Release -o /app/out; \
    fi

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 80
EXPOSE 443

# Verificar DLL de la API (opcional)
RUN find . -name "*.dll" | grep -i api

# Ejecutar directamente el DLL de la API
ENTRYPOINT ["dotnet", "API_Estudiantes_Test.dll"]

# 1) Build con SDK 9.0
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# — instala clang y zlib1g-dev si vas a publicar nativo (AOT)—
RUN apt-get update \
 && apt-get install -y --no-install-recommends \
    clang \
    zlib1g-dev
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
# Copia y restaura tu .csproj
COPY ["Frock-backend/Frock-backend.csproj", "Frock-backend/"]
RUN dotnet restore "Frock-backend/Frock-backend.csproj"

# Copia todo y compila
COPY . .
WORKDIR "/src/Frock-backend"
RUN dotnet build "Frock-backend.csproj" \
    -c $BUILD_CONFIGURATION \
    -o /app/build

# 2) Publica (ajusta /p:UseAOT si quieres AOT; por defecto dejamos APP HOST)
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Frock-backend.csproj" \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \
    /p:UseAppHost=true

# 3) Imagen de runtime ligera
FROM mcr.microsoft.com/dotnet/runtime-deps:9.0 AS final
WORKDIR /app

# Que Kestrel escuche en 0.0.0.0:8080
#ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=publish /app/publish .

ENTRYPOINT ["./Frock-backend"]

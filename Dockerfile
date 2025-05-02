FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app


COPY . ./


RUN dotnet restore AdopcionMascotas.csproj
RUN dotnet publish AdopcionMascotas.csproj -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
git add Dockerfile
git commit -m "Agrego Dockerfile para despliegue en Render"
git push origin deploy/render

ENTRYPOINT ["dotnet", "AdopcionMascotas.dll"]
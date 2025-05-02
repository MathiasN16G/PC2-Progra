
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app


COPY . ./


RUN dotnet restore AdopcionMascotas.csproj
RUN dotnet publish AdopcionMascotas.csproj -c Release -o /app/out


FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./


ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "AdopcionMascotas.dll"]

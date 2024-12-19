# Stagiul 1: Construirea aplicației
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app

# Stagiul 2: Rularea aplicației
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
COPY isticketing.db /app/isticketing.db
EXPOSE 5050
ENTRYPOINT ["dotnet", "TSIS.dll"]

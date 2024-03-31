#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#When running the container, this connString is used in Startup.cs. The placeholder for Password (ENVPW), is replaced with the value from an
#environment variable named DB_PW, which is defined in the docker-compose file. The value comes from the .env file.
ENV ConnectionStrings:CleanCommanderConnectionString="Server=ms-sql-server;Database=CleanCommanderDb;User=sa;Password=ENVPW;integrated security=false"

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY ["src/API/CleanCommander.Api/CleanCommander.Api.csproj", "app/API/CleanCommander.Api/"]
COPY ["src/Core/CleanCommander.Application/CleanCommander.Application.csproj", "app/Core/CleanCommander.Application/"]
COPY ["src/Core/CleanCommander.Domain/CleanCommander.Domain.csproj", "app/Core/CleanCommander.Domain/"]
COPY ["src/Infrastructure/CleanCommander.Infrastructure/CleanCommander.Infrastructure.Identity.csproj", "app/Infrastructure/CleanCommander.Infrastructure/"]
COPY ["src/Infrastructure/CleanCommander.Persistence/CleanCommander.Persistence.csproj", "app/Infrastructure/CleanCommander.Persistence/"]
RUN dotnet restore "app/API/CleanCommander.Api/CleanCommander.Api.csproj"
COPY . .
WORKDIR "/app/src/API/CleanCommander.Api"
RUN dotnet build "CleanCommander.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanCommander.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanCommander.Api.dll"]
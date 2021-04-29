#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/CarPark.UserApi/CarPark.UserApi.csproj", "src/CarPark.UserApi/"]
COPY ["src/CarPark.EntitiesDto/CarPark.EntitiesDto.csproj", "src/CarPark.EntitiesDto/"]
COPY ["src/CarPark.LoggerService/CarPark.LoggerService.csproj", "src/CarPark.LoggerService/"]
COPY ["src/CarPark.Contracts/CarPark.Contracts.csproj", "src/CarPark.Contracts/"]
COPY ["src/CarPark.Entities/CarPark.Entities.csproj", "src/CarPark.Entities/"]
RUN dotnet restore "src/CarPark.UserApi/CarPark.UserApi.csproj"
COPY . .
WORKDIR "/src/src/CarPark.UserApi"
RUN dotnet build "CarPark.UserApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarPark.UserApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarPark.UserApi.dll"]
#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
RUN apt-get update && apt-get install -y libgssapi-krb5-2
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ShopeeKorean/ShopeeKorean.Application.csproj", "ShopeeKorean/"]
COPY ["LoggerService/ShopeeKorean.LoggerService.csproj", "LoggerService/"]
COPY ["Contracts/ShopeeKorean.Repository.Contracts.csproj", "Contracts/"]
COPY ["Repository/ShopeeKorean.Repository.csproj", "Repository/"]
COPY ["Entities/ShopeeKorean.Entities.csproj", "Entities/"]
COPY ["ShopeeKorean.Shared/ShopeeKorean.Shared.csproj", "ShopeeKorean.Shared/"]
COPY ["ShopeeKorean.Presentation/ShopeeKorean.Presentation.csproj", "ShopeeKorean.Presentation/"]
COPY ["ShopeeKorean.Services/ShopeeKorean.Service.csproj", "ShopeeKorean.Services/"]
COPY ["ShopeeKorean.Service.Contracts/ShopeeKorean.Service.Contracts.csproj", "ShopeeKorean.Service.Contracts/"]
RUN dotnet restore "./ShopeeKorean/ShopeeKorean.Application.csproj"
COPY . .
WORKDIR "/src/ShopeeKorean"
RUN dotnet build "./ShopeeKorean.Application.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ShopeeKorean.Application.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopeeKorean.Application.dll"]
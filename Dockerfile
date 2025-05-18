# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution file và các file .csproj trước
COPY *.sln .
COPY ShopeeKorean/*.csproj ./ShopeeKorean/
COPY Contracts/*.csproj ./Contracts/
COPY Entities/*.csproj ./Entities/
COPY Repository/*.csproj ./Repository/

# Restore dependencies
RUN dotnet restore "ShopeeKorean.sln"

# Copy toàn bộ source code
COPY . .

# Build và publish
WORKDIR /src/ShopeeKorean
RUN dotnet publish -c Release -o /app

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "ShopeeKorean.dll"]

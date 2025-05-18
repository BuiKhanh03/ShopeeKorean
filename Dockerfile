# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY *.sln .
COPY *.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish "ShopeeKorean.csproj" -c Release -o /app

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
HEALTHCHECK --interval=30s --timeout=3s \
  CMD curl -f http://localhost/health || exit 1
ENTRYPOINT ["dotnet", "ShopeeKorean.dll"]

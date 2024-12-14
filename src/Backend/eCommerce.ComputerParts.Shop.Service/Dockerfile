# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Backend/eCommerce.ComputerParts.Shop.Service/eCommerce.ComputerParts.Shop.Service.csproj", "Backend/eCommerce.ComputerParts.Shop.Service/"]
COPY ["common/eCommerce.ComputerParts.Shop.Infrastructure/eCommerce.ComputerParts.Shop.Infrastructure.csproj", "common/eCommerce.ComputerParts.Shop.Infrastructure/"]
COPY ["common/eCommerce.ComputerParts.Shop.Core/eCommerce.ComputerParts.Shop.Core.csproj", "common/eCommerce.ComputerParts.Shop.Core/"]
COPY ["Common/eCommerce.ComputerParts.Shop.Shared/eCommerce.ComputerParts.Shop.Shared.csproj", "Common/eCommerce.ComputerParts.Shop.Shared/"]
COPY ["Data/eCommerce.ComputerParts.Shop.Catalog/eCommerce.ComputerParts.Shop.Catalog.csproj", "Data/eCommerce.ComputerParts.Shop.Catalog/"]
COPY ["Data/eCommerce.ComputerParts.Shop.Identity/eCommerce.ComputerParts.Shop.Identity.csproj", "Data/eCommerce.ComputerParts.Shop.Identity/"]
RUN dotnet restore "./Backend/eCommerce.ComputerParts.Shop.Service/eCommerce.ComputerParts.Shop.Service.csproj"
COPY . .
WORKDIR "/src/Backend/eCommerce.ComputerParts.Shop.Service"
RUN dotnet build "./eCommerce.ComputerParts.Shop.Service.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./eCommerce.ComputerParts.Shop.Service.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eCommerce.ComputerParts.Shop.Service.dll"]
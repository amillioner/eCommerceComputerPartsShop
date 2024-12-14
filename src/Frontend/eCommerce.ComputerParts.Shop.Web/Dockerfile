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
COPY ["Directory.Packages.props", "."]
COPY ["src/eCommerce.ComputerParts.Shop.Web/eCommerce.ComputerParts.Shop.Web.csproj", "src/eCommerce.ComputerParts.Shop.Web/"]
COPY ["src/eCommerce.ComputerParts.Shop.Data/eCommerce.ComputerParts.Shop.Data.csproj", "src/eCommerce.ComputerParts.Shop.Data/"]
COPY ["src/eCommerce.ComputerParts.Shop.Core/eCommerce.ComputerParts.Shop.Core.csproj", "src/eCommerce.ComputerParts.Shop.Core/"]
COPY ["src/eCommerce.ComputerParts.Shop.Identity/eCommerce.ComputerParts.Shop.Identity.csproj", "src/eCommerce.ComputerParts.Shop.Identity/"]
COPY ["src/eCommerce.ComputerParts.Shop.Web.Shared/eCommerce.ComputerParts.Shop.Web.Shared.csproj", "src/eCommerce.ComputerParts.Shop.Web.Shared/"]
COPY ["src/eCommerce.ComputerParts.Shop.Infrastructure/eCommerce.ComputerParts.Shop.Infrastructure.csproj", "src/eCommerce.ComputerParts.Shop.Infrastructure/"]
COPY ["src/eCommerce.ComputerParts.Shop.Web.Admin/eCommerce.ComputerParts.Shop.Web.Admin.csproj", "src/eCommerce.ComputerParts.Shop.Web.Admin/"]
RUN dotnet restore "./src/eCommerce.ComputerParts.Shop.Web/eCommerce.ComputerParts.Shop.Web.csproj"
COPY . .
WORKDIR "/src/src/eCommerce.ComputerParts.Shop.Web"
RUN dotnet build "./eCommerce.ComputerParts.Shop.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./eCommerce.ComputerParts.Shop.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eCommerce.ComputerParts.Shop.Web.dll"]
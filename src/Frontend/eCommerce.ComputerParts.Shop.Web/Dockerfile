# RUN ALL CONTAINERS FROM ROOT (folder with .sln file):
# docker-compose build
# docker-compose up
#
# RUN JUST THIS CONTAINER FROM ROOT (folder with .sln file):
# docker build --pull -t web -f src/Web/Dockerfile .
# docker build --pull -t web -f src/Frontend/eCommerce.ComputerParts.Shop.Web/Dockerfile .
# docker build --pull -t api -f src/Backend/eCommerce.ComputerParts.Shop.Service/Dockerfile .
#
# RUN COMMAND
#  docker run --name eshopweb --rm -it -p 5106:5106 web
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY . .

WORKDIR /app/src/Frontend/eCommerce.ComputerParts.Shop.Web

RUN dotnet restore

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/src/Frontend/eCommerce.ComputerParts.Shop.Web/out ./

# Optional: Set this here if not setting it from docker-compose.yml
# ENV ASPNETCORE_ENVIRONMENT Developmentx
ENTRYPOINT ["dotnet", "eCommerce.ComputerParts.Shop.Web.dll"]


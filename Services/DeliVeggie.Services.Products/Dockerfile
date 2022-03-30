FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["DeliVeggie.Services.Products.csproj", "./"]

RUN dotnet restore "./DeliVeggie.Services.Products.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DeliVeggie.Services.Products.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DeliVeggie.Services.Products.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeliVeggie.Services.Products.dll"]
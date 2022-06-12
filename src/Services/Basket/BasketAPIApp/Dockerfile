#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Basket/BasketAPIApp/BasketAPIApp.csproj", "Services/Basket/BasketAPIApp/"]
RUN dotnet restore "Services/Basket/BasketAPIApp/BasketAPIApp.csproj"
COPY . .
WORKDIR "/src/Services/Basket/BasketAPIApp"
RUN dotnet build "BasketAPIApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasketAPIApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasketAPIApp.dll"]

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Ordering/Ordering/OrderingAPIApp.csproj", "Services/Ordering/Ordering/"]
COPY ["Services/Ordering/OrderingApplication/OrderingApplication.csproj", "Services/Ordering/OrderingApplication/"]
COPY ["Services/Ordering/OrderingDomain/OrderingDomain.csproj", "Services/Ordering/OrderingDomain/"]
COPY ["Services/Ordering/OrderingInfrastructure/OrderingInfrastructure.csproj", "Services/Ordering/OrderingInfrastructure/"]
RUN dotnet restore "Services/Ordering/Ordering/OrderingAPIApp.csproj"
COPY . .
WORKDIR "/src/Services/Ordering/Ordering"
RUN dotnet build "OrderingAPIApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderingAPIApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderingAPIApp.dll"]

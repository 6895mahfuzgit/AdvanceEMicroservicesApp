#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Discount/DiscountAPIApp/DiscountAPIApp.csproj", "Discount/DiscountAPIApp/"]
RUN dotnet restore "Discount/DiscountAPIApp/DiscountAPIApp.csproj"
COPY . .
WORKDIR "/src/Discount/DiscountAPIApp"
RUN dotnet build "DiscountAPIApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DiscountAPIApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DiscountAPIApp.dll"]

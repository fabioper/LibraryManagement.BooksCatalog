FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BooksCatalog.API/BooksCatalog.API.csproj", "BooksCatalog.API/"]
RUN dotnet restore "BooksCatalog.API/BooksCatalog.API.csproj"
COPY . .
WORKDIR "/src/BooksCatalog.API"
RUN dotnet build "BooksCatalog.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BooksCatalog.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BooksCatalog.API.dll"]

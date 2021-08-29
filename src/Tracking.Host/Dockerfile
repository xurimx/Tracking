#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/Tracking.Host/Tracking.Host.csproj", "src/Tracking.Host/"]
RUN dotnet restore "src/Tracking.Host/Tracking.Host.csproj"
COPY . .
WORKDIR "/src/src/Tracking.Host"
RUN dotnet build "Tracking.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tracking.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tracking.Host.dll"]
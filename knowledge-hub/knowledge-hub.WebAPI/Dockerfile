#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["knowledge-hub.WebAPI/knowledge-hub.WebAPI.csproj", "knowledge-hub.WebAPI/"]
RUN dotnet restore "knowledge-hub.WebAPI/knowledge-hub.WebAPI.csproj"
COPY . .
WORKDIR "/src/knowledge-hub.WebAPI"
RUN dotnet build "knowledge-hub.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "knowledge-hub.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "knowledge-hub.WebAPI.dll"]
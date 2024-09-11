FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["2-PersonRestAPI/2-PersonRestAPI.csproj", "2-PersonRestAPI/"]
RUN dotnet restore "2-PersonRestAPI/2-PersonRestAPI.csproj"
COPY . .
WORKDIR "/src/2-PersonRestAPI"
RUN dotnet build "2-PersonRestAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "2-PersonRestAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "2-PersonRestAPI.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Sajan.Abpvue/Sajan.Abpvue.csproj", "Sajan.Abpvue/"]
RUN dotnet restore "Sajan.Abpvue/Sajan.Abpvue.csproj"
COPY . .
WORKDIR "/src/Sajan.Abpvue"
RUN dotnet build "Sajan.Abpvue.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Sajan.Abpvue.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

# ✅ Adding the certificate securely
COPY --from=publish /app/publish .
COPY ./Sajan.Abpvue/openiddict.pfx /app/openiddict.pfx

ENTRYPOINT ["dotnet", "Sajan.Abpvue.dll"]

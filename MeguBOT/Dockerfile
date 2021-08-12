FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app
FROM mcr.microsoft.com/dotnet/nightly/sdk:5.0 AS build
WORKDIR /src
COPY ["MeguBOT.csproj", ""]
RUN dotnet restore "./MeguBOT.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MeguBOT.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "MeguBOT.csproj" -c Release -o /app/publish
FROM base AS final
RUN sed -i 's/main/main contrib/g' /etc/apt/sources.list
RUN apt-get update
WORKDIR /app
COPY "config.json" /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet",  "MeguBOT.dll"]

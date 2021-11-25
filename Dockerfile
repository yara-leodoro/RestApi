FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["RestApi.csproj", "./"]
RUN dotnet restore "RestApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "RestApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RestApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RestApi.dll"]

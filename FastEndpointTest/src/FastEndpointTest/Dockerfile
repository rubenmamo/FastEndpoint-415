FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/FastEndpointTest/FastEndpointTest.csproj", "FastEndpointTest/"]
RUN dotnet restore "src/FastEndpointTest/FastEndpointTest.csproj"
COPY . .
WORKDIR "/src/FastEndpointTest"
RUN dotnet build "FastEndpointTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FastEndpointTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FastEndpointTest.dll"]

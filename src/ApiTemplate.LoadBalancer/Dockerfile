FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /
COPY ["src/ApiTemplate.LoadBalancer/ApiTemplate.LoadBalancer.csproj", "src/ApiTemplate.LoadBalancer/"]
RUN dotnet restore "src/ApiTemplate.LoadBalancer/ApiTemplate.LoadBalancer.csproj"
COPY . .
WORKDIR "/src/ApiTemplate.LoadBalancer"
RUN dotnet build "ApiTemplate.LoadBalancer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiTemplate.LoadBalancer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiTemplate.LoadBalancer.dll"]

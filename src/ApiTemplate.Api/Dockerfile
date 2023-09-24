FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/ApiTemplate.Api/ApiTemplate.Api.csproj", "src/ApiTemplate.Api/"]
COPY ["src/ApiTemplate.Domain/ApiTemplate.Domain.csproj", "src/ApiTemplate.Domain/"]
COPY ["src/ApiTemplate.Application/ApiTemplate.Application.csproj", "src/ApiTemplate.Application/"]
COPY ["src/ApiTemplate.Contracts/ApiTemplate.Contracts.csproj", "src/ApiTemplate.Contracts/"]
COPY ["src/ApiTemplate.Infrastructure/ApiTemplate.Infrastructure.csproj", "src/ApiTemplate.Infrastructure/"]
RUN dotnet restore "src/ApiTemplate.Api/ApiTemplate.Api.csproj"
COPY . .
WORKDIR "/src/src/ApiTemplate.Api"
RUN dotnet build "ApiTemplate.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiTemplate.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiTemplate.Api.dll"]

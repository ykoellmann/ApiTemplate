FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ApiTemplate.Api/ApiTemplate.Api.csproj", "ApiTemplate.Api/"]
COPY ["ApiTemplate.Application/ApiTemplate.Application.csproj", "ApiTemplate.Application/"]
COPY ["ApiTemplate.Domain/ApiTemplate.Domain.csproj", "ApiTemplate.Domain/"]
COPY ["ApiTemplate.Contracts/ApiTemplate.Contracts.csproj", "ApiTemplate.Contracts/"]
COPY ["ApiTemplate.Infrastructure/ApiTemplate.Infrastructure.csproj", "ApiTemplate.Infrastructure/"]
RUN dotnet restore "ApiTemplate.Api/ApiTemplate.Api.csproj"
COPY . .
WORKDIR "/src/ApiTemplate.Api"
RUN dotnet build "ApiTemplate.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiTemplate.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiTemplate.Api.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PredictionBot-DataManagement/PredictionBot-DataManagement.csproj", "PredictionBot-DataManagement/"]
COPY ["PredictionBot-DataManagement/PredictionBot-DataManagement-Application.csproj", "PredictionBot-DataManagement-Application/"]
COPY ["PredictionBot-DataManagement/PredictionBot-DataManagement-Infrastructure.csproj", "PredictionBot-DataManagement-Infrastructure/"]
COPY ["PredictionBot-DataManagement/PredictionBot-DataManagement-Domain.csproj", "PredictionBot-DataManagement-Domain/"]

RUN dotnet restore "PredictionBot-DataManagement/PredictionBot-DataManagement.csproj"
COPY . .
WORKDIR "/src/PredictionBot-DataManagement"
RUN dotnet build "PredictionBot-DataManagement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PredictionBot-DataManagement.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PredictionBot-DataManagement.dll"]
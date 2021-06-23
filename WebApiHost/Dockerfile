#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WebApiHost/WebApiHost.csproj", "WebApiHost/"]
COPY ["Interoperation/Controllers/Interoperation.Controllers.csproj", "Interoperation/Controllers/"]
COPY ["Core/Core.Logic/Core.Logic.csproj", "Core/Core.Logic/"]
COPY ["DependencyInjection/DI.Abstractions/DI.Abstractions.csproj", "DependencyInjection/DI.Abstractions/"]
COPY ["Core/Core.DataAccess/Core.DataAccess.csproj", "Core/Core.DataAccess/"]
COPY ["Core/Core.Common/Core.Common.csproj", "Core/Core.Common/"]
COPY ["Core/Core.Database/Core.Database.csproj", "Core/Core.Database/"]
COPY ["Core/Core.Model/Core.Model.csproj", "Core/Core.Model/"]
COPY ["Core/Core.Configuration/Core.Configuration.csproj", "Core/Core.Configuration/"]
COPY ["Helpers/Helpers.Checkers/Helpers.Checkers.csproj", "Helpers/Helpers.Checkers/"]
COPY ["Interoperation/Model/Interoperation.Model.DTO/Interoperation.Model.DTO.csproj", "Interoperation/Model/Interoperation.Model.DTO/"]
COPY ["Interoperation/Converters/Interoperation.Converters.DTO/Interoperation.Converters.DTO.csproj", "Interoperation/Converters/Interoperation.Converters.DTO/"]
COPY ["DependencyInjection/DI/DI.csproj", "DependencyInjection/DI/"]
RUN dotnet restore "WebApiHost/WebApiHost.csproj"
COPY . .
WORKDIR "/src/WebApiHost"
RUN dotnet build "WebApiHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApiHost.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiHost.dll"]
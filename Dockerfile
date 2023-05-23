#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CourrierDocker_MBDS_31/CourrierDocker_MBDS_31.csproj", "CourrierDocker_MBDS_31/"]
RUN dotnet restore "CourrierDocker_MBDS_31/CourrierDocker_MBDS_31.csproj"
COPY . .
WORKDIR "/src/CourrierDocker_MBDS_31"
RUN dotnet build "CourrierDocker_MBDS_31.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CourrierDocker_MBDS_31.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourrierDocker_MBDS_31.dll"]
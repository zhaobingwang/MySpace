#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/MySpace.WebMvc/MySpace.WebMvc.csproj", "src/MySpace.WebMvc/"]
COPY ["src/MySpace.ApplicationCore/MySpace.ApplicationCore.csproj", "src/MySpace.ApplicationCore/"]
COPY ["src/MySpace.Infrastructure/MySpace.Infrastructure.csproj", "src/MySpace.Infrastructure/"]
RUN dotnet restore "src/MySpace.WebMvc/MySpace.WebMvc.csproj"
COPY . .
WORKDIR "/src/src/MySpace.WebMvc"
RUN dotnet build "MySpace.WebMvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MySpace.WebMvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MySpace.WebMvc.dll"]
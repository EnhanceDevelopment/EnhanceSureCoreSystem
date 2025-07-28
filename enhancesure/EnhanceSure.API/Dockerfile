# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5117
EXPOSE 7262


## Runtime environment variable (injected during container start)
#ENV ASPNETCORE_URLS=http://+:8081 \
    #DOTNET_RUNNING_IN_CONTAINER=true

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_ENV=PROD
ENV BUILD_ENV=${BUILD_ENV}
ENV BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EnhanceSure.API/EnhanceSure.API.csproj", "EnhanceSure.API/"]
COPY ["EnhanceSure.Application/EnhanceSure.Application.csproj", "EnhanceSure.Application/"]
COPY ["EnhanceSure.Domain/EnhanceSure.Domain.csproj", "EnhanceSure.Domain/"]
COPY ["EnhanceSure.Infrastructure/EnhanceSure.Infrastructure.csproj", "EnhanceSure.Infrastructure/"]
COPY ["EnhanceSure.Persistance/EnhanceSure.Persistance.csproj", "EnhanceSure.Persistance/"]
COPY ["Common.Configuration/Common.Configuration.csproj", "Common.Configuration/"]
RUN dotnet restore "EnhanceSure.API/EnhanceSure.API.csproj"
COPY . .
WORKDIR "/src/EnhanceSure.API"
RUN dotnet build "EnhanceSure.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_ENV=PROD
ENV BUILD_ENV=${BUILD_ENV}
ENV BUILD_CONFIGURATION=Release
RUN dotnet publish "EnhanceSure.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
ARG BUILD_ENV=PROD                  # Pass environment into the container at runtime
ENV ASPNETCORE_ENVIRONMENT=${BUILD_ENV}
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EnhanceSure.API.dll"]


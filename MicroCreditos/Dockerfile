FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS build
WORKDIR /src
COPY ["MicroCreditos.csproj", "MicroCreditos/"]
COPY . MicroCreditos/
WORKDIR /src/MicroCreditos
RUN nuget restore MicroCreditos.csproj -PackagesDirectory ../packages
RUN msbuild MicroCreditos.csproj /p:OutputPath=/app/build

FROM build AS publish
RUN MSBuild MicroCreditos.csproj /p:DeployOnBuild=True /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:DeleteExistingFiles=True /p:publishUrl=/app/publish

FROM base AS final
ARG source
WORKDIR /inetpub/wwwroot
COPY --from=publish /app/publish .
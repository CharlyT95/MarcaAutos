#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 8080

ADD https://raw.githubusercontent.com/vishnubob/wait-for-it/master/wait-for-it.sh /wait-for-it.sh
RUN chmod +x /wait-for-it.sh

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MarcasAutosAPI.API/MarcasAutosAPI.API.csproj", "MarcasAutosAPI.API/"]
COPY ["MarcasAUtosAPI.Domain/MarcasAUtosAPI.Domain.csproj", "MarcasAutosAPI.API/"]
COPY ["MarcasAUtosAPI.Application/MarcasAUtosAPI.Application.csproj", "MarcasAutosAPI.API/"]

RUN dotnet restore "MarcaAutos.Test/MarcasAutos.ApiTest.csproj"
COPY . .
WORKDIR "/src/MarcasAutosAPI.API"
RUN dotnet build "./MarcasAutosAPI.API.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MarcasAutosAPI.API.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=base /wait-for-it.sh /wait-for-it.sh
COPY --from=publish /app/publish .
ENTRYPOINT ["/wait-for-it.sh", "postgres:5432", "--", "dotnet", "Test.Api.dll"]
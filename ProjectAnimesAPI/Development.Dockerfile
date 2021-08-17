FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ProjectAnimesAPI.csproj", "./"]
RUN dotnet restore "ProjectAnimesAPI.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet dev-certs https
ENTRYPOINT dotnet watch run  --urls=https://+:5001 --project ProjectAnimesAPI.csproj

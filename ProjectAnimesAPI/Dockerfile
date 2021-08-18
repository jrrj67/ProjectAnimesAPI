#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN dotnet tool install --global dotnet-ef

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ProjectAnimesAPI/ProjectAnimesAPI.csproj", "ProjectAnimesAPI/"]
RUN dotnet restore "ProjectAnimesAPI/ProjectAnimesAPI.csproj"
COPY . .
WORKDIR "/src/ProjectAnimesAPI"
RUN dotnet build "ProjectAnimesAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectAnimesAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectAnimesAPI.dll"]
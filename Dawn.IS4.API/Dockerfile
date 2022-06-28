#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Dawn.IS4.API/Dawn.IS4.API.csproj", "Dawn.IS4.API/"]
COPY ["Dawn.Entities/Dawn.Entities.csproj", "Dawn.Entities/"]
COPY ["Dawn.Common/Dawn.Commons.csproj", "Dawn.Common/"]
COPY ["Dawn.IServices/Dawn.IServices.csproj", "Dawn.IServices/"]
COPY ["Dawn.Repository/Dawn.Repository.csproj", "Dawn.Repository/"]
RUN dotnet restore "Dawn.IS4.API/Dawn.IS4.API.csproj"
COPY . .
WORKDIR "/src/Dawn.IS4.API"
RUN dotnet build "Dawn.IS4.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dawn.IS4.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dawn.IS4.API.dll"]
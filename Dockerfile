FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY *.sln .
COPY Web/*.csproj Web/
COPY Core/*.csproj Core/
COPY Data/*.csproj Data/

RUN dotnet restore

COPY . .
RUN dotnet publish Web/Web.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "Web.dll"]
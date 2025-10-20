
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY Vibora.sln .
COPY Vibora.API/Vibora.API.csproj Vibora.API/
COPY Vibora.Application/Vibora.Application.csproj Vibora.Application/
COPY Vibora.Domain/Vibora.Domain.csproj Vibora.Domain/
COPY Vibora.Infrastructure/Vibora.Infrastructure.csproj Vibora.Infrastructure/

RUN dotnet restore

COPY . .

WORKDIR /src/Vibora.API
RUN dotnet publish "Vibora.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:5044 
EXPOSE 5044

ENTRYPOINT ["dotnet", "Vibora.API.dll"]
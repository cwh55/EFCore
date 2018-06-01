FROM microsoft/aspnetcore:2.0-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-sac2016 AS build
WORKDIR /src
COPY CoreFirst/CoreFirst.csproj CoreFirst/
RUN dotnet restore CoreFirst/CoreFirst.csproj
COPY . .
WORKDIR /src/CoreFirst
RUN dotnet build CoreFirst.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CoreFirst.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CoreFirst.dll"]


#FROM microsoft/dotnet:latest
#COPY . /app
#WORKDIR /app
#RUN ["dotnet", "restore"]
#RUN ["dotnet", "build"]
#EXPOSE 5000/tcp
#ENV ASPNETCORE_URLS http://*:5000
#ENTRYPOINT ["dotnet", "run"]
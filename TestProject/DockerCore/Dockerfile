FROM microsoft/aspnetcore:2.0-nanoserver-sac2016 AS base  #声明我们将使用哪个基本镜像来构建我们的容器。
WORKDIR /app  #工作目录更改为'/ app'，因此我们的dockerfile中的所有命令都将在那里执行
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-sac2016 AS build
WORKDIR /src
COPY DockerCore/DockerCore.csproj DockerCore/  #我们将.csproj文件复制到临时容器的'/ app'目录中。我们这样做是因为.csproj文件包含了我们项目需要的软件包引用列表
RUN dotnet restore DockerCore/DockerCore.csproj

COPY . .
WORKDIR /src/DockerCore
RUN dotnet build DockerCore.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish DockerCore.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DockerCore.dll"]

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["SimpleCRM.Web/SimpleCRM.Web.csproj", "SimpleCRM.Web/"]
RUN dotnet restore "SimpleCRM.Web/SimpleCRM.Web.csproj"
COPY . .
WORKDIR "/src/SimpleCRM.Web"
RUN dotnet build "SimpleCRM.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SimpleCRM.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SimpleCRM.Web.dll"]
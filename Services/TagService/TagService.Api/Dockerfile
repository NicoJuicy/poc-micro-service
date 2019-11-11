FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Services/TagService/TagService.Api/TagService.Api.csproj", "Services/TagService/TagService.Api/"]
RUN dotnet restore "Services/TagService/TagService.Api/TagService.Api.csproj"
COPY . .
WORKDIR "/src/Services/TagService/TagService.Api"
RUN dotnet build "TagService.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TagService.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TagService.Api.dll"]
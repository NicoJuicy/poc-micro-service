FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Services/ContactService/ContactService.Api/ContactService.Api.csproj", "Services/ContactService/ContactService.Api/"]
RUN dotnet restore "Services/ContactService/ContactService.Api/ContactService.Api.csproj"
COPY . .
WORKDIR "/src/Services/ContactService/ContactService.Api"
RUN dotnet build "ContactService.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ContactService.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ContactService.Api.dll"]
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["src/LojaDropS.Aplicacao/LojaDropS.Aplicacao.csproj", "src/LojaDropS.Aplicacao/"]
RUN dotnet restore "src/LojaDropS.Aplicacao/LojaDropS.Aplicacao.csproj"
COPY . .
WORKDIR "/src/src/LojaDropS.Aplicacao"
RUN dotnet build "LojaDropS.Aplicacao.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LojaDropS.Aplicacao.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LojaDropS.Aplicacao.dll"]
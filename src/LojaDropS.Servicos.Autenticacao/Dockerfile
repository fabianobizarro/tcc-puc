FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["LojaDropS.Servicos.Autenticacao/LojaDropS.Servicos.Autenticacao.csproj", "LojaDropS.Servicos.Autenticacao/"]
RUN dotnet restore "LojaDropS.Servicos.Autenticacao/LojaDropS.Servicos.Autenticacao.csproj"
COPY . .
WORKDIR "/src/LojaDropS.Servicos.Autenticacao"
RUN dotnet build "LojaDropS.Servicos.Autenticacao.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LojaDropS.Servicos.Autenticacao.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LojaDropS.Servicos.Autenticacao.dll"]
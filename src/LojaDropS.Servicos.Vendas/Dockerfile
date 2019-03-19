FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["src/LojaDropS.Servicos.Vendas/LojaDropS.Servicos.Vendas.csproj", "src/LojaDropS.Servicos.Vendas/"]
RUN dotnet restore "src/LojaDropS.Servicos.Vendas/LojaDropS.Servicos.Vendas.csproj"
COPY . .
WORKDIR "/src/src/LojaDropS.Servicos.Vendas"
RUN dotnet build "LojaDropS.Servicos.Vendas.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LojaDropS.Servicos.Vendas.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LojaDropS.Servicos.Vendas.dll"]
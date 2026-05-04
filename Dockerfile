# Estágio de Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copia o arquivo de projeto e restaura as dependências
COPY ["Tarefinhas.csproj", "./"]
RUN dotnet restore "Tarefinhas.csproj"

# Copia o restante dos arquivos e compila
COPY . .
RUN dotnet build "Tarefinhas.csproj" -c Release -o /app/build

# Publica a aplicação
FROM build AS publish
RUN dotnet publish "Tarefinhas.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Estágio Final (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Configura a porta para o Render (padrão 10000 ou via variável PORT)
ENV ASPNETCORE_URLS=http://+:10000

ENTRYPOINT ["dotnet", "Tarefinhas.dll"]

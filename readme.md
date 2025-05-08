# App Monitor API

Bem-vindo ao **App Monitor API**, uma aplicação desenvolvida em .NET 9 para monitoramento de aplicações. Este projeto fornece uma API RESTful para gerenciar e consultar logs de aplicações.

## 📋 Funcionalidades

- Listar aplicações monitoradas.
- Consultar logs de uma aplicação específica com base em um intervalo de tempo.
- Configuração de CORS para integração com frontend.
- Documentação interativa da API com Swagger.

## 🚀 Tecnologias Utilizadas

- **.NET 9**
- **Dapper** para acesso a dados.
- **Npgsql** para conexão com PostgreSQL.
- **Swagger** para documentação da API.
- **Microsoft.Extensions.Configuration** para gerenciamento de configurações.

## ⚙️ Configuração

### Pré-requisitos

- .NET 9 SDK instalado.
- Banco de dados PostgreSQL configurado.
- Configuração de strings de conexão no arquivo `appsettings.json` ou via [User Secrets](https://learn.microsoft.com/pt-br/aspnet/core/security/app-secrets).
- Para ter as informações atualizadas, é preciso que esteja com a aplicação https://github.com/NunesErick/App.Monitor

### Configuração de Strings de Conexão

Certifique-se de configurar as strings de conexão no `appsettings.json` ou via User Secrets.
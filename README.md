# Instruções de Uso da API

## Requisitos

- **Banco de Dados**: PostgreSQL
- **Ferramentas Utilizadas**:
  - **EF Core** (Entity Framework Core)
  - **Docker** (opcional)

---

## Configuração do Banco de Dados

### Passo 1: Criar Tabelas no PostgreSQL

1. Navegue até a pasta do projeto no terminal.
2. Execute o seguinte comando para aplicar as migrações e criar as tabelas automaticamente:

   ```bash
   dotnet ef database update --startup-project WalletFlow.API --project WalletFlow.Infraestructure

## Primeiras Requisições para Utilizar a API

Nos arquivos alterados, você encontrará todas as requisições necessárias para utilizar a API. Para aproveitar ao máximo o desenvolvimento e garantir que todos os recursos funcionem corretamente, siga os seguintes passos:

1. **CreateUser**: Realize a criação de um novo usuário. Esta requisição é necessária para estabelecer uma conta que poderá acessar os outros recursos da API.
   
2. **Login**: Após criar o usuário, execute a requisição de **Login** com as credenciais do usuário recém-criado. 

   - A requisição de **Login** irá retornar um **Bearer Token**.
   - Este **Bearer Token** é essencial para autenticar as suas requisições subsequentes, permitindo que você acesse e interaja com os outros endpoints da API com segurança.

   **Importante**: Sem o **Bearer Token**, as requisições aos outros endpoints não serão autorizadas.

---

## Execução com Docker (opcional)

Caso você prefira rodar a aplicação utilizando o Docker, será necessário configurar o banco de dados manualmente. Isso é útil para ambientes de desenvolvimento ou produção onde o uso de containers facilita o processo de configuração e execução.

### Passo 1: Configurar o Banco de Dados no Docker

1. **Alterar o arquivo `appSettings`**:
   - Abra o arquivo `appSettings` na pasta do projeto.
   - Altere as configurações de conexão com o banco de dados para utilizar as conexões definidas no arquivo `Docker-Compose`. Isso garantirá que o aplicativo se conecte corretamente ao banco de dados dentro do container Docker.

2. **Construir o Container Docker**:
   - Navegue até a pasta `WalletFlow.API` no terminal.
   - Execute o seguinte comando para construir e configurar o container Docker:

     ```bash
     docker compose --build
     ```

   Esse comando irá:
   - Construir as imagens Docker necessárias.
   - Iniciar o container com todas as dependências da aplicação, incluindo o banco de dados.

### Passo 2: Executar Scripts de Criação de Tabelas

Após o container ser executado com sucesso, siga estas etapas:

1. Entre no banco de dados através do container Docker.
2. Rode os scripts de criação de tabelas, que estão localizados nos arquivos alterados. Esses scripts irão criar a estrutura necessária no banco de dados para que a API funcione corretamente.

**Observação**: Esses scripts são necessários somente se você estiver utilizando o Docker para rodar o banco de dados. Se o banco de dados já estiver configurado externamente, esse passo pode ser pulado.

---




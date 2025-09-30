Claro, aqui está a tradução do arquivo Markdown para o português.

# MandrilAPI

**MandrilAPI** é uma API Web RESTful desenvolvida em **C\# com ASP.NET Core (.NET 8)** que simula o gerenciamento de uma entidade `Mandril`, que pode estar associada a um conjunto de habilidades (`Skills`).

A aplicação segue os princípios de **arquitetura limpa**, **separação de responsabilidades** e agora inclui um sistema completo de **autenticação e autorização baseado em JWT e ASP.NET Identity**.

-----

## 🆕 Novidades e funcionalidades recentes

  - **Sistema de autenticação e autorização JWT**: Registro, login e logout de usuários, geração e validação de tokens JWT.
  - **Gerenciamento de usuários**: Endpoints para obter e atualizar dados do usuário autenticado (nome, sobrenome, username público, email, data de nascimento).
  - **Papéis (Roles) e políticas (Policies)**: Suporte para papéis `Admin` e `User`, com endpoints protegidos por políticas e papéis.
  - **Controladores adicionais**:
      - `AccountController`: Registro, login e logout de usuários.
      - `UserDataController`: Consulta e atualização de dados do usuário autenticado.
      - `AdminController`: Gerenciamento avançado de relacionamentos e usuários (somente para administradores).
  - **Validações avançadas**: Validações personalizadas em DTOs para registro e atualização de usuários.
  - **Swagger com suporte para JWT**: Documentação interativa e testes de endpoints autenticados.
  - **Mensagens de erro e sucesso personalizadas**: Mensagens claras e categorizadas para cada operação.

-----

## Arquitetura e Design

  - **Arquitetura Limpa** (Clean Architecture)
  - Estrutura modular em camadas bem definida
  - Padrão Repository com separação de responsabilidades de leitura/escrita
  - Injeção de dependência através de interfaces
  - **ASP.NET Identity** para gerenciamento de usuários e papéis
  - **JWT** para autenticação e autorização seguras

## Banco de Dados

  - Persistência em SQL Server usando Entity Framework Core
  - Relacionamento muitos-para-muitos entre `Mandril` e `Skills` com tabela intermediária `MandrilSkills` e campo `PowerMS`
  - Migrações e configuração de entidades
  - Tabelas de usuários e papéis gerenciadas pelo Identity

## API RESTful

  - Controladores principais:
      - `MandrilController`: Gerenciamento de mandris (somente Admin)
      - `SkillsController`: Gerenciamento de habilidades (somente Admin)
      - `MandrilSkillsController`: Gerenciamento de relacionamentos mandril-habilidade (usuários autenticados)
      - `AccountController`: Registro, login e logout de usuários
      - `UserDataController`: Gerenciamento de dados do usuário autenticado
      - `AdminController`: Gerenciamento avançado de relacionamentos e usuários (somente Admin)
  - Endpoints seguindo as convenções REST
  - Documentação com Swagger (inclui autenticação JWT)

## Qualidade do Código

  - Sistema de logging (ILogger) para monitoramento de operações
  - Tratamento de erros por camada com mensagens personalizadas
  - Validações de negócio e DTOs para transferência segura de dados
  - Código limpo e documentado

-----

## 🎯 Objetivos do Projeto

1.  Implementação de uma arquitetura escalável em .NET
2.  Boas práticas no desenvolvimento de APIs seguras
3.  Gerenciamento de relacionamentos em banco de dados e gestão de usuários/papéis
4.  Padrões de design comuns em aplicações empresariais

-----

## 🚀 Próximas Melhorias

  - Testes automatizados

-----

## 🛠️ Tecnologias utilizadas

  - .NET 8
  - ASP.NET Core Web API
  - Entity Framework Core
  - ASP.NET Identity
  - JWT (Json Web Token)
  - Swagger
  - SQL Server
  - ILogger

-----

-----

## 📁 Estrutura do projeto

```
📁 MandrilAPI (Raiz do Projeto)
├── 📁 Aplication
│   ├── 📁 Interfaces
│   │   ├── 📄 IMandrilSkillsReadRepository.cs
│   │   └── 📄 IMandrilSkillsWriteRepository.cs
│   └── 📁 Service
│       ├── 📄 Functions.cs
│       ├── 📄 MessageDefaultsAdmin.cs
│       ├── 📄 MessageDefaultsDevs.cs
│       └── 📄 MessageDefaultsUsers.cs
├── 📁 Domain
│   └── 📁 Models
│       ├── 📄 Mandril.cs
│       └── 📄 Skill.cs
├── 📁 Infrastructure
│   ├── 📁 Authentication
│   │   ├── 📁 AuthDatabaseContext
│   │   ├── 📁 AuthenticationDTOs
│   │   ├── 📁 AuthModels
│   │   └── 📄 GenerateJwt.cs
│   ├── 📁 CustomAnnotations
│   ├── 📁 DatabaseContext
│   │   ├── 📄 MandrilDbContext.cs
│   │   └── 📄 MandrilWithSkillsIntermediateTable.cs
│   ├── 📁 ModelsDTOs
│   │   ├── 📄 MandrilDto.cs
│   │   ├── 📄 SkillDto.cs
│   │   └── 📄 UpdatePowerRequestDto.cs
│   └── 📁 Repositories
│       ├── 📄 MandrilSkillsReadRepository.cs
│       └── 📄 MandrilSkillsWriteRepository.cs
├── 📁 Presentation
│   ├── 📁 AuthenticationControllers
│   ├── 📁 Controllers
│   └── 📄 Program.cs
├── 📄 appsettings.json
├── 📄 README.md
├── 📄 README-ES.md
└── 📄 README-PT-BR.md
```

## 📚 Documentação com Swagger

Ao iniciar o projeto, o Swagger é carregado automaticamente em:
https://localhost:(porta)/swagger

Lá você pode ver e testar todos os endpoints disponíveis.

# 🧪 Como executar o projeto

## Como executar o projeto no Windows

Este projeto pode ser executado tanto pela linha de comando quanto por um IDE como Visual Studio ou Rider.

## Opção 1: Pela linha de comando (PowerShell ou CMD)

1.  **Clonar o repositório:**

<!-- end list -->

```
git clone https://github.com/AdrianLeon09/mandrilapi

cd mandrilapi
```

**2. Restaurar as dependências:**

```
dotnet restore
```

**3. Aplicar as migrações para criar o banco de dados:**

**Configurar a string de conexão**

  - Abra o arquivo `appsettings.json` localizado no projeto.
  - Verifique se a string de conexão com o banco de dados SQL Server está configurada corretamente para o seu ambiente local.
  - Exemplo Windows:

<!-- end list -->

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=mandrilDB;Trusted_Connection=true;TrustServerCertificate=True;"
}
```

  - Exemplo Linux:

<!-- end list -->

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=mandrilDB;UserId=sa;Password=SuaSenha123;TrustServerCertificate=True;"
}

```

**4. Aplicar as migrações correspondentes a AuthDbContext e MandrilDbContext**

No terminal, navegue até a solução do projeto e digite:

```
dotnet ef migrations add NomeDaMigracao --context MandrilDbContext
```

```
dotnet ef migrations add NomeDaMigracao --context AuthDbContext
```

```
dotnet ef database update --context MandrilDbContext
```

```
dotnet ef database update --context AuthDbContext
```

**5. Executar a aplicação:**

dotnet run

**6. Abrir a documentação do Swagger no seu navegador:**

` https://localhost:(porta)/swagger/index.html  `

## Opção 2: Pelo Visual Studio

Siga estes passos para abrir e executar o projeto no Visual Studio 2022:

1.  **Abrir o projeto ou a solução**

      - Inicie o Visual Studio 2022.

      - Selecione **Clonar um repositório** e insira ` https://github.com/AdrianLeon09/mandrilapi  `

      - Se você baixou o repositório diretamente:

      - Selecione **Abrir um projeto ou uma solução**.

      - Navegue até a pasta onde você clonou o repositório e selecione o arquivo `MandrilAPI.sln` (solução) do projeto.

2.  **Restaurar as dependências**

      - O Visual Studio detectará e restaurará automaticamente os pacotes NuGet necessários.
      - Você pode verificar o progresso na janela **Gerenciador de Pacotes NuGet** ou na barra de status.

3.  **Configurar a string de conexão**

      - Abra o arquivo `appsettings.json` localizado no projeto.
      - Verifique se a string de conexão com o banco de dados SQL Server está configurada corretamente para o seu ambiente local.
      - Exemplo:

    <!-- end list -->

    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=mandrilDB;Trusted_Connection=true;TrustServerCertificate=True;"
    }

    ```

**4. Aplique as migrações correspondentes a **AuthDbCOntext** e **MandrilDbContext****

Abra o Console do Gerenciador de Pacotes em Ferramentas > Gerenciador de Pacotes NuGet > Console do Gerenciador de Pacotes.

Execute os seguintes comandos para criar as migrações e atualizar o banco de dados:

```
Add-Migration NomeDaMigracao -Context MandrilDbContext
```
```
Add-Migration NomeDaMigracao -Context AuthDbContext
```
```
Update-Database -context MandrilDbCOntext
```
```
Update-Database -context AuthDbContext
```

5.  **Executar a aplicação**
    Pressione F5 para iniciar a aplicação em modo de depuração, ou Ctrl + F5 para executá-la sem depurar.
    Uma janela do navegador será aberta automaticamente com a documentação do Swagger.

**(Opcional - Acessar a documentação do Swagger manualmente)**

No navegador, acesse a URL: `http://localhost:(porta)/swagger/index.html`
Lá você poderá ver a documentação interativa da API e testar os endpoints.

**NOTAS**

  - Certifique-se de ter o Visual Studio 2022 instalado com a carga de trabalho de **desenvolvimento ASP.NET e web**.

  - A porta atribuída pode variar; verifique a que aparece na barra de endereços do navegador quando a aplicação é iniciada.

  - Se você fizer alterações nas migrações, lembre-se de aplicar `Update-Database` novamente para atualizar o banco de dados.

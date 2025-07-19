# MandrilAPI

**MandrilAPI** é uma API Web RESTful desenvolvida em **C# com ASP.NET Core** que simula o gerenciamento de uma entidade `Mandril`, que pode estar associada a um conjunto de habilidades (`Skills`).

A aplicação está estruturada seguindo princípios de **arquitetura limpa** e **separação de responsabilidades**, tornando-a ideal para aprender como escalar e organizar um projeto de forma básica.

O sistema inclui três controladores principais:
- `MandrilController`
- `SkillsController`
- `MandrilSkillsController`

Cada um gerencia sua respectiva tabela em um **banco de dados SQL Server** por meio do EF. A tabela `MandrilSkills` representa uma relação **muitos para muitos** entre mandris e habilidades, utilizando chaves primárias compostas. Além disso, incorpora uma coluna adicional chamada `PowerMS` (MS = MandrilSkill), que indica o nível de habilidade atribuído, variando de 0 até o máximo de 4.

Essa tabela intermediária foi modelada manualmente com Entity Framework, o que permite maior controle sobre sua estrutura e comportamento, pensando em uma possível escalabilidade futura do sistema e na incorporação de novos recursos.

---

## 🎯 O que este projeto oferece?
Este projeto de prática foi construído com o objetivo de ir além do básico. Inclui conceitos essenciais para o desenvolvimento profissional de backend:

### Arquitetura e Design
- Implementação da **Arquitetura Limpa** (Clean Architecture)
- Estrutura modular em camadas bem definida
- Padrão Repository com separação de responsabilidades de leitura e escrita
- Injeção de dependência via interfaces

### Banco de Dados
- Persistência em SQL Server usando Entity Framework Core
- Relação muitos para muitos entre `Mandril` e `Skills`
- Tabela intermediária `MandrilSkills` com campo `PowerMS` para nível de habilidade
- Migrações e configuração das entidades

### API RESTful
- Três controladores principais:
  - `MandrilController`: Administração de mandris
  - `SkillsController`: Administração de habilidades
  - `MandrilSkillsController`: Gerenciamento de relações entre mandril e habilidades
- Endpoints seguindo convenções REST
- Documentação com Swagger

### Qualidade de Código
- Sistema de logging (ILogger) para monitoramento de operações via console
- Tratamento de erros por camada com mensagens personalizadas
- Validações de regras de negócio
- DTOs para transferência segura de dados
- Código limpo e comentado em inglês

## 🎯 Objetivos do Projeto
Este projeto foi desenvolvido para demonstrar:
1. Implementação de arquitetura escalável em .NET
2. Boas práticas no desenvolvimento de APIs
3. Manipulação de relacionamentos em banco de dados
4. Padrões de design comuns em aplicações empresariais

## 🚀 Melhorias Futuras
- Sistema de autenticação/autorização baseado em JWT e ASP.NET Identity
- Desenvolvimento de uma interface de usuário com Angular

---

Este projeto **não tem a intenção de ser avançado**, mas é ideal para qualquer iniciante que queira aprender de forma prática:
- Como estruturar uma API real de maneira profissional
- Que validações e erros considerar em projetos do mundo real
- Como relacionar entidades com banco de dados usando C# e ASP.NET Core

---

## 🛠️ Tecnologias Utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core 
- Swagger
- SQL Server
- ILogger

---

## 📁 Estrutura do Projeto

```
/Presentation
├── Controllers
│   ├── MandrilController.cs
│   ├── SkillsController.cs
│   └── SkillsMandrilController.cs
├── Program.cs

/Application
├── Interfaces
│   ├── IMandrilSkillsReadRepository.cs
│   └── IMandrilSkillsWriteRepository.cs
├── Services
│   ├── MessageDefaultsDevs.cs
│   └── MessageDefaultsUsers.cs

/Infrastructure
├── Repositories
│   ├── MandrilSkillsReadRepository.cs
│   └── MandrilSkillsWriteRepository.cs
├── DatabaseContext
│   ├── MandrilDbContext.cs
│   └── MandrilWithSkillsIntermediateTable.cs
├── DTOs
│   ├── MandrilDTO.cs
│   ├── SkillDTO.cs
│   └── PowerDTO.cs
├── Migrations

/Domain
├── Models
│   ├── Mandril.cs
│   └── Skill.cs
```

## 📚 Documentação com Swagger

Ao iniciar o projeto, o Swagger é carregado automaticamente em:  
https://localhost:(porta)/swagger

Lá você pode visualizar e testar todos os endpoints disponíveis.

---

## 🧪 Como Executar o Projeto

### 🔸 No Windows

Este projeto pode ser executado tanto via linha de comando quanto por IDE (Visual Studio ou Rider).

### Opção 1: Linha de Comando (PowerShell ou CMD)

1. **Clonar o repositório:**
```
git clone https://github.com/AdrianLeon09/mandrilapi 
cd mandrilapi 
```

2. **Restaurar dependências:**
```
dotnet restore
```

3. **Aplicar migrações:**
```
dotnet ef database update
```

4. **Executar o projeto:**
```
dotnet run
```

5. **Acessar o Swagger:**
```
https://localhost:(porta)/swagger/index.html
```

### Opção 2: Visual Studio 2022

1. **Abrir o projeto ou solução**
   - Inicie o Visual Studio 2022
   - Selecione **Clonar um repositório** e informe:
     ```
     https://github.com/AdrianLeon09/mandrilapi
     ```
   - Ou, se já baixou o projeto, selecione **Abrir projeto/solução** e abra `MandrilAPI.sln`

2. **Restaurar pacotes NuGet**
   - O Visual Studio restaurará automaticamente as dependências

3. **Configurar a string de conexão**
   - No `appsettings.json`:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=mandrilDB;Trusted_Connection=true;TrustServerCertificate=True;"
     }
     ```

4. **Aplicar migrações**
   - Acesse: Ferramentas > Gerenciador de Pacotes NuGet > Console do Gerenciador
   - Execute:
     ```
     Update-Database
     ```

5. **Executar**
   - Pressione F5 (debug) ou Ctrl+F5 (sem debug)

O navegador abrirá automaticamente a documentação do Swagger.

---

**Notas:**
Certifique-se de ter o Visual Studio 2022 instalado com a carga de trabalho de desenvolvimento ASP.NET e web.

A porta atribuída pode variar; verifique o que aparece na barra de endereços do seu navegador ao iniciar o aplicativo.

Se você fizer alterações nas migrações, lembre-se de executar o comando ``Update-Database`` novamente para atualizar o banco de dados.

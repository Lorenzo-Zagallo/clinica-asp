# Projeto Sistema de Prontuário de Clínica

### Descrição do Projeto

Este projeto é um sistema simples de prontuário de clínica, desenvolvido com **ASP.NET Web Forms** para fins de aprendizado. Ele demonstra conceitos fundamentais de desenvolvimento web e manipulação de dados, como operações CRUD (Criar, Ler, Atualizar, Deletar), tudo a partir de uma interface gráfica intuitiva.

É uma ótima base para quem está começando com a plataforma ASP.NET e deseja entender como o frontend (`.aspx`), o backend (`.aspx.cs`) e a lógica de negócio interagem.

## Tecnologias Utilizadas

  * **Frontend**: ASP.NET Web Forms (`.aspx`): Utiliza HTML, CSS e JavaScript para a interface de usuário.
  * **Backend**: C\# (`.aspx.cs`): Implementa a lógica de negócio e o controle das operações.
  * **Banco de Dados:** SQL Server (com arquivo `.mdf` local)
  * **Lógica de Negócio**: Totalmente implementada no backend, nos arquivos `.aspx.cs`.
  * **Ambiente de Desenvolvimento:** Visual Studio

### Funcionalidades

O sistema foi projetado para realizar as seguintes operações básicas de gerenciamento de dados:

* **Criar (Create):** Inserir novos registros de pacientes ou prontuários.
* **Ler (Read):** Visualizar e consultar dados existentes.
* **Atualizar (Update):** Modificar informações de registros.
* **Deletar (Delete):** Excluir registros do sistema.


## Estrutura do Projeto

A estrutura do projeto segue a convenção padrão de aplicações ASP.NET Web Forms:

Com certeza\! Aqui está a estrutura do projeto no modelo que você pediu, com base nas informações do seu projeto. Você pode copiar e colar este trecho diretamente no seu arquivo `README.md`.

```
## Estrutura do Projeto

A estrutura do projeto segue a convenção padrão de aplicações ASP.NET Web Forms:

```

clinica-asp/ProjetoWebApp/
├── ProjetoWebApp.csproj					\# Arquivo de projeto do Visual Studio
├── App\_Data/								\# Pasta para arquivos de dados locais, como o banco de dados
│   ├── DadosClinica.mdf					\# Arquivo principal do banco de dados SQL Server
│   └── DadosClinica\_log.ldf				\# Arquivo de log do banco de dados
├── UserControls/							\# Pasta para organizar componentes de interface reutilizáveis
│   ├── MenuSimples.ascx					\# O controle de usuário da interface
│   ├── MenuSimples.ascx.cs					\# Lógica de Backend para o controle de usuário
│   └── MenuSimples.ascx.designer.cs		\# Arquivo gerado automaticamente para o controle
├── Default.aspx							\# Página principal da aplicação (Frontend)
│   ├── Default.aspx.cs						\# Lógica de Backend para a página Default.aspx
│   ├── Default.aspx.designer.cs			\# Arquivo gerado automaticamente para a página
├── MasterPage.master						\# A página mestre que define o layout global da aplicação
│   ├── MasterPage.master.cs				\# Lógica de Backend para a Master Page
│   ├── MasterPage.master.designer.cs		\# Arquivo gerado automaticamente para a Master Page
└── Web.config								\# Configurações globais da aplicação web

```

### Pré-requisitos

Para executar este projeto, você precisará ter o seguinte ambiente de desenvolvimento configurado:

  * **Visual Studio** (Versão 2017 ou superior, com a workload de "Desenvolvimento para a Web e ASP.NET" instalada) ou **Visual Studio Code** com as extensões apropriadas para C\#.
  * **.NET Framework** (Versão 4.x ou superior).

### Como Executar o Projeto

1.  Clone este repositório para o seu ambiente local.
2.  Abra a solução (`.sln`) no Visual Studio.
3.  No "Gerenciador de Soluções", clique com o botão direito no projeto e selecione **"Recompilar"** (Build).
4.  Pressione `F5` ou clique no botão "Executar" para iniciar a aplicação no seu navegador.
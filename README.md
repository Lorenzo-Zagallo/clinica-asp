# Projeto Clinica - Sistema de Prontuário

## Descrição

Este projeto é um sistema simples de prontuário de clínica, desenvolvido com **ASP.NET Web Forms** para fins de aprendizado. Ele demonstra conceitos fundamentais de desenvolvimento web e manipulação de dados, como operações CRUD (Criar, Ler, Atualizar, Deletar), tudo a partir de uma interface gráfica intuitiva.

É uma ótima base para quem está começando com a plataforma ASP.NET e deseja entender como o frontend (`.aspx`), o backend (`.aspx.cs`) e a lógica de negócio interagem.

-----

## Funcionalidades

O sistema foi projetado para gerenciar informações básicas de pacientes e oferece as seguintes funcionalidades:

  * **Carregamento Automático de Pacientes**: Exibe uma lista de pacientes ao iniciar a aplicação.
  * **CRUD de Pacientes**:
      * **Criar um Paciente**: Adiciona um novo registro de paciente ao sistema.
      * **Ler Pacientes**: Permite visualizar a lista completa de pacientes.
      * **Atualizar dados do Paciente**: Modifica as informações de um paciente existente.
      * **Deletar um Paciente**: Remove um paciente da lista.

-----

## Tecnologias Utilizadas

  * **Frontend**: ASP.NET Web Forms (`.aspx`): Utiliza HTML, CSS e JavaScript para a interface de usuário.
  * **Backend**: C\# (`.aspx.cs`): Implementa a lógica de negócio e o controle das operações.
  * **Banco de Dados**: N/A: **Atenção**: Este projeto **não utiliza** um banco de dados persistente. Os dados são armazenados na memória, o que significa que serão perdidos ao fechar a aplicação. Este é um design intencional para focar na lógica do ASP.NET.
  * **Lógica de Negócio**: Totalmente implementada no backend, nos arquivos `.aspx.cs`.

-----

## Estrutura do Projeto

```
clinica-asp/ProjetoWebApp/
├── Properties/                    # Configurações do projeto e metadados
│   ├── AssemblyInfo.cs            # Informações sobre o assembly
├── bin/                           # Arquivos compilados (.dll, .exe)
├── obj/                           # Arquivos temporários de compilação
├── Default.aspx                   # Página principal da interface (Frontend)
├── Default.aspx.cs                # Lógica de Backend para a página Default.aspx
├── Default.aspx.designer.cs       # Arquivo gerado automaticamente para o controle de componentes
├── ProjetoWebApp.csproj           # Arquivo de projeto do Visual Studio
└── Web.config                     # Configurações globais da aplicação web
```

*Note que a estrutura pode ter outros arquivos e pastas dependendo da sua IDE (como `bin` e `obj`), mas os listados acima são os principais para o funcionamento do projeto.*

-----

## Pré-requisitos

Para executar este projeto, você precisará ter o seguinte ambiente de desenvolvimento configurado:

  * **Visual Studio** (Versão 2017 ou superior, com a workload de "Desenvolvimento para a Web e ASP.NET" instalada) ou **Visual Studio Code** com as extensões apropriadas para C\#.
  * **.NET Framework** (Versão 4.x ou superior).

-----

## Como Executar o Projeto

1.  **Clone o repositório:**
    ```
    git clone https://github.com/seu-usuario/seu-repositorio.git
    ```
2.  **Abra o projeto no Visual Studio:**
    Navegue até a pasta `ProjetoWebApp` e abra o arquivo `ProjetoWebApp.csproj`.
3.  **Restaure os pacotes (se necessário):**
    O Visual Studio deve restaurar as dependências automaticamente. Caso não, clique com o botão direito na solução e selecione "Gerenciar Pacotes NuGet".
4.  **Execute a aplicação:**
    Pressione **F5** ou clique no botão "Start" (Geralmente um triângulo verde na barra de ferramentas) no Visual Studio.
    A aplicação será iniciada em seu navegador padrão.
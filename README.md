# Sistema de Cadastro de Veículos

Este é um sistema de gerenciamento de veículos, desenvolvido em C# utilizando o framework .NET, com banco de dados MySQL. O sistema permite a criação de administradores com autenticação de senha, e possibilita o cadastro e consulta de veículos.

## Funcionalidades

- **Autenticação de Administradores:** Apenas administradores autenticados podem acessar as funcionalidades de cadastro e consulta de veículos.
- **Cadastro de Veículos:** Administradores podem adicionar novos veículos ao sistema, especificando atributos como nome, marca e ano.
- **Consulta de Veículos:** Administradores podem buscar veículos cadastrados no sistema, assim como fazer alterações do tipo 'Atualizar'e 'Deletar'.

## Tecnologias Utilizadas

- **C#:** Linguagem de programação principal.
- **.NET Core / ASP.NET:** Framework para a criação da API.
- **MySQL:** Banco de dados para armazenar os dados dos administradores e veículos.
- **JWT:** Utilizado para autenticação via tokens.

## Como Rodar o Projeto

**1. Clonar o Repositório:**

```git clone https://github.com/seu-usuario/nome-do-repositorio.git```

**2. Configurar o Banco de Dados:**

- Certifique-se de ter o MySQL instalado.
- Crie um banco de dados no MySQL e configure a string de conexão no appsettings.json do projeto.

**3. Instalar Dependências:**

Com o projeto clonado, navegue até o diretório do projeto e execute o comando abaixo para restaurar as dependências:

```dotnet restore```

**4. Rodar o Projeto:**

```dotnet run```

Isso iniciará a API localmente, geralmente na URL *https://localhost:5001*.

**5. Testar a API:**

- Para testar as funcionalidades, você pode usar o Postman ou ferramentas semelhantes, enviando requisições HTTP para as rotas da API.
- As rotas disponíveis incluem a criação de administradores, login para autenticação, cadastro de veículos, e consulta de veículos.

## Considerações Finais

Este é um sistema simples de cadastro de veículos com autenticação de administradores, utilizando as tecnologias C#, .NET, MySQL e JWT para autenticação.

--------------------------------

# Vehicle Registration System

This is a vehicle management system developed in C# using the .NET framework, with a MySQL database. The system allows the creation of administrators with password authentication, and enables the registration and querying of vehicles.

## Features

- **Administrator Authentication:** Only authenticated administrators can access the vehicle registration and query functionalities.
- **Vehicle Registration:** Administrators can add new vehicles to the system, specifying attributes such as name, brand, and year.
- **Vehicle Query:** Administrators can search for registered vehicles in the system, as well as make changes like 'Update' and 'Delete'.

## Technologies Used

- **C#:** Main programming language.
- **.NET Core / ASP.NET:** Framework for creating the API.
- **MySQL:** Database to store administrator and vehicle data.
- **JWT:** Used for authentication via tokens.

## How to Run the Project

**1. Clone the Repository:**

```bash
git clone https://github.com/your-username/repository-name.git
```

**2. Set Up the Database:**

- Make sure you have MySQL installed.
- Create a MySQL database and configure the connection string in the appsettings.json file of the project.

**3. Install Dependencies:**

Once the project is cloned, navigate to the project directory and run the following command to restore dependencies:

```dotnet restore```

**4. Run the Project:**

```dotnet run```

This will start the API locally, usually at the URL https://localhost:5001.

**5. Test the API:**

- To test the features, you can use Postman or similar tools by sending HTTP requests to the API endpoints.
- Available routes include creating administrators, logging in for authentication, registering vehicles, and querying vehicles.

## Final Considerations

This is a simple vehicle registration system with administrator authentication, using the technologies C#, .NET, MySQL, and JWT for authentication.

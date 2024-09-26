# Sobre o projeto

Esta API foi desenvolvida com **.NET 8** e segue os princípios do **Domain-Driven Design (DDD)** para oferecer uma solução robusta e organizada no gerenciamento de despesas pessoais. O principal propósito é permitir que os usuários registrem suas despesas com detalhes como título, data, hora, descrição, valor e método de pagamento, armazenando todas as informações de forma segura em um banco de dados **MySQL**.

## Arquitetura e Funcionalidades

A **API** é construída com base na arquitetura **REST**, utilizando os métodos **HTTP** convencionais para garantir uma comunicação eficiente e simplificada. A documentação é gerada automaticamente via **Swagger**, oferecendo uma interface interativa onde desenvolvedores podem explorar e testar facilmente os endpoints.

## Principais Tecnologias Utilizadas
- **AutoMapper**: Realiza o mapeamento automático entre objetos de domínio e objetos de requisição/resposta, reduzindo a repetição de código manual.
- **FluentAssertions**: Facilita a criação de testes unitários, tornando as verificações mais legíveis e intuitivas, resultando em testes mais claros e compreensíveis.
- **FluentValidation**: Responsável pelas validações das classes de requisição, proporcionando uma maneira simples e elegante de aplicar regras de validação.
- **Entity Framework**: Utilizado como ORM (Object-Relational Mapper), simplifica as operações de banco de dados, permitindo que você trabalhe com objetos .NET em vez de lidar diretamente com SQL.

Essa combinação de tecnologias garante uma API escalável, fácil de manter e eficiente no controle de despesas pessoais.

## Features
- **Domain-Driven Design (DDD)**: Estrutura modular que facilita o entendimento e a manutenção do domínio da aplicação.
- **Testes de Unidade**: Testes abrangentes com FluentAssertions para garantir a funcionalidade e a qualidade.
- **Geração de Relatórios**: Capacidade de exportar relatórios detalhados para PDF e Excel, oferecendo uma análise visual e eficaz das despesas.
- **RESTful API com Documentação Swagger**: Interface documentada que facilita a integração e o teste por parte dos desenvolvedores.

## Getting Started
Para obter uma cópia local funcionando, siga estes passos simples.

### Requisitos
- Visual Studio versão 2022+ ou Visual Studio Code
- Windows 10+ ou Linux/MacOS com .NET SDK instalado
- MySql Server

### Instalação
1. Clone o repositório:

 ``` sh 
    git clone https://github.com/mathsant/cash-flow-dotnet-api
 ```
2. Preencha as informações no arquivo appsettings.Development.json.

3. Execute a API e aproveite o seu teste :)
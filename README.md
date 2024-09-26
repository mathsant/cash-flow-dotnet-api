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
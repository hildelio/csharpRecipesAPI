# API de Receitas

## Descrição

Este projeto consiste na implementação de uma API para um aplicativo de receitas, permitindo o cadastro, consulta, atualização e exclusão de receitas, além de fornecer funcionalidades para o cadastro de usuários que podem comentar nas receitas.

## Motivação

O objetivo deste projeto é consolidar conhecimentos em ASP.NET e C#, explorando conceitos fundamentais da web e arquitetura MVC.

## Tecnologias Utilizadas

- ASP.NET
- C#
- MVC

## Funcionalidades Principais

- Cadastro, consulta, atualização e exclusão de receitas
- Cadastro de usuários
- Comentários em receitas

## Estrutura do Projeto

O projeto é uma aplicação WebAPI que fornece endpoints para interação com receitas e usuários, seguindo padrões RESTful.

## Como Usar

1. Clone o repositório.
2. Abra o projeto em sua IDE.
3. Execute a aplicação.
4. Utilize um cliente HTTP (como Postman) para interagir com a API através dos endpoints disponíveis.

## Endpoints

- **GET /api/receitas**: Retorna todas as receitas cadastradas.
- **GET /api/receitas/{id}**: Retorna uma receita específica pelo ID.
- **POST /api/receitas**: Cadastra uma nova receita.
- **PUT /api/receitas/{id}**: Atualiza uma receita existente.
- **DELETE /api/receitas/{id}**: Exclui uma receita pelo ID.
- **POST /api/usuarios**: Cadastra um novo usuário.
- **POST /api/receitas/{id}/comentarios**: Adiciona um comentário a uma receita específica.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir uma issue ou uma pull request.


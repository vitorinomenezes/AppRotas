# API .NET 8, SWAGGER MSSQLLOCAL para gerenciamento Rotas de Viagem

### A APIROTAS é uma aplicação criada nos padrões de desenho do DDD, e tem como objetivo um simples cadastros de ROTAS, com um crud em mssqllocaldb/EF. E uma busca pela melhor valor por rota.

### Este projeto consiste em uma API desenvolvida em .NET 8.

## Funcionalidades Principais

* **Listagem de ROTAS:** Endpoint para recuperar a lista de ROTAS cadastradas.

## Padrão DDD 

Seguindo os princípios do Domain-Driven Design (DDD), o projeto foi estruturado em camadas.

## Tecnologias e Bibliotecas Utilizadas

As seguintes tecnologias e bibliotecas foram utilizadas no desenvolvimento desta API:

* **.NET 8:** Plataforma de desenvolvimento.
* * **.Entity Framework:** ORM mais utilizado nas aplicações .NET.
* **MSSQLLOCALDB:** Utilizado para persistir os dados.
* * **Swagger:** provem a documentação visual da api via browser.

### Bibliotecas NuGet

* **Automapper 14.0.0:** Biblioteca para mapeamento de objetos.
* **Microsoft.EntityFrameworkCore 9.0.4:** ORM da Microsoft para acesso a dados.
* **Microsoft.EntityFrameworkCore.Tools 9.0.4:** Ferramentas para o Entity Framework Core (como migrations).
* **Microsoft.Extensions.DependencyInjection.Abstractions 9.0.4:** Abstrações para injeção de dependência.
* **NSwag.Annotations 0.1.15:** Anotações para geração de documentação OpenAPI (Swagger).
* **Swashbuckle.AspNetCore 6.6.2:** Biblioteca para gerar a interface do Swagger/OpenAPI para documentação e testes da API.
* **Newtonsoft.Json 13.0.3:** Biblioteca para trabalhar com JSON.
* **Microsoft.EntityFrameworkCore.SqlServer.Design:** Suporte para design do Entity Framework Core com SQLite.


## Endpoints da API

Os endpoints da API podem ser visualizados nas imagens de evidência da funcionalidade abaixo (mencionadas no seu texto). Geralmente, a documentação completa dos endpoints pode ser acessada através do Swagger UI, configurado com o Swashbuckle.AspNetCore.

Parte inicial
![image](https://github.com/user-attachments/assets/56d35e37-2518-4791-a41f-00385ed77271)

## Como Executar

** No Visual Studio

1.  **Clonar o Repositório:**
  [ [ ```bash
    [git clone (https://github.com/vitorinomenezes/AppWVBTesteBackEnd.git)](https://github.com/vitorinomenezes/ApiBlog.git)
    ```](https://github.com/vitorinomenezes/AppRotas.git)

2.  **Restaurar as Dependências:**
    ```bash
    dotnet restore
    ```
5.  **Executar a API .NET 8:**
    No diretório raiz do projeto da API, execute:
    ```bash
    dotnet run
    ```

A API estará acessível em um endereço como [`[[http://localhost:5xxx/swagger`](https://localhost:44323/swagger/index.html]).
](https://localhost:44300/index.html)


## Melhorias e próximos passos 
* Implementar logs e rastreio de falhas
* Implementar a camada `Repository`no local correto.
* melhorar e corrigir testes unitários e de integração.
* Implementar tratamento de erros mais robusto.
* Adicionar autenticação e autorização (já parcialmente configurado com JWT OUATH 2).


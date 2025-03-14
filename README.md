
# Gerenciamento de clientes

Uma aplicação completa, com fronend e backend no mesmo repositório, desenvolvido para consulta de benefícios de um cliente.



## Frontend
O frontend consta de tela que pede credenciais de segurança para acesso a uma nova tela com um valor de entrada (cpf) e os resultados apresentados na própria tela;

O frontend foi desenvolvido em Asp Net MVC com Razor Pages;
## Backend
O backend é composto de uma API com dois endpoints, um para geração do token a partir das credenciais de acesso e o outro é a consulta de benefícios a partir de um Cpf:

Backend desenvolvido em .NET Core versão 8. Para comunicação com as Apis externas, utilizou-se a biblioteca REFIT;

O backend também consta de um projeto de Testes Unitários, usando xUnit, Moq e coverlet coverage, para abranger a Api desenvolvida;

Na WebApi, procurou-se seguir os princípios do clean code e do solid e seguiu-se o padrão CQRS;
## Instalação da aplicação na máquina

Para instalar o frontend, basta clonar o projeto na máquina. Depois disso abrir o arquivo solução na pasta (Client.Management.App.sln)

Para rodar o projeto localmente na máquina, basta definir dois projetos de inicialização:

Client.Management.App.Api e o Client.Management.App.Web

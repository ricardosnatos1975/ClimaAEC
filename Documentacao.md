Documentação da Arquitetura do Projeto ClimaAEC
Visão Geral
O projeto ClimaAEC é uma API que fornece informações climáticas para cidades e aeroportos. A API é desenvolvida em C# usando o framework .NET Core e segue uma arquitetura baseada em camadas, com o objetivo de manter o código organizado, modular e de fácil manutenção.

Estrutura de Pastas
A estrutura de pastas do projeto segue o padrão sugerido pelo .NET Core:

ClimaAEC: Pasta raiz do projeto, contém o arquivo Program.cs e Startup.cs.
Controllers: Contém os controladores da API responsáveis por lidar com as requisições HTTP.
Data: Contém as classes relacionadas ao acesso ao banco de dados e configuração do DbContext.
Models: Contém as classes que representam as entidades do domínio da aplicação.
Repositories: Contém as interfaces e implementações dos repositórios que lidam com a persistência dos dados.
Services: Contém a interface e implementação dos serviços responsáveis por fornecer informações climáticas.
Middleware: Contém o middleware de tratamento de erros personalizado da aplicação.
Tests: Contém os testes unitários do projeto.
Camadas da Arquitetura
O projeto ClimaAEC segue uma arquitetura em camadas para garantir a separação de responsabilidades e facilitar a manutenção:

Camada de Apresentação (Controllers): Responsável por lidar com as requisições HTTP e encaminhá-las para as camadas adequadas. Os controladores interagem com a camada de serviços para obter as informações climáticas.

Camada de Serviços (Services): Responsável por fornecer os serviços relacionados às informações climáticas. Os serviços utilizam os repositórios para acessar e persistir os dados.

Camada de Repositórios (Repositories): Responsável por lidar com a persistência dos dados relacionados às informações climáticas. Os repositórios utilizam o DbContext para acessar o banco de dados.

Camada de Acesso a Dados (Data): Responsável pela configuração do DbContext e acesso ao banco de dados usando o Entity Framework Core.

Camada de Domínio (Models): Contém as classes que representam as entidades do domínio da aplicação, como Clima e ClimaAECInfo.

Camada de Testes (Tests): Contém os testes unitários para validar o funcionamento das diferentes camadas da aplicação.

Fluxo de Funcionamento
O cliente (navegador, Postman, etc.) faz uma requisição HTTP para os endpoints da API (controladores).

Os controladores recebem a requisição e encaminham a solicitação para a camada de serviços.

Os serviços interagem com os repositórios para obter ou persistir as informações climáticas.

Os repositórios acessam o banco de dados usando o DbContext para recuperar ou armazenar as informações.

As informações são retornadas para os serviços, que as enviam de volta aos controladores.

Os controladores retornam as informações ao cliente em formato JSON.

Conclusão
A arquitetura do projeto ClimaAEC segue uma abordagem em camadas para garantir uma organização clara do código e facilitar a manutenção e testabilidade. A estrutura de pastas ajuda a manter as diferentes partes do projeto separadas e bem organizadas. Com essa arquitetura, o projeto pode ser facilmente escalável e extensível para atender a futuras necessidades.
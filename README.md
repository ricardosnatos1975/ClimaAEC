Manual de Instalação e Dependências do Projeto ClimaAEC
Este manual fornecerá instruções para instalar e configurar o projeto ClimaAEC em sua máquina local. 
Certifique-se de ter as seguintes dependências instaladas antes de prosseguir:

Dependências
.NET Core SDK - Certifique-se de ter a versão mais recente do SDK .NET Core instalada em sua máquina.
SQL Server - Banco de dados SQL Server para armazenar as informações climáticas.
Git - Controle de versão Git para clonar o repositório do projeto.
Instalação
Clone o repositório do projeto ClimaAEC em sua máquina local usando o Git:
git clone https://github.com/ricardosnatos1975/ClimaAEC.git
Navegue para o diretório do projeto ClimaAEC:
cd ClimaAEC
Abra o arquivo appsettings.json na pasta ClimaAEC e configure a conexão com o banco de dados SQL Server, substituindo SUA_STRING_DE_CONEXAO pelo endereço e credenciais do seu servidor:
json
Copy code
{
  "ConnectionStrings": {
    "DefaultConnection": "SUA_STRING_DE_CONEXAO"
  },
  ...
}
Abra um terminal na pasta ClimaAEC e execute o seguinte comando para criar o banco de dados:
sql
dotnet ef database update
Isso criará o banco de dados com as tabelas necessárias para armazenar as informações climáticas.

Execute o seguinte comando para restaurar as dependências do projeto:
dotnet restore
Finalmente, execute o projeto ClimaAEC com o seguinte comando:
dotnet run
Agora, o servidor estará em execução e você poderá acessar a API pelo navegador ou por meio de ferramentas como Postman.

Uso
A API possui dois endpoints:

GET /api/ClimaAEC/previsao/{codigoCidade} - Obtém e cadastra informações climáticas para uma determinada cidade.
GET /api/ClimaAEC/aeroporto/{icaoCode} - Obtém e cadastra informações climáticas para um determinado aeroporto.
Você pode fazer solicitações para esses endpoints usando o navegador ou o Postman.

Isso conclui o manual de instalação e dependências do projeto ClimaAEC. Se tudo foi configurado corretamente, você agora pode começar a usar a API para obter informações climáticas para cidades e aeroportos.

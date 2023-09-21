# BookMicroservices

<h1>Requisitos para rodar o projeto</h1>
<ul>Ter a SDK do .Net 7 instalada</ul>
<ul>Ter o Docker Desktop instalado</ul>
<ul>ter o dotnet ef tool instalado na versão 7.0.11</ul>

<h1>Como rodar o Projeto</h1>
<p>Acessar a raíz do projeto e rodar o comando docker-compose up para subir o container do RabbitMQ</p>
<p>Acessar o appsettings da api BookConsumer e alterar a connectionString</p>
<p>Acessar a pasta ./BookConsumer e rodar o comando dotnet ef database update para gerar a migração do banco de dados</p>
<p>Acessar a api BookProject e rodar com dotnet run</p>
<p>Acessar o swagger e fazer a requisição para o endpoint Create, esse endpoint criará a fila</p>
<p>Acessar a api BookConsumer e rodar com dotnet run</p>
<p>Com as duas api rodando localmente, você poderá fazer as requisições pela Api BookPubliser e visualizar os dados pela Api BookConsumer</p>

<h1>Tecnologias Utilizadas</h1>
<ul>.NET 7</ul>
<ul>Docker e Docker Desktop</ul>
<ul>Entity Framework</ul>
<ul>Sql Server</ul>
<ul>RabbitMQ</ul>
<ul>MicroService</ul>

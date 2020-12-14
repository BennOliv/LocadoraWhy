# LocadoraWhy
API de uma suposta locadora 

Após baixar, insira no console:
 > >dotnet build
	
 > >dotnet ef database update
 
 
 Link para a Collection do Postman:
 https://documenter.getpostman.com/view/11386630/TVsoJBEJ
 
(Para Melhor visualização da doc. abaixo veja o arquivo raw)

"Objetos Nesta API": [
	"cliente":
	{
		"Id": long,
		"Nome": string,
		"CPF": long,
		"Ativo": bool
	},
	"clienteDTO":
	{
		"Nome": string,
		"CPF": long,
		"Ativo": bool
	},
	"Filme":
	{
		"Id": long,						//Propriedade não utilizada no BodyRequ. do PUT /Filmes/{id}
		"Nome": string,
		"Estoque": int,
		"Precolocacao": double,
		"Ativo": bool
	},
	"LocacaoDTO":
	{
		"Id": long,						//Propriedade não utilizada no BodyRequ. do PUT /Locacao/{id}
		"ClienteId": long,
		"FilmeId": long,
		"ValorMulta": double
	},
	"LocacaoInfoDTO":
	{
		"Id": long,
		"ClienteId": long,
		"FilmeId": long,
		"DataLocacao": Date,			//Pattern de exibição: MM/dd/yyyy
		"DataLimiteDevolucao": DAte,	//Pattern de exibição: MM/dd/yyyy
		"ValorMulta": double
	},
	"NotaDTO":
	{
		"LocacaoId": long,
		"ClienteId": long,
		"FilmeId": long,
		"ValorLocaCao": double,
		"DataLocacao": Date,			//Pattern de exibição: MM/dd/yyyy
		"DataDevolucao": Date,			//Pattern de exibição: MM/dd/yyyy
		"ValorMultaAplicada": double,
		"ValorTotal": double,
		"Observacao": string
	}
]

 
 /api/Clientes

Verbo  Rota  BodyRequ.  BodyResp.   Resultado
							
GET    /     null       [{cliente}] Retorna Lista com Clientes registrados no DB.

GET    /{id} null       {cliente}   Retorna um Cliente em específico.

POST   /     clienteDTO {cliente}   Cadastra um cliente no BD.

PUT    /{id} cliente    {cliente}   Atualiza Cadastro.

DELETE /{id} null       null        Desativa Cadastro.


 /api/Filmes

Verbo  Rota  BodyRequ. BodyResp.   Resultado
							
GET    /     null      [{filme}]   Retorna Lista com Filmes registrados no DB.

GET    /{id} null      {filme}     Retorna um Filme em específico.

POST   /     filme     {filme}     Cadastra um filme no BD.

PUT    /{id} filme     {filme}     Atualiza Cadastro.

DELETE /{id} null      null        Desativa Cadastro.


 /api/Locacaos

Verbo Rota                   BodyRequ.    BodyResp.         Resultado
			 				
GET   /                      null        [{LocacaoInfoDTO}]  Retorna Lista com Locações registradas no DB.

GET   /{id}                  null         {LocacaoInfoDTO}   Retorna uma Locação em específico.

POST  /                     {LocacaoDTO}  {LocacaoInfoDTO}   Cadastra uma Locação no BD.

PUT   /{id}                 {LocacaoDTO}  {LocacaoInfoDTO}   Atualiza Cadastro.

GET   /Devolver/{id}         null         {NotaDTO}          Devolve Filme.

GET   /DevolverAtrasado/{id} null         {NotaDTO}          Devolve Filme com atraso.
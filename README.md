# LocadoraWhy
API de uma suposta locadora 

Após baixar, insira no console:
 > dotnet build
	
 > dotnet ef database update

/api/Cliente

Verbo  Rota  BodyRequ. BodyResp.   Resultado
							
GET    /     null      [{cliente}] Retorna Lista com Clientes registrados no DB.

GET    /{id} null      {cliente}   Retorna um Cliente em específico.

POST   /     cliente   {cliente}   Cadastra um cliente no BD.

PUT    /{id} cliente   {cliente}   Atualiza Cadastro.

DELETE /{id} null      null        Desativa Cadastro.

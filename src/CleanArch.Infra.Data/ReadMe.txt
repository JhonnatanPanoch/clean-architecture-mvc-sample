Camada de Infraestrutura 
- A camada de infraestrutura é a camada mais externa da arquitetura que lida com as
necessidades de infraestrutura e fornece a implementação de suas interfaces de repositório.
É nesta camada que conectamos a lógica de acesso a dados ou a lógica de chamadas de
serviço. Apenas a camada de infraestrutura deve saber sobre o banco de dados e a
tecnologia de acesso a dados (Entityframework,ADO.NET, etc.), as demais camadas não
devem saber nada sobre de onde vêm os dados e como estão sendo armazenados.


- Context: Onde vamos definir o contexto da aplicação (DbContext) e mapeamento ORM
	Na abordagem Code-First o EF Core segue convenções para gerar o banco de dados e as tabelas
	O banco de dados será gerado com base no provedor informado e na string de conexão
	Para gerar as tabelas ele verifica as entidades mapeadas no arquivo de contexto (ApplicationDbContext)
	E gera as tabelas no banco de dados com os nomes definidos no mapeamento
	Com base nas propriedades definidas no modelo de domínio ele gera as colunas das tabelas com o mesmo nome das propriedades
		
	- Problemas
		O tipo de dado string será mapeado para uma coluna do tipo nvarchar(max) e nullable igual a true
		O tipo de decimal será mapeado para uma coluna do tipo decimal(18,2) e será emitida uma mensagem de alerta para perda de dados por problemas de precisão

- EntitiesConfiguration: Onde vamos definir as configurações(Fluent API) das entidades do contexto;
- Repositories: Onde vamos implementar as interfaces dos repositórios para category e product;
- Identity: Onde definimos as configurações e os recursos de autenticação e autorização do Identity;

- Referência aos pacotes Nuget :
Microsoft.EntityFrameworkcore.SqlServer
Microsoft.EntityFrameworkcore.Tools
Microsoft.EntityFrameworkcore.Design
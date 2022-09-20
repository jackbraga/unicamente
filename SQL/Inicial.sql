
CREATE TABLE tbRecipiente
(
	ID INT PRIMARY KEY IDENTITY,
	Descricao VARCHAR(100) NOT NULL,
	Volume	DECIMAL(10,2),
	Imagem	VARCHAR(MAX),
	QtdReuso	INT
)
GO
INSERT INTO tbRecipiente VALUES('Garrafa',2.00,'Garrafa.png',1)
INSERT INTO tbRecipiente VALUES('Vidro',3.40,'vidro.png',3)
INSERT INTO tbRecipiente VALUES('Vidro',3.20,'vidro2.png',3)

-------~~~~~~~~~~~~~~~~~------
-------~~~~~~~~~~~~~~~~~------
-------~~~~~~~~~~~~~~~~~------

CREATE TABLE tbMariri
(
	ID INT PRIMARY KEY IDENTITY,
	Descricao VARCHAR(200) NOT NULL,
	Imagem	  VARCHAR(MAX)
)
GO
INSERT INTO tbMariri VALUES('Tucunacá','tucunaca.png')
INSERT INTO tbMariri VALUES('Caupuri','Caupuri.png')
INSERT INTO tbMariri VALUES('Caupuri + Tucunacá','tucunaca_caupuri.png')
INSERT INTO tbMariri VALUES('Amarelinho','amarelinho.png')
-------~~~~~~~~~~~~~~~~~------
-------~~~~~~~~~~~~~~~~~------
-------~~~~~~~~~~~~~~~~~------
CREATE TABLE tbChacrona
(
	ID INT PRIMARY KEY IDENTITY,
	Descricao VARCHAR(200) NOT NULL,
	Imagem	  VARCHAR(MAX)
)

GO
INSERT INTO tbChacrona VALUES('Chacrona','Chacrona.png')
INSERT INTO tbChacrona VALUES('Chacroninha','Chacroninha.png')
-------~~~~~~~~~~~~~~~~~------
-------~~~~~~~~~~~~~~~~~------
-------~~~~~~~~~~~~~~~~~------
CREATE TABLE tbVegetal
(
	ID INT PRIMARY KEY IDENTITY,
	Descricao VARCHAR(255) NOT NULL,
	IDMariri INT NOT NULL FOREIGN KEY REFERENCES tbMariri(ID),
	IDChacrona INT NULL FOREIGN KEY REFERENCES tbChacrona(ID),
	MestrePreparo VARCHAR(255),
	DataPreparoRetorno DATETIME,
	Observacao VARCHAR(MAX)
)
GO
INSERT INTO tbVegetal VALUES('PREP. IPIAÚ M. CLÁUDIO 2° Apuro',1,1,'Mestre Cláudio',GETDATE(),NULL)
INSERT INTO tbVegetal VALUES('PREP. NSJB M. EDSON',1,1,'Mestre Edson Romão',GETDATE(),NULL)
INSERT INTO tbVegetal VALUES('PREP. NOVA SERRANA - NOVO',1,1,'Mestre Gabriel',GETDATE(),NULL)

-------~~~~~~~~~~~~~~~~~------
-------~~~~~~~~~~~~~~~~~------
-------~~~~~~~~~~~~~~~~~------
CREATE TABLE tbTipoMovimentoVegetal
(
	ID INT PRIMARY KEY IDENTITY,
	Descricao VARCHAR(100)
)
GO
INSERT INTO tbTipoMovimentoVegetal VALUES('Entrada')
INSERT INTO tbTipoMovimentoVegetal VALUES('Consumo em Sessão')
INSERT INTO tbTipoMovimentoVegetal VALUES('Doação')
INSERT INTO tbTipoMovimentoVegetal VALUES('Desperdicio')
-------~~~~~~~~~~~~~~~~~------
-------~~~~~~~~~~~~~~~~~------
-------~~~~~~~~~~~~~~~~~------
CREATE TABLE tbMovimentoVegetal
(
	ID INT PRIMARY KEY IDENTITY,
	IDVegetal INT FOREIGN KEY REFERENCES tbVegetal(ID),
	IDRecipiente INT FOREIGN KEY REFERENCES tbRecipiente(ID),
	TipoMovimento	INT FOREIGN KEY REFERENCES tbTipoMovimentoVegetal(ID),
	DataMovimento DATETIME,
	Litros	DECIMAL(10,2),
	Retorno BIT,
	Imagem VARCHAR(MAX),
	Observacao VARCHAR(MAX)
)
GO
INSERT INTO tbMovimentoVegetal VALUES(1,1,1,GETDATE(),10.00,0,'vegetal.png','Coisa boa é vegetal')
INSERT INTO tbMovimentoVegetal VALUES(1,1,2,GETDATE(),5.00,0,NULL,NULL)

INSERT INTO tbMovimentoVegetal VALUES(2,2,1,GETDATE(),10.00,0,'vegetal2.png','Coisa magnifica é vegetal')
-------~~~~~~~~~~~~~~~~~------
-------~~~~~~~~~~~~~~~~~------
-------~~~~~~~~~~~~~~~~~------

CREATE TABLE tbTipoSessao
(
	ID INT PRIMARY KEY IDENTITY,	
	Descricao VARCHAR(100)
)
GO
INSERT INTO tbTipoSessao VALUES('Sessão de Escala')
INSERT INTO tbTipoSessao VALUES('Sessão de Escala Anual')
INSERT INTO tbTipoSessao VALUES('Sessão Extra')
INSERT INTO tbTipoSessao VALUES('Sessão Instrutiva')
INSERT INTO tbTipoSessao VALUES('Sessão de Caráter Instrutivo')
INSERT INTO tbTipoSessao VALUES('Sessão da Direção')
INSERT INTO tbTipoSessao VALUES('Sessão do Quadro de Mestres')
-------~~~~~~~~~~~~~~~~~------
-------~~~~~~~~~~~~~~~~~------
-------~~~~~~~~~~~~~~~~~------

CREATE TABLE tbSessao
(
	ID INT PRIMARY KEY IDENTITY,	
	IDTipoSessao INT  FOREIGN KEY REFERENCES tbTipoSessao(ID),
	Dirigente	VARCHAR(255),
	Documentos	VARCHAR(255),
	Explanação	VARCHAR(255),
	QuartoLugar	VARCHAR(255),
	QtdPessoas	INT,
	DataSessao	DATETIME
)
GO
INSERT INTO tbSessao VALUES(1,'Mestre Edson Romão','Jackson Braga','Daniel Martins','Wellington Criniti',100,GETDATE())
-------~~~~~~~~~~~~~~~~~------
-------~~~~~~~~~~~~~~~~~------
-------~~~~~~~~~~~~~~~~~------

CREATE TABLE tbSessaoVegetal
(
	ID INT PRIMARY KEY IDENTITY,
	IDSessao INT  FOREIGN KEY REFERENCES tbSessao(ID),	
	IDVegetal INT  FOREIGN KEY REFERENCES tbVegetal(ID),	
	Litros	DECIMAL(10,2)
)
GO
INSERT INTO tbSessaoVegetal VALUES(1,1,5.00)
-------~~~~~~~~~~~~~~~~~------
-------~~~~~~~~~~~~~~~~~------
-------~~~~~~~~~~~~~~~~~------


SELECT A.Descricao,SUM(B.Litros) as Litros
FROM tbVegetal					AS A
INNER JOIN	tbMovimentoVegetal	AS B ON B.IDVegetal=A.ID
GROUP BY A.Descricao

SELECT * FROM tbVegetal
SELECT * FROM tbMovimentoVegetal

SELECT * FROM tbMovimentoVegetal

CREATE TABLE tbRecipiente
(
	ID INT IDENTITY PRIMARY KEY,
	Descricao VARCHAR(50) NOT NULL,
	Volume DECIMAL(2,1),
	QuantidadeReuso INT,
	Observacao VARCHAR(100),
	Imagem VARBINARY(MAX)
)
drop table tbRecipiente
select * from tbRecipiente
CREATE TABLE tbMariri
(
	ID INT IDENTITY PRIMARY KEY,
	Descricao VARCHAR(50) NOT NULL,
	Observacao VARCHAR(100),
	Imagem VARBINARY(MAX)
)

CREATE TABLE tbChacrona
(
	ID INT IDENTITY PRIMARY KEY,
	Descricao VARCHAR(50) NOT NULL,
	Observacao VARCHAR(100),
	Imagem VARBINARY(MAX)
)

CREATE TABLE tbVegetal
(
		ID INT IDENTITY PRIMARY KEY,
		Descricao VARCHAR(50) NOT NULL,
		MestrePreparo VARCHAR(50),
		DataPreparo DATETIME,
		IDMariri INT FOREIGN KEY REFERENCES tbMariri(ID),
		IDChacrona INT FOREIGN KEY REFERENCES tbChacrona(ID),
		Observacao VARCHAR(100),
		Imagem VARBINARY(MAX)
)
drop table tbVegetal


delete from tbRecipiente


SELECT 
A.ID,A.Descricao,A.MestrePreparo,A.DataPreparo,A.Observacao,A.Imagem,
B.ID AS IDMariri,B.Descricao,
C.ID as IDChacrona,C.Descricao
FROM tbVegetal AS A
INNER JOIN tbMariri AS B ON B.ID=A.IDMariri
LEFT JOIN tbChacrona AS C ON C.ID=A.IDChacrona


select * from tbMariri


CREATE TABLE tbTipoSess�o
(
	ID INT PRIMARY KEY,
	Descricao VARCHAR(50) NOT NULL
)
GO
INSERT INTO tbTipoSess�o VALUES (1,'Escala')
INSERT INTO tbTipoSess�o VALUES(2,'Escala Anual');
INSERT INTO tbTipoSess�o VALUES(3,'Extra');
INSERT INTO tbTipoSess�o VALUES(4,'Instrutiva');
INSERT INTO tbTipoSess�o VALUES(5,'Carater Instrutivo');
INSERT INTO tbTipoSess�o VALUES(6,'Dire��o');
INSERT INTO tbTipoSess�o VALUES(7,'Quadro de Mestres');
)
GO

CREATE TABLE tbSess�o
(
	ID INT IDENTITY PRIMARY KEY,

)
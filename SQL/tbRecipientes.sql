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


CREATE TABLE tbTipoSessão
(
	ID INT PRIMARY KEY,
	Descricao VARCHAR(50) NOT NULL
)
GO
INSERT INTO tbTipoSessão VALUES (1,'Escala')
INSERT INTO tbTipoSessão VALUES(2,'Escala Anual');
INSERT INTO tbTipoSessão VALUES(3,'Extra');
INSERT INTO tbTipoSessão VALUES(4,'Instrutiva');
INSERT INTO tbTipoSessão VALUES(5,'Carater Instrutivo');
INSERT INTO tbTipoSessão VALUES(6,'Direção');
INSERT INTO tbTipoSessão VALUES(7,'Quadro de Mestres');
)
GO

CREATE TABLE tbSessão
(
	ID INT IDENTITY PRIMARY KEY,

)
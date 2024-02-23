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
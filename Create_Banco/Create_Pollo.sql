CREATE TABLE Pollo_Pergunta(
cod_pergunta	INT		PRIMARY KEY 	IDENTITY(1,1),
pergunta		VARCHAR(50)
);

CREATE TABLE Pollo_Usuario (
cod_usuario		INT 	PRIMARY KEY 	IDENTITY(1000,1),
nome 			VARCHAR(50),
data_nasc 		VARCHAR(10), 
sexo			VARCHAR(10),
celular 	    VARCHAR(14),
user_pollo		VARCHAR(30),
email 			VARCHAR(50),
senha 			VARCHAR(50),
cod_pergunta 	INT 	FOREIGN KEY 	REFERENCES Pollo_Pergunta(cod_pergunta),
rec_resposta 	VARCHAR(50)
);

CREATE TABLE Pollo_Tamanho_Ovo(
cod_tamanho	INT		PRIMARY KEY 		IDENTITY(1,1),
tamanho		VARCHAR(50),
cod_usuario		INT 	FOREIGN KEY 	REFERENCES Pollo_Usuario(cod_usuario)
);

CREATE TABLE Pollo_Ovo(
cod_ovo 		INT 	PRIMARY KEY 	IDENTITY(1000,1),
tipo			VARCHAR(20),
tamanho 		INT 	FOREIGN KEY 	REFERENCES Pollo_Tamanho_Ovo(cod_tamanho),
temperatura 	DECIMAL,
tempo_dia		INT,
cod_usuario		INT 	FOREIGN KEY 	REFERENCES Pollo_Usuario(cod_usuario)
);

CREATE TABLE Pollo_Chocadeira(
cod_chocadeira 	INT 	PRIMARY KEY 	IDENTITY (1000,1),
nome_chocadeira VARCHAR (50),
cod_ovo 		INT 	FOREIGN KEY 	REFERENCES Pollo_Ovo(cod_ovo),
quantidade_ovos INT,
inicio			DATE,
final			DATE,	
cod_usuario		INT 	FOREIGN KEY 	REFERENCES Pollo_Usuario(cod_usuario)
	
);

-- DROP TABLE Pollo_Tamanho_Ovo
-- DROP TABLE Pollo_Pergunta
-- DROP TABLE Pollo_Ovo
-- DROP TABLE Pollo_Chocadeira
-- DROP TABLE Pollo_Usuario
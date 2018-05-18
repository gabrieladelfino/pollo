CREATE TABLE Pollo_Usuario (
cod_usuario		INT 	PRIMARY KEY 	IDENTITY(1000,1),
nome 			VARCHAR(50),
data_nasc 		DATE, 
cpf 			VARCHAR(14),
celular 	    VARCHAR(14),
user_pollo		VARCHAR(30),
email 			VARCHAR(50),
senha 			VARCHAR(50),
rec_pergunta 	VARCHAR(50),
rec_resposta 	VARCHAR(50)
);

CREATE TABLE Pollo_Ovo(
cod_ovo 		INT 	PRIMARY KEY 	IDENTITY(1000,1),
tipo			VARCHAR(20),
tamanho 		VARCHAR(10),
temperatura 	DECIMAL,
tempo_dia		INT,
cod_usuario		INT 	FOREIGN KEY 	REFERENCES Pollo_Usuario(cod_usuario)
);


CREATE TABLE Pollo_Chocadeira(
cod_chocadeira 	INT 	PRIMARY KEY 	IDENTITY (1000,1),
nome_chocadeira VARCHAR (50),
cod_ovo 		INT 	FOREIGN KEY 	REFERENCES Pollo_Ovo(cod_ovo),
quantidade_ovos INT,
cod_usuario		INT 	FOREIGN KEY 	REFERENCES Pollo_Usuario(cod_usuario)
);


Server=tcp:cyberbitchs.database.windows.net,1433;Initial Catalog=Primeiro_Banco;Persist Security Info=False;User ID=cyberbitchs;Password=Teste<code/>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;



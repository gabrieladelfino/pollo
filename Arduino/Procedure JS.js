"	DECLARE\n"+
"	@total_min INT, @total_hora INT, @total_dia INT, @media_hora_60 FLOAT, @media_hora_120 FLOAT, @media_hora_180 FLOAT, @media_dia_24 FLOAT, @media_dia_48 FLOAT, @media_dia_72 FLOAT, @media_mes_30 FLOAT, @media_mes_60 FLOAT, @media_mes_90 FLOAT, @cont_min INT,@cont_hora INT,@cont_dia INT \n"+

"	SELECT @cont_min = minuto FROM Contador;\n"+
"	SELECT @cont_hora= hora FROM Contador;\n"+
"	SELECT @cont_dia = dia FROM Contador;\n"+

"	SELECT @total_min = COUNT(*) FROM Pollo_Media_Minuto;\n"+
"	SELECT @total_hora= COUNT(*) FROM Pollo_Media_Hora;\n"+
"	SELECT @total_dia = COUNT(*) FROM Pollo_Media_Dia;\n"+

"	SELECT @media_hora_60 = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto <= 60;\n"+
"	SELECT @media_hora_120 = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto >=61 AND minuto <= 120;\n"+
"	SELECT @media_hora_180 = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto >=121 AND minuto <= 180;\n"+

"	SELECT @media_dia_24 = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto <= 24;\n"+
"	SELECT @media_dia_48 = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto >=25 AND minuto <= 48;\n"+
"	SELECT @media_dia_72 = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto >=49 AND minuto <= 72;\n"+

"	SELECT @media_mes_30 = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto <= 30;\n"+
"	SELECT @media_mes_60 = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto >=31 AND minuto <= 60;\n"+
"	SELECT @media_mes_90 = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto >=61 AND minuto <= 90;\n"+

"	IF @total_min < 180\n"+
"		BEGIN\n"+
"			INSERT INTO Pollo_Media_Minuto (temperatura) VALUES (@temperatura);\n"+
"				IF @total_min = 1\n"+
"				BEGIN\n"+
"					UPDATE Contador SET minuto = 1; \n"+
"				END\n"+
"				IF @total_min > 1\n"+
"				BEGIN\n"+
"					UPDATE Contador SET minuto = minuto + 1; \n"+
"				END\n"+
"		END\n"+

"	IF @total_min = 180\n"+
"		BEGIN\n"+
"			UPDATE Pollo_Media_Minuto SET temperatura = @temperatura;\n"+
"			UPDATE Contador SET minuto = minuto + 1;\n"+
"		END\n"+
"		
"	IF @cont_min = 60\n"+
"		BEGIN\n"+
"			INSERT INTO Pollo_Media_Hora VALUES(@media_hora_60);\n"+
"		END\n"+
"
"	IF @cont_min = 120\n"+
"		BEGIN\n"+
"			INSERT INTO Pollo_Media_Hora VALUES(@media_hora_120);\n"+
"		END\n"+

"	IF @cont_min = 180\n"+
"		BEGIN\n"+
"			INSERT INTO Pollo_Media_Hora VALUES(@media_hora_180);\n"+
"			 UPDATE Contador SET minuto = 1;\n"+
"		END\n"+

"	IF @total_hora < 72\n"+
"		BEGIN\n"+
"			IF @total_hora = 1\n"+
"			BEGIN\n"+
"				UPDATE Contador SET hora = 1; \n"+
"			END\n"+
"			IF @total_hora > 1\n"+
"			BEGIN\n"+
"				UPDATE Contador SET hora = hora + 1; \n"+
"			END\n"+
"		END\n"+
		
"	IF @total_hora = 72\n"+
"		BEGIN\n"+
"			UPDATE Pollo_Media_Hora SET temperatura = @temperatura;\n"+
"			UPDATE Contador SET hora = hora + 1;\n"+
"		END\n"+
		
"	IF @cont_hora = 24\n"+
"		BEGIN\n"+
"			INSERT INTO Pollo_Media_Hora VALUES(@media_dia_24);\n"+
"		END\n"+

"	IF @cont_hora = 48\n"+
"		BEGIN\n"+
"			INSERT INTO Pollo_Media_Hora VALUES(@media_dia_48);\n"+
"		END\n"+
"
"	IF @cont_hora = 72\n"+
"		BEGIN\n"+
"			INSERT INTO Pollo_Media_Hora VALUES(@media_dia_72);\n"+
"			 UPDATE Contador SET i = 1;\n"+
"		END\n"+

"	IF @total_dia < 90\n"+
"		BEGIN\n"+
"			INSERT INTO Pollo_Media_Dia (temperatura) VALUES (@temperatura);\n"+
"				IF @total_dia = 1\n"+
"				BEGIN\n"+
"					UPDATE Contador SET hora = 1; \n"+
"				END\n"+
"				IF @total_dia > 1\n"+
"				BEGIN\n"+
"					UPDATE Contador SET hora = hora + 1; \n"+
"				END\n"+
"		END\n"+

"	IF @total_dia = 90\n"+
"		BEGIN\n"+
"			UPDATE Pollo_Media_Dia SET temperatura = @temperatura;\n"+
"			UPDATE Contador SET hora = hora + 1;\n"+
"		END\n"+

"	IF @cont_hora = 30\n"+
"		BEGIN\n"+
"			INSERT INTO Pollo_Media_Dia VALUES(@media_mes_30);\n"+
"		END\n"+

"	IF @cont_hora = 60\n"+
"		BEGIN\n"+
"			INSERT INTO Pollo_Media_Dia VALUES(@media_mes_60);\n"+
"		END\n"+

"	IF @cont_hora = 90\n"+
"		BEGIN\n"+
"			INSERT INTO Pollo_Media_Dia VALUES(@media_mes_90);\n"+
"			 UPDATE Contador SET hora = 1;\n"+
"		END"
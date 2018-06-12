	DECLARE
	@total_min INT, @total_hora INT, @total_dia INT, @media_hora_60 FLOAT, @media_hora_120 FLOAT, @media_hora_180 FLOAT, @media_dia_24 FLOAT, @media_dia_48 FLOAT, @media_dia_72 FLOAT, @media_mes_30 FLOAT, @media_mes_60 FLOAT, @media_mes_90 FLOAT, @cont_min INT,@cont_hora INT,@cont_dia INT

	SELECT @cont_min = minuto FROM Contador;
	SELECT @cont_hora= hora FROM Contador;
	SELECT @cont_dia = dia FROM Contador;

	SELECT @total_min = COUNT(*) FROM Pollo_Media_Minuto;
	SELECT @total_hora= COUNT(*) FROM Pollo_Media_Hora;
	SELECT @total_dia = COUNT(*) FROM Pollo_Media_Dia;

	SELECT @media_hora_60 = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto <= 60;
	SELECT @media_hora_120 = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto >=61 AND minuto <= 120;
	SELECT @media_hora_180 = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto >=121 AND minuto <= 180;

	SELECT @media_dia_24 = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto <= 24;
	SELECT @media_dia_48 = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto >=25 AND minuto <= 48;
	SELECT @media_dia_72 = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto >=49 AND minuto <= 72;

	SELECT @media_mes_30 = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto <= 30;
	SELECT @media_mes_60 = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto >=31 AND minuto <= 60;
	SELECT @media_mes_90 = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto >=61 AND minuto <= 90;

	--Minuto --> Hora
	IF @total_min < 180
		BEGIN
			INSERT INTO Pollo_Media_Minuto (temperatura) VALUES (@temperatura);
				IF @total_min = 1
				BEGIN
					UPDATE Contador SET minuto = 1; 
				END
				IF @total_min > 1
				BEGIN
					UPDATE Contador SET minuto = minuto + 1; 
				END
		END
		
	IF @total_min = 180
		BEGIN
			UPDATE Pollo_Media_Minuto SET temperatura = @temperatura;
			UPDATE Contador SET minuto = minuto + 1; ;
		END
		
	IF @cont_min = 60
		BEGIN
			INSERT INTO Pollo_Media_Hora VALUES(@media_hora_60);
		END

	IF @cont_min = 120
		BEGIN
			INSERT INTO Pollo_Media_Hora VALUES(@media_hora_120);
		END

	IF @cont_min = 180
		BEGIN
			INSERT INTO Pollo_Media_Hora VALUES(@media_hora_180);
			 UPDATE Contador SET minuto = 1;
		END
		
	--Hora --> Dia
	IF @total_hora < 72
		BEGIN
			IF @total_hora = 1
			BEGIN
				UPDATE Contador SET hora = 1; 
			END
			IF @total_hora > 1
			BEGIN
				UPDATE Contador SET hora = hora + 1; 
			END
		END
		
	IF @total_hora = 72
		BEGIN
			UPDATE Pollo_Media_Hora SET temperatura = @temperatura;
			UPDATE Contador SET hora = hora + 1; ;
		END
		
	IF @cont_hora = 24
		BEGIN
			INSERT INTO Pollo_Media_Hora VALUES(@media_dia_24);
		END

	IF @cont_hora = 48
		BEGIN
			INSERT INTO Pollo_Media_Hora VALUES(@media_dia_48);
		END

	IF @cont_hora = 72
		BEGIN
			INSERT INTO Pollo_Media_Hora VALUES(@media_dia_72);
			 UPDATE Contador SET i = 1;
		END
		
	--Dia --> Mês

	IF @total_dia < 90
		BEGIN
			INSERT INTO Pollo_Media_Dia (temperatura) VALUES (@temperatura);
				IF @total_dia = 1
				BEGIN
					UPDATE Contador SET hora = 1; 
				END
				IF @total_dia > 1
				BEGIN
					UPDATE Contador SET hora = hora + 1; 
				END
		END
		
	IF @total_dia = 90
		BEGIN
			UPDATE Pollo_Media_Dia SET temperatura = @temperatura;
			UPDATE Contador SET hora = hora + 1; ;
		END
		
	IF @cont_hora = 30
		BEGIN
			INSERT INTO Pollo_Media_Dia VALUES(@media_mes_30);
		END

	IF @cont_hora = 60
		BEGIN
			INSERT INTO Pollo_Media_Dia VALUES(@media_mes_60);
		END

	IF @cont_hora = 90
		BEGIN
			INSERT INTO Pollo_Media_Dia VALUES(@media_mes_90);
			 UPDATE Contador SET hora = 1;
		END
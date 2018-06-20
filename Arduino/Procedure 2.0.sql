	DECLARE
	@total_min INT, @total_hora INT, @total_dia INT, @media_hora_60 FLOAT, @media_hora_120 FLOAT, @media_hora_180 FLOAT, @media_dia_24 FLOAT, @media_dia_48 FLOAT, @media_dia_72 FLOAT, @media_mes_30 FLOAT, @media_mes_60 FLOAT, @media_mes_90 FLOAT, @cont_min INT,@cont_hora INT,@cont_dia INT

	SELECT @cont_min = minuto FROM Contador;
	SELECT @cont_hora= hora FROM Contador;
	SELECT @cont_dia = dia FROM Contador;

	SELECT @total_min = COUNT(*) FROM Pollo_Media_Minuto;
	SELECT @total_hora= COUNT(*) FROM Pollo_Media_Hora;
	SELECT @total_dia = COUNT(*) FROM Pollo_Media_Dia;

	SELECT @media_minuto_60  = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto <= 60;
	SELECT @media_minuto_120 = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto >= 61  AND minuto <= 120;
	SELECT @media_minuto_180 = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto >= 121 AND minuto <= 180;

	SELECT @media_hora_24 = AVG(temperatura) FROM Pollo_Media_Hora WHERE hora <= 24;
	SELECT @media_hora_48 = AVG(temperatura) FROM Pollo_Media_Hora WHERE hora >= 25 AND hora <= 48;
	SELECT @media_hora_72 = AVG(temperatura) FROM Pollo_Media_Hora WHERE hora >= 49 AND hora <= 72;

	SELECT @media_dia_30 = AVG(temperatura) FROM Pollo_Media_Dia WHERE dia <=30;
	SELECT @media_dia_60 = AVG(temperatura) FROM Pollo_Media_Dia WHERE dia >=31 AND dia <= 60;
	SELECT @media_dia_90 = AVG(temperatura) FROM Pollo_Media_Dia WHERE dia >=61 AND dia <= 90;

	--Arduino --> Minuto
	IF @total_min < 180
		BEGIN
			INSERT INTO Pollo_Media_Minuto (temperatura) VALUES (@temperatura);
				IF @total_min = 1
				BEGIN
					UPDATE Contador SET minuto = 1; 
				END
				--ACHO QUE PODE TIRAR ISSO
				-- IF @total_min > 1
				-- BEGIN
					-- UPDATE Contador SET minuto = minuto + 1; 
				-- END
		END
		
	IF @total_min = 180
		BEGIN
			UPDATE Pollo_Media_Minuto SET temperatura = @temperatura WHERE minuto = @cont_min;
			UPDATE Contador SET minuto = minuto + 1;
			IF @cont_min = 180
				BEGIN
					UPDATE Contador SET minuto = 1;
				END
		END
	
		
	 --Minuto--> Hora
		IF @total_hora = 72
			BEGIN
				IF @cont_min = 60
					BEGIN 
						UPDATE Pollo_Media_Hora SET temperatura = @media_minuto_60 WHERE hora = @cont_hora;
						UPDATE Contador SET hora = hora + 1;
					END
				IF @cont_min= 120
					BEGIN 
						UPDATE Pollo_Media_Hora SET temperatura = @media_minuto_120 WHERE hora = @cont_hora;
						UPDATE Contador SET hora = hora + 1;
					END
				IF @cont_min= 180
					BEGIN 
						UPDATE Pollo_Media_Hora SET temperatura = @media_minuto_180 WHERE hora = @cont_hora;
						UPDATE Contador SET hora = hora + 1;
					END
				IF @cont_hora = 72
					BEGIN
						UPDATE Contador SET hora = 1;
					END
			END
		
		ELSE
			BEGIN
				IF @cont_min = 60
					BEGIN 
						INSERT INTO Pollo_Media_Hora VALUES(@media_minuto_60);
					END
				IF @cont_min = 120
					BEGIN 
						INSERT INTO Pollo_Media_Hora VALUES(@media_minuto_120);
					END
				IF @cont_min = 180
					BEGIN 
						INSERT INTO Pollo_Media_Hora VALUES(@media_minuto_180);
					END
			END
			
	--Hora --> Dia
	IF @total_dia = 90
			BEGIN
				IF @cont_hora = 24
					BEGIN 
						UPDATE Pollo_Media_Dia SET temperatura = @media_hora_24 WHERE dia = @cont_dia;
						UPDATE Contador SET dia = dia + 1;
					END
				IF @cont_hora= 48
					BEGIN 
						UPDATE Pollo_Media_Dia SET temperatura = @media_hora_48 WHERE dia = @cont_dia;
						UPDATE Contador SET dia = dia + 1;
					END
				IF @cont_hora= 72
					BEGIN 
						UPDATE Pollo_Media_Dia SET temperatura = @media_hora_72 WHERE dia = @cont_dia;
						UPDATE Contador SET dia = dia + 1;
					END
				IF @cont_dia = 90
					BEGIN
						UPDATE Contador SET dia = 1;
					END
			END
		
		ELSE
			BEGIN
				IF @cont_hora = 24
					BEGIN 
						INSERT INTO Pollo_Media_Dia VALUES(@media_hora_24);
					END
				IF @cont_hora = 48
					BEGIN 
						INSERT INTO Pollo_Media_Dia VALUES(@media_hora_48);
					END
				IF @cont_hora = 72
					BEGIN 
						INSERT INTO Pollo_Media_Dia VALUES(@media_hora_72);
					END
			END
	
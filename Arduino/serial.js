const SerialPort = require('serialport');
const Readline = SerialPort.parsers.Readline;

class ArduinoDataRead {

    constructor(){
        this.listData = [];
    }

    get List() {
        return this.listData;
    }

    SetConnection(){

        SerialPort.list().then(listSerialDevices => {
            
            let listArduinoSerial = listSerialDevices.filter(serialDevice => {
                return serialDevice.vendorId == 2341 && serialDevice.productId == 43;
            });
            
            if (listArduinoSerial.length != 1){
                throw new Error("The Arduino was not connected or has many boards connceted");
            }

            console.log("Arduino found in the com %s", listArduinoSerial[0].comName);
             
            return  listArduinoSerial[0].comName;
            
        }).then(arduinoCom => {
            
            let arduino = new SerialPort(arduinoCom, {baudRate: 9600});
            
            const parser = new Readline();
            arduino.pipe(parser);
            
            parser.on('data', (data) => {
				inserirRegistro(data);
                this.listData.push(parseFloat(data));
            });
            
        }).catch(error => console.log(error));
    } 
}

const serial = new ArduinoDataRead();
serial.SetConnection();

module.exports.ArduinoData = {List: serial.List} 



	var Connection = require('tedious').Connection;  
    var config = {  
        userName: 'cyberbitchs',  
        password: 'Teste<code/>',  
        server: 'cyberbitchs.database.windows.net',  
        // If you are on Microsoft Azure, you need this:  
        options: {encrypt: true, database: 'Primeiro_Banco'}  
    };  
    var connection = new Connection(config);  
    connection.on('connect', function(err) {  
		if (err) {
			console.error('Erro ao tentar conexão com banco '+err);
		} else {
			console.log("Conectado com o SQL Server");  
		}
    }); 
	
	
	var Request = require('tedious').Request  
    var TYPES = require('tedious').TYPES;  

    function inserirRegistro(temperatura) {  
        request = new Request("DECLARE\n"+	
		"@total_min INT, @total_hora INT, @total_dia INT, @media_hora_60 FLOAT, @media_hora_120 FLOAT, @media_hora_180 FLOAT, @media_dia_24 FLOAT, @media_dia_48 FLOAT, @media_dia_72 FLOAT, @media_mes_30 FLOAT, @media_mes_60 FLOAT, @media_mes_90 FLOAT, @cont_min INT,@cont_hora INT,@cont_dia INT \n"+

	"	SELECT @cont_min = minuto FROM Contador;\n"+
	"	SELECT @cont_hora= hora FROM Contador;\n"+
	"	SELECT @cont_dia = dia FROM Contador;\n"+
	"\n"+
	"	SELECT @total_min = COUNT(*) FROM Pollo_Media_Minuto;\n"+
	"	SELECT @total_hora= COUNT(*) FROM Pollo_Media_Hora;\n"+
	"	SELECT @total_dia = COUNT(*) FROM Pollo_Media_Dia;\n"+
	"\n"+
	"	SELECT @media_minuto_60  = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto <= 60;\n"+
	"	SELECT @media_minuto_120 = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto >= 61  AND minuto <= 120;\n"+
	"	SELECT @media_minuto_180 = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto >= 121 AND minuto <= 180;\n"+
	"\n"+
	"	SELECT @media_hora_24 = AVG(temperatura) FROM Pollo_Media_Hora WHERE hora <= 24;\n"+
	"	SELECT @media_hora_48 = AVG(temperatura) FROM Pollo_Media_Hora WHERE hora >= 25 AND hora <= 48;\n"+
	"	SELECT @media_hora_72 = AVG(temperatura) FROM Pollo_Media_Hora WHERE hora >= 49 AND hora <= 72;\n"+
	"\n"+
	"	SELECT @media_dia_30 = AVG(temperatura) FROM Pollo_Media_Dia WHERE dia <=30;\n"+
	"	SELECT @media_dia_60 = AVG(temperatura) FROM Pollo_Media_Dia WHERE dia >=31 AND dia <= 60;\n"+
	"	SELECT @media_dia_90 = AVG(temperatura) FROM Pollo_Media_Dia WHERE dia >=61 AND dia <= 90;\n"+
	"\n"+
	"	IF @total_min < 180\n"+
	"		BEGIN\n"+
	"			INSERT INTO Pollo_Media_Minuto (temperatura) VALUES (@temperatura);\n"+
	"				IF @total_min = 1\n"+
	"				BEGIN\n"+
	"					UPDATE Contador SET minuto = 1; \n"+
	"				END\n"+
	"		END\n"+
	"		\n"+
	"	IF @total_min = 180\n"+
	"		BEGIN\n"+
	"			UPDATE Pollo_Media_Minuto SET temperatura = @temperatura WHERE minuto = @cont_min;\n"+
	"			UPDATE Contador SET minuto = minuto + 1;\n"+
	"			IF @cont_min = 180\n"+
	"				BEGIN\n"+
	"					UPDATE Contador SET minuto = 1;\n"+
	"				END\n"+
	"		END\n"+
	"		IF @total_hora = 72\n"+
	"			BEGIN\n"+
	"				IF @cont_min = 60\n"+
	"					BEGIN \n"+
	"						UPDATE Pollo_Media_Hora SET temperatura = @media_minuto_60 WHERE hora = @cont_hora;\n"+
	"						UPDATE Contador SET hora = hora + 1;\n"+
	"					END\n"+
	"				IF @cont_min= 120\n"+
	"					BEGIN \n"+
	"						UPDATE Pollo_Media_Hora SET temperatura = @media_minuto_120 WHERE hora = @cont_hora;\n"+
	"						UPDATE Contador SET hora = hora + 1;\n"+
	"					END\n"+
	"				IF @cont_min= 180\n"+
	"					BEGIN \n"+
	"						UPDATE Pollo_Media_Hora SET temperatura = @media_minuto_180 WHERE hora = @cont_hora;\n"+
	"						UPDATE Contador SET hora = hora + 1;\n"+
	"					END\n"+
	"				IF @cont_hora = 72\n"+
	"					BEGIN\n"+
	"						UPDATE Contador SET hora = 1;\n"+
	"					END\n"+
	"			END\n"+
	"		ELSE\n"+
	"			BEGIN\n"+
	"				IF @cont_min = 60\n"+
	"					BEGIN \n"+
	"						INSERT INTO Pollo_Media_Hora VALUES(@media_minuto_60);\n"+
	"					END\n"+
	"				IF @cont_min = 120\n"+
	"					BEGIN \n"+
	"						INSERT INTO Pollo_Media_Hora VALUES(@media_minuto_120);\n"+
	"					END\n"+
	"				IF @cont_min = 180\n"+
	"					BEGIN \n"+
	"						INSERT INTO Pollo_Media_Hora VALUES(@media_minuto_180);\n"+
	"					END\n"+
	"			END\n"+
	"	IF @total_dia = 90\n"+
	"			BEGIN\n"+
	"				IF @cont_hora = 24\n"+
	"					BEGIN \n"+
	"						UPDATE Pollo_Media_Dia SET temperatura = @media_hora_24 WHERE dia = @cont_dia;\n"+
	"						UPDATE Contador SET dia = dia + 1;\n"+
	"					END\n"+
	"				IF @cont_hora= 48\n"+
	"					BEGIN \n"+
	"						UPDATE Pollo_Media_Dia SET temperatura = @media_hora_48 WHERE dia = @cont_dia;\n"+
	"						UPDATE Contador SET dia = dia + 1;\n"+
	"					END\n"+
	"				IF @cont_hora= 72\n"+
	"					BEGIN \n"+
	"						UPDATE Pollo_Media_Dia SET temperatura = @media_hora_72 WHERE dia = @cont_dia;\n"+
	"						UPDATE Contador SET dia = dia + 1;\n"+
	"					END\n"+
	"				IF @cont_dia = 90\n"+
	"					BEGIN\n"+
	"						UPDATE Contador SET dia = 1;\n"+
	"					END\n"+
	"			END\n"+
	"		ELSE\n"+
	"			BEGIN\n"+
	"				IF @cont_hora = 24\n"+
	"					BEGIN \n"+
	"						INSERT INTO Pollo_Media_Dia VALUES(@media_hora_24);\n"+
	"					END\n"+
	"				IF @cont_hora = 48\n"+
	"					BEGIN \n"+
	"						INSERT INTO Pollo_Media_Dia VALUES(@media_hora_48);\n"+
	"					END\n"+
	"				IF @cont_hora = 72\n"+
	"					BEGIN \n"+
	"						INSERT INTO Pollo_Media_Dia VALUES(@media_hora_72);\n"+
	"					END\n"+
	"  					END", function(err) {  
         if (err) {  
            console.log(err);}  
        });  
        request.addParameter('temperatura', TYPES.Float, temperatura);  
        connection.execSql(request);  
    }  

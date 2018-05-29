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

    function inserirRegistro(media) {  
        var request = new Request("INSERT INTO Pollo_Media_Minuto VALUES(CURRENT_TIMESTAMP,@media);\n" +
		"DECLARE\n"+
		"@total INT, @media_hora FLOAT \n"+

		"SELECT @total = COUNT(*) FROM Pollo_Media_Minuto;\n"+
		"SELECT @media_hora = AVG(temperatura) FROM Pollo_Media_Minuto WHERE minuto <= 60;\n"+
				
		"IF @total >= 60\n"+
		"BEGIN\n"
		"	INSERT INTO Pollo_Media_Hora VALUES(@media_hora);\n"+
		"END"
		, function(err) {  
			if (err) {  
				console.log(err);
				console.log("Erro");
			} else {
				console.log("Funcionou");
			}
        });
        request.addParameter('media', TYPES.Float, media);  
        connection.execSql(request);  
    }  

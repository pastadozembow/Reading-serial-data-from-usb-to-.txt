// See https://aka.ms/new-console-template for more information
using System.IO.Ports;



// Create a new SerialPort object with default settings.
 SerialPort _serialPort = new SerialPort();
// Allow the user to set the appropriate properties.
Console.WriteLine("Enter your serial port");
//Console.WriteLine("Here are ports:");

_serialPort.PortName = SetPortName(_serialPort.PortName, _serialPort);

string SetPortName(string portName, SerialPort serialPort)
{
    portName = Console.ReadLine();
    return portName;
}
Console.WriteLine("Enter Baud rate");
_serialPort.BaudRate = SetPortBaudRate(_serialPort.BaudRate);

int SetPortBaudRate(int baudRate)
{

    baudRate = Console.Read();
    return baudRate;
}
// Set the read/write timeouts
_serialPort.ReadTimeout = 5000;

Thread.Sleep(1000);
_serialPort.Open();
// I used continu becouse continue was some function or idk
bool continu = true;
while (continu == true)
{
    try
    {
        string message = _serialPort.ReadLine();
        Console.WriteLine(message);
        continu = false;
    }
    catch (TimeoutException e)
    {
        Console.WriteLine(e.Message);
        Thread.Sleep(1000);
        continu = false;
    }
    
    catch (ArgumentException e)
    {
        Console.WriteLine(e.Message);
        Thread.Sleep(1000);
        continu = false;
    }
    
    catch (InvalidOperationException e)
    {
        Console.WriteLine(e.Message);
        Thread.Sleep(1000);
        continu = false;
    }
    
}








using ArduinoDisplayLib;
using System.IO.Ports;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Arduino display started..");
            string com = "";
            foreach (var s in SerialPort.GetPortNames())
            {
                com = s;
            }
          
            Console.WriteLine("Port: " + com);

            int baudRate = 9600;

            var portn = com;
            display.Init(portn, baudRate);
            Thread.Sleep(2500);
            ts.SwitchScreenRequest += Screen1_SwitchScreenRequest;
            ms.SwitchScreenRequest += Ms_SwitchScreenRequest;
            display.SetScreen(ts);
            Console.ReadLine();
        }

        static MonitorScreen ms = new MonitorScreen();
        static TestScreen ts = new TestScreen();
        static ArduinoDisplay display = new ArduinoDisplay();

        static void Screen1_SwitchScreenRequest(int obj)
        {
            display.SetScreen(ms);
        }
        static void Ms_SwitchScreenRequest(int obj)
        {
            ts.lines[1] = "2.monitor: " + ms.value;
            display.SetScreen(ts);

        }
    }
}
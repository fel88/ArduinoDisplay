using System.IO.Ports;

namespace ArduinoDisplayLib
{
    public class ArduinoDisplay : IDisplay
    {
        public IScreen Screen { get; private set; }
        public void Init(string com, int baudRate)
        {
            port = new SerialPort(com, baudRate);
            port.Open();
            port.DataReceived += Port_DataReceived;
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            if (indata.Trim() == "btn1")
            {
                Screen.ButtonPressed(0);
            }
            else if (indata.Trim() == "btn2")
            {
                Screen.ButtonPressed(1);
            }
            else if (indata.Trim() == "btn3")
            {
                Screen.ButtonPressed(2);
            }
            else if (indata.Trim() == "btn4")
            {
                Screen.ButtonPressed(3);
            }
        }

        SerialPort port;
        public void UpdateLine(int line, string str)
        {
            port.WriteLine($"str{line+1}={str}");
        }

        public void UpdateTitle(string str)
        {
            port.WriteLine($"title={str}");            
        }
                
        public void SetScreen(IScreen screen)
        {
            Screen = screen;
            screen.SetDisplay(this);
            screen.Redraw();
        }
    }
}
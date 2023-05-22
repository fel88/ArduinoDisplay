using System.IO.Ports;

namespace ArduinoDisplayLib
{
    public class ArduinoDisplay : IDisplay
    {
        public IScreen Screen { get; private set; }
        public void Init(string com, int baudRate)
        {
            port = new SerialPort(com, baudRate);
            port.RtsEnable = true;
            port.DtrEnable = true;            
            
            port.Open();
            //port.DataReceived += Port_DataReceived;

            Thread th = new Thread(() =>
            {
                while (true)
                {
                    var indata = port.ReadLine().Trim();
                    //strings.Add(indata);
                    if (indata == "ok")
                    {
                        //ArduinoDisplay.ev.Set();
                    }
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
            });
            th.IsBackground = true;
            th.Start();
        }
        static List<string> strings = new List<string>();

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
            //ev.WaitOne();
        }
       
        //static AutoResetEvent ev = new AutoResetEvent(false);
        public void UpdateTitle(string str)
        {
            port.WriteLine($"title={str}");
            //ev.WaitOne();
        }
                
        public void SetScreen(IScreen screen)
        {
            Screen = screen;
            screen.SetDisplay(this);
            screen.Redraw();
        }
    }
}
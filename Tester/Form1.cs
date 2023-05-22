using System.IO.Ports;

namespace Tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (var item in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(item);
            }
        }
        System.IO.Ports.SerialPort sp;
        private void button1_Click(object sender, EventArgs e)
        {
            sp = new System.IO.Ports.SerialPort(comboBox1.Text, int.Parse(comboBox2.Text));

            sp.RtsEnable = true;
            sp.DtrEnable = true;
            sp.Open();
            Thread.Sleep(3500);
            //sp.Dispose();
            int cnt = 0;
            while (!sp.IsOpen)
            {
                cnt++;
            }
            Thread th = new Thread((() =>
            {
                while (true)
                {
                    try
                    {
                        if (sp.BytesToRead > 0)
                        {
                            var line = sp.ReadExisting();

                            richTextBox1.Invoke(() =>
                            {
                                richTextBox1.AppendText(line);
                            });
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }));
            th.IsBackground = true;
            th.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sp.WriteLine(textBox1.Text);

            textBox1.Text = "";
            sp.BaseStream.Flush();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
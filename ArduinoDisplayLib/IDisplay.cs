namespace ArduinoDisplayLib
{
    public interface IDisplay
    {
        void SetScreen(IScreen screen);
        IScreen Screen { get; }
        void Init(string com, int baudRate);
        void UpdateLine(int line, string str);
        void UpdateTitle(string str);
    }
}
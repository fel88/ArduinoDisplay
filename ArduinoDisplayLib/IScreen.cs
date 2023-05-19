namespace ArduinoDisplayLib
{
    public interface IScreen
    {
        void Redraw();
        void ButtonPressed(int index);
        void SetDisplay(IDisplay display);
        void Update();
    }

}
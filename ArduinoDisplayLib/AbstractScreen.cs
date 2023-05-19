namespace ArduinoDisplayLib
{
    public abstract class AbstractScreen
    {
        protected IDisplay Display;
        public event Action<int> SwitchScreenRequest;
        public event Action<int> ButtonFire;
        protected void InvokeSwitchScreenRequest(int index)
        {
            SwitchScreenRequest?.Invoke(index);
        }
        protected void InvokeButtonFire(int index)
        {
            ButtonFire?.Invoke(index);
        }
        public virtual void Update()
        {

        }
        public void SetDisplay(IDisplay display)
        {
            Display = display;
        }
    }
}
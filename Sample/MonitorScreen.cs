using ArduinoDisplayLib;

namespace Sample
{
    public class MonitorScreen : AbstractScreen, IScreen
    {
        public void ButtonPressed(int index)
        {
            if (index == 2)
            {
                InvokeSwitchScreenRequest(0);
            }
            else
            {
                InvokeButtonFire(index);
                Ms_ButtonFire(index);
            }
        }

        void Ms_ButtonFire(int obj)
        {
            if (obj == 0)
            {
                value += step;
                Update();
            }
            else if (obj == 1)
            {
                value -= step;
                Update();
            }
            else if (obj == 3)
            {
                if (step == 1)
                {
                    step = 5;
                }
                else { step = 1; }

                Update();
            }
            /*else
            if (obj == 2)
                valueDown = !valueDown;*/
        }
        public float value = 10.0f;
        public override void Update()
        {
            Display.UpdateTitle("Value: " + Math.Round(value, 1));
            Display.UpdateLine(0,"step: " + step);
        }
        public int step = 1;

        public void Redraw()
        {
            Update();
            for (int i = 0; i < 3; i++)
            {
                Display.UpdateLine(i, string.Empty);
            }
            Display.UpdateLine(0, "step: " + step);

        }
    }
}
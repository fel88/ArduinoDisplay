using ArduinoDisplayLib;

namespace Sample
{
    public class TestScreen : AbstractScreen, IScreen
    {
        public void ApplyButton()
        {
            if (crnMenuPos == 1)
            {
                InvokeSwitchScreenRequest(1);
            }
            else
                Display.UpdateTitle(lines[crnMenuPos]);
        }

        public void ButtonPressed(int index)
        {
            if (index == 2) ApplyButton();
            else if (index == 0) UpButton();
            else if (index == 1) DownButton();
        }
        public void DownButton()
        {
            crnMenuPos++;
            if (crnMenuPos > 2) crnMenuPos = 2;
            for (int i = 0; i < lines.Length; i++)
            {
                if (i == crnMenuPos) continue;
                Display.UpdateLine(i, lines[i]);
            }
            Display.UpdateLine(crnMenuPos, $"> {lines[crnMenuPos]}");
        }
        public void UpButton()
        {
            crnMenuPos--;
            if (crnMenuPos < 0)
                crnMenuPos = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                if (i == crnMenuPos) continue;
                Display.UpdateLine(i, lines[i]);
            }
            Display.UpdateLine(crnMenuPos, $"> {lines[crnMenuPos]}");
        }


        public void Redraw()
        {
            Display.UpdateTitle("Test");
            
            Display.UpdateLine(0, $"> {lines[0]}");
            for (int i = 1; i < lines.Length; i++)
            {
                Display.UpdateLine(i, lines[i]);
            }
        }

        int crnMenuPos = 0;
        public string[] lines = new string[] { "1.test", "2.monitor: 10", "3.exit" };
    }
}
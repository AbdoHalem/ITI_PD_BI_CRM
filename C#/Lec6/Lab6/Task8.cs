using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public delegate void ClickHandler(object sender, string buttonName);
    // Declare the sender class
    public class Button
    {
        public string buttonName;
        public Button(string buttonName)
        {
            this.buttonName = buttonName;
        }
        public event ClickHandler? Click;
        public void PerformClick()
        {
            Click?.Invoke(this, buttonName);
        }
    }
    // Declare listener classes
    public class FormHandler
    {
        public static void OnClick(object sender, string buttonName)
        {
            Console.WriteLine($"FormHandler listener of {buttonName} from sender {sender}");
        }
    }
    public class Logger
    {
        public static void LogClick(object sender, string buttonName)
        {
            Console.WriteLine($"Logger listener of {buttonName} from sender {sender}");
        }
    }
    internal class Task8
    {
        public static void task8()
        {
            Button button = new Button("EnterButton");
            button.Click += FormHandler.OnClick;
            button.Click += Logger.LogClick;
            button.Click += (s, n) => Console.WriteLine(n);
            button.PerformClick();
        }

    }
}

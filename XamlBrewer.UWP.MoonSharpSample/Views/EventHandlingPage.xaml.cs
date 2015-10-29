using MoonSharp.Interpreter;
using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using XamlBrewer.UWP.MoonSharpSample.Models;

namespace XamlBrewer.UWP.MoonSharpSample.Views
{
    /// <summary>
    /// Shows how to register a Lua event handler to a C# event.
    /// </summary>
    public sealed partial class EventHandlingPage : Page
    {
        private BusinessObject bus = new BusinessObject();

        public EventHandlingPage()
        {
            this.InitializeComponent();

            Chunk.Text = @"function handler(o, a)
   print('handled!', o, a);
end

obj.somethingHappened.add(handler);
obj.raiseTheEvent();

--obj.somethingHappened.remove(handler);
--obj.raiseTheEvent();";
        }

        private void CallButton_Click(object sender, RoutedEventArgs e)
        {
            string scriptCode = Chunk.Text;

            // Register types to be used in the script.
            UserData.RegisterType<BusinessObject>();
            UserData.RegisterType<EventArgs>();

            Script script = new Script();

            try
            {
                var obj = UserData.Create(bus);

                script.Globals.Set("obj", obj);

                script.DoString(scriptCode);

                Result.Foreground = new SolidColorBrush(Colors.Black);
                Result.Text = "done";
            }
            catch (Exception ex)
            {
                Result.Foreground = new SolidColorBrush(Colors.Red);
                Result.Text = ex.Message;
            }
        }

        private void RaiseButton_Click(object sender, RoutedEventArgs e)
        {
            bus.RaiseTheEvent();
        }
    }
}
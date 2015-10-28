using MoonSharp.Interpreter;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using XamlBrewer.UWP.MoonSharpSample.Models;

namespace XamlBrewer.UWP.MoonSharpSample.Views
{
    public sealed partial class EventHandlingPage : Page
    {
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


        private BusinessObject bus = new BusinessObject();

        private void CallButton_Click(object sender, RoutedEventArgs e)
        {
            string scriptCode = Chunk.Text;

            UserData.RegisterType<BusinessObject>();
            UserData.RegisterType<EventArgs>();

            Script script = new Script();

            try
            {
                var obj = UserData.Create(bus);

                script.Globals.Set("obj", obj);

                script.DoString(scriptCode);

                Result.Text = "done";
            }
            catch (Exception ex)
            {
                Result.Text = ex.Message;
            }
        }

        private void RaiseButton_Click(object sender, RoutedEventArgs e)
        {
            bus.RaiseTheEvent();
        }
    }
}
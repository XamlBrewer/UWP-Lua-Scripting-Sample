using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using XamlBrewer.UWP.MoonSharpSample.Models;

namespace XamlBrewer.UWP.MoonSharpSample.Views
{
    public sealed partial class EventHandlingPage : Page
    {
        public EventHandlingPage()
        {
            this.InitializeComponent();

            Chunk4.Text = @"function handler(o, a)
   print('handled!', o, a);
end

obj.somethingHappened.add(handler);
obj.raiseTheEvent();

obj.somethingHappened.remove(handler);
obj.raiseTheEvent();";
        }


        private BusinessObject bus = new BusinessObject();

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string scriptCode = Chunk4.Text;

            UserData.RegisterType<BusinessObject>();
            UserData.RegisterType<EventArgs>();

            Script script = new Script();

            try
            {
                var obj = UserData.Create(bus);

                script.Globals.Set("obj", obj);

                script.DoString(scriptCode);

                Result5.Text = "done";
            }
            catch (Exception ex)
            {
                Result5.Text = ex.Message;
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            bus.RaiseTheEvent();
        }
    }
}
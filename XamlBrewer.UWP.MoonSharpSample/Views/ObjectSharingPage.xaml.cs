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
    public sealed partial class ObjectSharingPage : Page
    {
        public ObjectSharingPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string scriptCode = Chunk3.Text;

            // Automatically register all MoonSharpUserData types
            // UserData.RegisterAssembly(); // Hey, that did not work

            // Automatically register all types. Pandora's box.
            // UserData.RegistrationPolicy = InteropRegistrationPolicy.Automatic;

            UserData.RegisterType<BusinessObject>();

            Script script = new Script();

            try
            {
                var obj = UserData.Create(new BusinessObject());

                script.Globals.Set("obj", obj);

                script.DoString(scriptCode);

                Result4.Text = "done";
            }
            catch (Exception ex)
            {
                Result4.Text = ex.Message;
            }
        }
    }
}

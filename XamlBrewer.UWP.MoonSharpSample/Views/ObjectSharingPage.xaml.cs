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
    /// Shows how to expose a C# instance to a Lua script, how the script accesses and manipulates that instance.
    /// </summary>
    public sealed partial class ObjectSharingPage : Page
    {
        public ObjectSharingPage()
        {
            this.InitializeComponent();
            Chunk.Text = @"vat = obj.vatRate
print(vat)

obj.vatRate = 25
print(obj.calculateVAT(200))";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string scriptCode = Chunk.Text;

            // Register the type(s) to be used in the script.

            // Automatically register all classes with the MoonSharpUserData attribute.
            // UserData.RegisterAssembly(); // Hey, that did not work (not here and not in WPF)

            // Automatically register all types. Pandora's box.
            // UserData.RegistrationPolicy = InteropRegistrationPolicy.Automatic;

            UserData.RegisterType<BusinessObject>();

            Script script = new Script();

            try
            {
                var obj = UserData.Create(new BusinessObject());

                // Actually, this also works:
                // var obj = new BusinessObject();

                script.Globals["obj"] = obj;

                // Alternatively:
                //script.Globals.Set("obj", obj);

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
    }
}

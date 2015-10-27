using MoonSharp.Interpreter;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace XamlBrewer.UWP.MoonSharpSample.Views
{
    public sealed partial class CSharpFunctionPage : Page
    {
        public CSharpFunctionPage()
        {
            this.InitializeComponent();
        }

        public async static void Say(string message)
        {
            var d = new MessageDialog(message);
            await d.ShowAsync();
        }

        public static string Reverse(string tobereversed)
        {
            char[] charArray = tobereversed.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string scriptCode = Chunk2.Text;

            Script script = new Script();

            try
            {
                script.Globals["say"] = (Action<String>)(Say);
                script.Globals["reverse"] = (Func<String, String>)(Reverse);

                script.DoString(scriptCode);

                Result3.Text = "done";
            }
            catch (Exception ex)
            {
                Result3.Text = ex.Message;
            }
        }
    }
}

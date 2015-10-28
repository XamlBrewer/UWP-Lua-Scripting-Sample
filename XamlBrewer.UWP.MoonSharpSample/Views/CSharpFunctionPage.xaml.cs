using MoonSharp.Interpreter;
using System;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace XamlBrewer.UWP.MoonSharpSample.Views
{
    public sealed partial class CSharpFunctionPage : Page
    {
        public CSharpFunctionPage()
        {
            this.InitializeComponent();

            Chunk.Text = @"hello = 'Hello World'
say(hello)

print(reverse(hello))";
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string scriptCode = Chunk.Text;

            Script script = new Script();

            try
            {
                script.Globals["say"] = (Action<String>)(Say);
                script.Globals["reverse"] = (Func<String, String>)(Reverse);

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

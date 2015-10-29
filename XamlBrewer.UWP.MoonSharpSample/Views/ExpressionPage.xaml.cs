using MoonSharp.Interpreter;
using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace XamlBrewer.UWP.MoonSharpSample.Views
{
    /// <summary>
    /// Shows how to run a Lua script from C# and get back the result.
    /// </summary>
    public sealed partial class ExpressionPage : Page
    {
        public ExpressionPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var script = "return " + Expression.Text;

            try
            {
                // Run the script and get the result.
                DynValue result = Script.RunString(script);

                Result.Foreground = new SolidColorBrush(Colors.Black);
                Result.Text = result.ToString();
            }
            catch (Exception ex)
            {
                Result.Foreground = new SolidColorBrush(Colors.Red);
                Result.Text = ex.Message;
            }
        }
    }
}

using MoonSharp.Interpreter;
using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace XamlBrewer.UWP.MoonSharpSample.Views
{
    public sealed partial class LuaFunctionPage : Page
    {
        public LuaFunctionPage()
        {
            this.InitializeComponent();

            ParameterA.Text = "42";
            ParameterB.Text = "36";

            Chunk.Text = @"if a<b then
  return a
else
  return b
end";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string scriptCode = "function f(a,b) " + Chunk.Text + " end";

            var script = new Script();

            try
            {
                script.DoString(scriptCode);

                DynValue luaFunction = script.Globals.Get("f");

                // Type conversion is optional
                DynValue res = script.Call(luaFunction, DynValue.NewString(ParameterA.Text).CastToNumber(), DynValue.NewString(ParameterB.Text).CastToNumber());

                Result.Foreground = new SolidColorBrush(Colors.Black);
                // Type conversion is optional
                Result.Text = res.Number.ToString();
            }
            catch (Exception ex)
            {
                Result.Foreground = new SolidColorBrush(Colors.Black);
                Result.Text = ex.Message;
            }
        }
    }
}

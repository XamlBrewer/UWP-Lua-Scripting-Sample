using MoonSharp.Interpreter;
using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace XamlBrewer.UWP.MoonSharpSample.Views
{
    /// <summary>
    /// Shows how to provide parameters to a Lua function from C#, call it, and get the result back.
    /// </summary>
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

                // Type conversion for the parameters is optional
                DynValue res = script.Call(
                                        luaFunction, 
                                        DynValue.NewString(ParameterA.Text).CastToNumber(), 
                                        Double.Parse(ParameterB.Text));

                // Check the return type.
                if (res.Type != DataType.Number)
                {
                    throw new InvalidCastException("Invalid return type: " + res.Type.ToString());
                }

                Result.Foreground = new SolidColorBrush(Colors.Black);

                // Type conversion swallows exceptions.
                Result.Text = res.Number.ToString();
                // Result.Text = res.CastToNumber().ToString();
            }
            catch (Exception ex)
            {
                Result.Foreground = new SolidColorBrush(Colors.Red);
                Result.Text = ex.Message;
            }
        }
    }
}

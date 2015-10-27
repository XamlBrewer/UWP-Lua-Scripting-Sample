using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace XamlBrewer.UWP.MoonSharpSample.Views
{
    public sealed partial class LuaFunctionPage : Page
    {
        public LuaFunctionPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string scriptCode = "function f(a,b) " + Chunk.Text + " end";

            var script = new Script();

            try
            {
                script.DoString(scriptCode);

                DynValue luaFunction = script.Globals.Get("f");

                // Type conversion is optional
                DynValue res = script.Call(luaFunction, DynValue.NewString(ParameterA.Text).CastToNumber(), DynValue.NewString(ParameterB.Text).CastToNumber());

                Result2.Foreground = new SolidColorBrush(Colors.Black);
                // Type conversion is optional
                Result2.Text = res.Number.ToString();
            }
            catch (Exception ex)
            {
                Result2.Foreground = new SolidColorBrush(Colors.Black);
                Result2.Text = ex.Message;
            }
        }
    }
}

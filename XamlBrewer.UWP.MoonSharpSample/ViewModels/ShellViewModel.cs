using XamlBrewer.UWP.MoonSharpSample.Views;

namespace Mvvm
{
    class ShellViewModel : ViewModelBase
    {
        public ShellViewModel()
        {
            // Build the menu
            Menu.Add(new MenuItem() { Glyph = "\uE1D0", Text = "Expressions", NavigationDestination = typeof(ExpressionPage) });
            //Menu.Add(new MenuItem() { Glyph = "\uE2B1", Text = "Templated", NavigationDestination = typeof(TemplatePage) });
            //Menu.Add(new MenuItem() { Glyph = "\uE114", Text = "Camera", NavigationDestination = typeof(CameraPage) });
        }
    }
}

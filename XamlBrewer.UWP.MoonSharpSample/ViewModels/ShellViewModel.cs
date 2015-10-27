using XamlBrewer.UWP.MoonSharpSample.Views;

namespace Mvvm
{
    class ShellViewModel : ViewModelBase
    {
        public ShellViewModel()
        {
            // Build the menu
            Menu.Add(new MenuItem() { Glyph = "\uE1D0", Text = "Expressions", NavigationDestination = typeof(ExpressionPage) });
            Menu.Add(new MenuItem() { Glyph = "\uE2B1", Text = "Lua Functions", NavigationDestination = typeof(LuaFunctionPage) });
            Menu.Add(new MenuItem() { Glyph = "\uE114", Text = "C# Functions", NavigationDestination = typeof(CSharpFunctionPage) });
            Menu.Add(new MenuItem() { Glyph = "\uE114", Text = "Object Sharing", NavigationDestination = typeof(ObjectSharingPage) });
            Menu.Add(new MenuItem() { Glyph = "\uE114", Text = "Event Handling", NavigationDestination = typeof(EventHandlingPage) });
        }
    }
}

# UWP-Lua-Scripting-Sample
Demonstrates extending Universal Windows Platform apps with Lua scripting through MoonSharp:
* Evaluating Lua expressions
* Calling Lua functions from C#
* Calling C# methods from a Lua script
* Accessing C# objects from a Lua script
* Handling C# events in a Lua script

Lua is a powerful, fast, lightweight, embeddable scripting language. More at http://www.lua.org/
MoonSharp is a Lua interpreter written entirely in C# for the .NET, Mono and Unity platforms (and that includes universal apps and Xamarin). More at http://www.moonsharp.org/.

This sample app is built as a playground: it allows you to experiment with the Lua scripts.

The PCL assembly in the MoonScript NuGet package does not yet contain a Windows 10 entry. I made one myself and put in the Libs folder of this solution.

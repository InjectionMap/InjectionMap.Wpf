![wickedflame injectionmap](assets/wickedflame injectionmap - black.png)

# InjectionMap.Wpf
------------------------------
InjectionMap is a small extension to InjectionMap for WPF Applications. 
This extension allows viewmodels to be injected into the DataContext of a View (FrameworkElement).

# Usage
------------------------------
- Create a View (Usercontrol/Window/...)  
```csharp
<Window x:Class="MainWindow">
	...
</Window>
```
- Create a ViewModel (A class that will be added to the DataContext)
```csharp
namespace ViewModels
{
	public class ViewModel : INotifyPropertyChanged
	{
		...
	}
}
```
- Bind the ViewModel to the View
```csharp
<Window x:Class="MainWindow"
        xmlns:resolver="clr-namespace:InjectionMap;assembly=personalplaner.common"
        xmlns:vm="clr-namespace:ViewModels"
        resolver:DataContextResolver.Resolve="{x:Type vm:ViewModel}">
...
</Window>
```

For ViewModels that just use the default constructor, the ViewModel does not have to be mapped to InjectionMap first.

## Installation
------------------------------
InjectionMap can be installed from [NuGet](http://docs.nuget.org/docs/start-here/installing-nuget) through the package manager console:  

    PM > Install-Package InjectionMap.Wpf

## Bugs, issues and features
------------------------------
Bugs, issues or feature wishes can submitted on the [issues](https://github.com/InjectionMap/InjectionMap.Wpf/issues) page or feel free to fork the project and send a pull request.


InjectionMap is developed by [wickedflame](http://wicked-flame.blogspot.ch/) under the [Ms-PL License](License.txt).
using Microsoft.Maui.Controls;

namespace UltraMinimalCrash;

public class App : Application
{
    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new ContentPage 
        { 
            Title = "Ultra Minimal",
            Content = new Label 
            { 
                Text = "Ultra Minimal SdkOnly Test",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            }
        });
    }
}
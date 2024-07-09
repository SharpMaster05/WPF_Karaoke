using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Karaoke.Services;

internal static class AnimationService
{
    public static void CloseAnimation(Border border)
    {
        int width = (int)border.ActualWidth;
        var time = TimeSpan.FromSeconds(0.5);

        DoubleAnimation animation =
            new(width, 0, time)
            {
                EasingFunction = new PowerEase() { Power = 3, EasingMode = EasingMode.EaseOut }
            };

        animation.Completed += (s, e) => App.Current.Shutdown();

        border.BeginAnimation(FrameworkElement.WidthProperty, animation);
    }

    public static void Maximize(Border border)
    {
        var view = App.Current.MainWindow;

        if (view.WindowState == WindowState.Maximized)
            MaximizeAnimation(border, view, WindowState.Normal);
        else
            MaximizeAnimation(border, view, WindowState.Maximized);
    }

    public static void Minimize(Border border)
    {
        var view = App.Current.MainWindow;
        var time = TimeSpan.FromSeconds(0.3);

        var actualHeight = (int)view.ActualHeight;
        var actualWidth = (int)view.ActualWidth;

        DoubleAnimation hideHeight = new DoubleAnimation(actualHeight, 0, time)
        {
            EasingFunction = new PowerEase() { Power = 2, EasingMode = EasingMode.EaseOut },
            FillBehavior = FillBehavior.Stop
        };
        DoubleAnimation hideWidth = new DoubleAnimation(actualWidth, 0, time)
        {
            EasingFunction = new PowerEase() { Power = 2, EasingMode = EasingMode.EaseOut },
            FillBehavior = FillBehavior.Stop
        };

        hideHeight.Completed += (s, e) => view.WindowState = WindowState.Minimized;

        border.BeginAnimation(FrameworkElement.HeightProperty, hideHeight);
        border.BeginAnimation(FrameworkElement.WidthProperty, hideWidth);
    }

    private static void MaximizeAnimation(Border border, Window window, WindowState state)
    {
        var view = window;
        var time = TimeSpan.FromSeconds(0.4);

        var actualHeight = (int)view.ActualHeight;

        DoubleAnimation hideHeight = new DoubleAnimation(actualHeight, 0, time)
        {
            EasingFunction = new PowerEase() {EasingMode = EasingMode.EaseInOut, Power = 3 },
        };

        hideHeight.Completed += (s, e) =>
        {
            view.WindowState = state;

            var targetHeight = (int)view.ActualHeight;
            var targetWidth = (int)view.ActualWidth;

            DoubleAnimation fadeHeight = new DoubleAnimation(0, targetHeight, time)
            {
                EasingFunction = new PowerEase() { EasingMode = EasingMode.EaseInOut, Power = 3 },
            };
            border.BeginAnimation(FrameworkElement.HeightProperty, fadeHeight);
        };
        border.BeginAnimation(FrameworkElement.HeightProperty, hideHeight);
    }
    public static void FadeSettings(Border border)
    {

        var time = TimeSpan.FromSeconds(0.5);

        if (border.Visibility == Visibility.Visible)
            FadeSettingsAnimation(border, 1, 0, Visibility.Collapsed);
        else
            FadeSettingsAnimation(border, 0, 1, Visibility.Visible);
    }

    private static void FadeSettingsAnimation(Border border, int start, int end, Visibility visibility)
    {
        var time = TimeSpan.FromSeconds(0.3);
        
        DoubleAnimation fadeAnimation = new DoubleAnimation(start, end, time);
        
        if (border.Visibility == Visibility.Visible)
            fadeAnimation.Completed += (s, e) => border.Visibility = visibility;
        else
            border.Visibility = visibility;

        border.BeginAnimation(UIElement.OpacityProperty, fadeAnimation);
    }
}

using System.Windows;

namespace Blagajna
{
    public static class MenuButtonHelper
    {
        public static readonly DependencyProperty ButtonNameProperty =
            DependencyProperty.RegisterAttached(
                "ButtonName",
                typeof(string),
                typeof(MenuButtonHelper),
                new PropertyMetadata(null));

        public static string GetButtonName(DependencyObject obj)
        {
            return (string)obj.GetValue(ButtonNameProperty);
        }

        public static void SetButtonName(DependencyObject obj, string value)
        {
            obj.SetValue(ButtonNameProperty, value);
        }
    }
}

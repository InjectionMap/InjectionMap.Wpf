using System;
using System.Windows;

namespace InjectionMap.Wpf
{
    public class InjectionResolver
    {
        #region Resolve

        /// <summary>
        /// Resolve Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty ResolveProperty = DependencyProperty.RegisterAttached(
            "Resolve",
            typeof(Type),
            typeof(InjectionResolver),
            new FrameworkPropertyMetadata((Type)null, new PropertyChangedCallback(OnResolveChanged)));

        /// <summary>
        /// Gets the Resolve property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static Type GetResolve(DependencyObject d)
        {
            return (Type)d.GetValue(ResolveProperty);
        }

        /// <summary>
        /// Sets the Resolve property.  This dependency property 
        /// indicates ....
        /// </summary>
        public static void SetResolve(DependencyObject d, Type value)
        {
            d.SetValue(ResolveProperty, value);
        }

        /// <summary>
        /// Handles changes to the Resolve property.
        /// </summary>
        private static void OnResolveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as FrameworkElement;
            if (element == null)
            {
                throw new InvalidOperationException("Objects can only be injected into the DataContext FrameworkElements");
            }

            using (var resolver = new InjectionMap.InjectionResolver())
            {
                element.DataContext = resolver.Resolve(e.NewValue as Type);
            }
        }

        #endregion
    }
}

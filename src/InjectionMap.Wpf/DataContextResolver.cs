﻿using InjectionMap.Tracing;
using System;
using System.Windows;

namespace InjectionMap
{
    [Obsolete("Use InjectionMap.Wpf.InjectionResolver")]
    public class DataContextResolver
    {
        static LoggerFactory _loggerFactory = new LoggerFactory();
        static ILogger Logger
        {
            get
            {
                return _loggerFactory.CreateLogger();
            }
        }

        #region Resolve

        /// <summary>
        /// Resolve Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty ResolveProperty = DependencyProperty.RegisterAttached(
            "Resolve",
            typeof(Type),
            typeof(DataContextResolver),
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
                Logger.Write(string.Format("InjectionMap.Wpf - ViewModel Injection can only be made on DataContext of FrameworkElements. Could not find DataContext on {0}", d.GetType().Name), LogLevel.Error, "InjectionMap.Wpf.InjectionResolver", "InjectionResolver", DateTime.Now);
                throw new InvalidOperationException("Objects can only be injected into the DataContext FrameworkElements");
            }

            using (var resolver = new InjectionResolver())
            {
                Logger.Write(string.Format("InjectionMap.Wpf - Inject {0} to DataContext of {1}", e.NewValue, d.GetType()), LogLevel.Info, "InjectionMap.Wpf.InjectionResolver", "InjectionResolver", DateTime.Now);
                element.DataContext = resolver.Resolve(e.NewValue as Type);
            }
        }

        #endregion
    }
}

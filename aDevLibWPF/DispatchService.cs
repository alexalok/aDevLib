using System;
using System.Windows;

namespace aDevLibWPF
{
    public static class DispatchService
    {
        public static void InvokeIfNeeded(Action action)
        {
            var dispatchObject = Application.Current?.Dispatcher;
            if (dispatchObject == null || dispatchObject.CheckAccess())
                action();
            else
                dispatchObject.Invoke(action);
        }
    }
}
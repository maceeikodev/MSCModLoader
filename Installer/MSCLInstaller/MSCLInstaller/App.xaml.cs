﻿using System.Windows;

namespace MSCLInstaller
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
#if DEBUG
            throw e.Exception;
#else
            MessageBox.Show("Error:\n\n" + e.Exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            Dbg.Log("!!! Unhandled Exception !!!",true,true);
            Dbg.Log(e.Exception.ToString());

            e.Handled = true;

#endif       
        }
    }
}

using System;
using System.Windows;
using System.Windows.Input;

namespace RSAKeyPairGenerator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainWindowDataContext();
            InitializeComponent();
        }

        void CopyCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = TypedDataContext.IsKeyPairGenerated;
        }

        private void CopyExecuted(object sender, ExecutedRoutedEventArgs e) => Clipboard.SetText(e.Parameter switch
        {
            "PrivateKey" => TypedDataContext.GetPrivateKeyText(),
            "PublicKey" => TypedDataContext.GetPublicKeyText(),
            _ => throw new NotSupportedException()
        });

        async void NewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            await TypedDataContext.GenerateKeyPairAsync();
            CommandManager.InvalidateRequerySuggested();
        }

        MainWindowDataContext TypedDataContext => (MainWindowDataContext)DataContext;
    }
}

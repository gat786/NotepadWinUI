using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System.Diagnostics;
using Windows.ApplicationModel.DataTransfer;
using Microsoft.UI.Text;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace NotepadWinUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void FileMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Something tapped an item in file menu");
        }

        private async void EditMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as MenuFlyoutItem) == CopyMenuItem)
            {
                var content = new DataPackage();
                content.SetText(MainEditBox.Text);
                Clipboard.SetContent(content);
            }
            else if ((sender as MenuFlyoutItem) == PasteMenuItem) 
            {
                Debug.WriteLine("Pasting Clipboard in Main Edit Box");

                if (MainEditBox.CanPasteClipboardContent)
                {
                    MainEditBox.PasteFromClipboard();
                }
            }
            else if((sender as MenuFlyoutItem) == CutMenuItem)
            {
                Debug.WriteLine("Cutting Stuff from Main Edit Box");
                var content = new DataPackage();
                content.SetText(MainEditBox.Text);
                Clipboard.SetContent(content);
                MainEditBox.Text = "";
            }
        }

        private void ViewMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Something tapped an item in View menu");
        }

        private void FormatMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Something tapped an item in Format menu");
        }

        private void HelpMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Something tapped an item in Help menu");
        }
    }
}

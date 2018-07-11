using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace broadFileSystemAccess
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var localfolder = ApplicationData.Current.LocalFolder.Path;
            var array = localfolder.Split('\\');
            var username = array[2];
            string _cloudPath = @"C:\Users\" + username + @"\OneDrive\invest\StockMonitor.db";

            string _dbLocalFolderPath = ApplicationData.Current.LocalFolder.Path;
            const string _dbLocalFileName = "StockMonitor.db";

            CopyFileAsync(_cloudPath, _dbLocalFolderPath, _dbLocalFileName);
        }

        private static async Task CopyFileAsync(string sourceFilePath,
            string destinationFilePath, string destinationFileName,
            NameCollisionOption option = NameCollisionOption.ReplaceExisting)
        {
            var sourceFile = await StorageFile.GetFileFromPathAsync(sourceFilePath);
            var destinationFolder = await StorageFolder.GetFolderFromPathAsync(destinationFilePath);
            await sourceFile.CopyAsync(destinationFolder, destinationFileName, option);
        }
    }
}

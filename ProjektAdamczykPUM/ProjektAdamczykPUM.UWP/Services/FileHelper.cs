
using System.IO;
using Xamarin.Forms;
using ProjektAdamczykPUM.UWP;
using Windows.Storage;
using ProjektAdamczykPUM.Services.Interfaces;
using ProjektAdamczykPUM.UWP.IO.FileSystem;

[assembly: Dependency(typeof(FileHelper))]
namespace ProjektAdamczykPUM.UWP.IO.FileSystem
{
    class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
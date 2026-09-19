using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace Streamall.Helpers
{
    internal class FileDialogHelper
    {
        public static string GetFilePath()
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Selecione a nova capa para o filme";
            dialog.InitialDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "Downloads");
            dialog.Filter = "IMG | *.jpg; *.png; *.webp; *.jfif";
            var succes = dialog.ShowDialog();

            if (succes == true)
                return dialog.FileName;
            return null;
        }
    }
}

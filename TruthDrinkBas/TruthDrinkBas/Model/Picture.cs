using Android.Content;
using System;
using Android.Systems;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace TruthDrinkBas.Model
{
    public class Picture
    {
        [Obsolete]
        public void storePhotoToGallery(byte[] bytes, string fileName)
        {
            Context context = MainActivity.Instancen;
            try
            {
                Java.IO.File storagePath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures);
                string path = System.IO.Path.Combine(storagePath.ToString(), fileName);
                System.IO.File.WriteAllBytes(path, bytes);
                var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                mediaScanIntent.SetData(Android.Net.Uri.FromFile(new Java.IO.File(path)));
                context.SendBroadcast(mediaScanIntent);
            }
            catch (Exception ex)
            {
            }
        }
    }
}

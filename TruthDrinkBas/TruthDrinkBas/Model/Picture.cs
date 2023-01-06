using Android.Content;
using System;
using Android.Systems;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Android.Graphics;
using Android.Media;
using System.IO;
using Android.Provider;

namespace TruthDrinkBas.Model
{
    public class Picture 
    { 

        public void ExportBitmapAsPNG(Bitmap bitmap)
        {

            // Get/Create Album Folder To Save To
            var jFolder = new Java.IO.File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "MyAppNamePhotoAlbum");
            if (!jFolder.Exists())
                jFolder.Mkdirs();

            var jFile = new Java.IO.File(jFolder, "MyPhoto.jpg");

            // Save File
            using (var fs = new FileStream(jFile.AbsolutePath, FileMode.CreateNew))
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 100, fs);
            }

            // Save Picture To Gallery
            var intent = new Intent(MediaStore.ActionImageCapture);
            //intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(jFile));
            //StartActivityForResult(intent, 0);

        }
    }
}

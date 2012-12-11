using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
/// <summary>
/// Summary description for Gallery
/// </summary>
public class Gallery
{
    private static readonly Regex ApprovedExenstions;
    public static string PhysicalApplicationPath { get; set; }
    static Gallery()
    {
        Regex ApprovedExenstions = new Regex("^.*.(gif|jpg|png)", RegexOptions.IgnoreCase);
    }
    public List<string> GetImageNames()
    {
        string path = String.Format("{0}/", PhysicalApplicationPath);
        var di = new DirectoryInfo(path);
        FileInfo[] files = di.GetFiles();
        List<string> fileList = new List<string>();

        for (int i = 0; i < files.Length; i++)
        {
            fileList.Add(files[i].Name);
        }
        return fileList;
    }
    public static bool ImageExists(string name)
    {
        if (File.Exists(String.Format("{0}/{1}", PhysicalApplicationPath, name)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    static bool IsValidImage(System.Drawing.Image image)
    {
        bool validImage;
        if (image.RawFormat.Guid == ImageFormat.Jpeg.Guid || image.RawFormat.Guid == ImageFormat.Png.Guid || image.RawFormat.Guid == ImageFormat.Gif.Guid)
        {
            validImage = true;
        }
        else
        {
            validImage = false;
        }
        return validImage;
    }
    public string SaveImage(Stream stream, string fileName)
    {

        if (true)
        {
            int existingImageCount = 15;

            var image = System.Drawing.Image.FromStream(stream); // stream -> ström med bild
            var thumbnail = image.GetThumbnailImage(60, 45, null, System.IntPtr.Zero);
            thumbnail.Save("~/Content/galleryPics/galleryThumbs"); // path -> fullständig fysisk filnamn inklusive sökväg

            //Kontrollerar så att bilden är av korrekt typ
            if (!IsValidImage(image))
            {
                throw new InvalidDataException("Bilden är av fel typ.");
            }

            //Kontrollerar om bilden redan finns, lägger till en siffra i slutet isf.
            while (ImageExists(fileName))
            {
                string imageNameWithoutExtention = Path.GetFileNameWithoutExtension(String.Format("{0}/{1}", PhysicalApplicationPath, fileName));
                string imageNameExtention = Path.GetExtension(String.Format("{0}/{1}", PhysicalApplicationPath, fileName));

                fileName = String.Format("{0}{1}{2}", imageNameWithoutExtention, existingImageCount, imageNameExtention);

                existingImageCount++;
            }

            //Spara ner bild och tumnagel i respektive mapp
            image.Save(String.Format("{0}/{1}", PhysicalApplicationPath, fileName));
            thumbnail.Save(String.Format("{0}/Files/Thumbs/{1}", PhysicalApplicationPath, fileName));

            return fileName;
        }
        else
        {
            throw new ArgumentException("Filen har fel MIME-typ. Var vänlig ladda upp en korrekt bildtyp");
        }
    }
}
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
    #region
    private static readonly Regex ApprovedExenstions;
    public static string PhysicalApplicationPath { get; set; }
    static Gallery()
    {
        Regex ApprovedExenstions = new Regex("^.*.(gif|jpg|png)", RegexOptions.IgnoreCase);
    }
    #endregion
    #region
    //HÄMTAR BILDER SOM REDAN FINNS I GALLERIET
    public List<string> GetImageNames()
    {
        string path = PhysicalApplicationPath;
        var di = new DirectoryInfo(path);

        List<string> fileList = new List<string>();

        FileInfo[] files = di.GetFiles();
        for (int i = 0; i < files.Length; i++)
        {
            fileList.Add(files[i].Name);
        }
        return fileList;
    }
    #endregion 
    #region
    //BILD REDAN FINNS
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
    #endregion
    #region
    //BILDVALIDERING
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
    #endregion
    #region
    //SPARA BILD
    public string SaveImage(Stream stream, string fileName)
    {

        if (true)
        {
            int existingImageCount = 15;
            var path = PhysicalApplicationPath;

            var image = System.Drawing.Image.FromStream(stream); // stream -> ström med bild
            var thumbnail = image.GetThumbnailImage(60, 45, null, System.IntPtr.Zero);

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

            try
            {
                //Spara ner bild och tumnagel i respektive mapp
                thumbnail.Save(String.Format("{0}/thumbs/{1}", PhysicalApplicationPath, fileName));
                image.Save(String.Format("{0}/{1}", PhysicalApplicationPath, fileName));
                

                return fileName;
            }
            catch
            {
                throw new ArgumentException("Fel inträffa, var god försök igen");
            }
        }
        else
        {
            throw new ArgumentException("Filen har fel MIME-typ. Var vänlig ladda upp en korrekt bildtyp");
        }
    }
    #endregion
}
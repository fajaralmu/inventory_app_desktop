using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Windows.Models;
using System.Diagnostics;
using Inventory_Windows.Properties;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Net.Mail;
using System.Drawing.Imaging;

namespace Inventory_Windows.Utils
{
    class Generator
    {
        static Random random = new Random();

        public static void main(String[] args)
        {
            try
            {
                //get image
                object O = Resources.ResourceManager.GetObject("Resources/kiis.jpg");
                Debug.WriteLine("ResourceManager result 1 :" + (O.GetType()));
                Debug.WriteLine("ResourceManager result 2 :" + (O.GetType()));
            }
            catch (Exception e)
            {

                Debug.WriteLine("ERROR :" + e.Message);
            }
        }

        static string randomNumber()
        {
            return DateTime.Now.Millisecond.ToString();
        }

        internal static void generateSticker(List<StickerData> stickerData, Institution institution, string saveToPath)
        {
            Debug.WriteLine("generateSticker , count: " + stickerData.Count);
            for (int i = 0; i < stickerData.Count; i++)
            {
                generateOneSticker(stickerData[i], institution, saveToPath);
            }
        }

        internal static void generateOneSticker(StickerData stickerData, Institution institution, string saveToPath)
        {

            Debug.WriteLine("institution: " + institution);
            Debug.WriteLine("SAVE TO PATH: " + saveToPath);
            try
            {
                //get image
                Image Image = Image.FromFile("Resources/kiis.jpg");
                Debug.WriteLine("ResourceManager result :" + (Image == null ? "TRUE" : "FALSE" + Image.GetType()));

                if (null != Image)
                {
                    //write image 
                    PixelFormat pf;
                    pf = PixelFormat.Format32bppArgb;
                    Bitmap BM = new Bitmap(200, 200, pf); //This is the Bitmap Image; you have not yet selected a file,
                    Brush B = new SolidBrush(Color.Orange);                               //Bitmap BM = new Bitmap(Image.FromFile(@"D:\Resources\International\Picrofo_Logo.png"), rect.Width, rect.Height);
                    Graphics g = Graphics.FromImage(BM);
                    g.FillRectangle(B, 0, 0, 200, 200);
                    g.DrawImage(Image, 0, 0, 50, 50);
                    string fullPath = saveToPath + "/" + stickerData.itemName + ".png";
                    BM.Save(fullPath, ImageFormat.Png);
                    Debug.WriteLine("SUCCESS SAVING IMAGE:" + fullPath);

                }

                //var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                //var logoimage = Path.Combine(outPutDirectory, "Resources\\ALKAHFI.png");
                //string relLogo = new Uri(logoimage).LocalPath;
                //LinkedResource LinkedResource = new LinkedResource(relLogo);
                //Debug.WriteLine("ResourceManager result :" + (LinkedResource == null ? "NULL" : "FOUND"));// + O.GetType()));
                //if(null!= LinkedResource)
                //{
                //     //Image.FromFile(LinkedResource.ContentLink.LocalPath);  
                //}
            }
            catch (Exception e)
            {

                Debug.WriteLine("ERROR :" + e.Message);
            }

        }
    }
}

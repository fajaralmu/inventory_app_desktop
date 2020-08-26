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

namespace Inventory_Windows.Utils
{
    class Generator
    {

        public static void main(String[] args)
        {
            try
            {
                //get image
                object O = Resources.ResourceManager.GetObject("Resources/kiis.jpg");
                Debug.WriteLine("ResourceManager result 1 :" + (O .GetType()));
                Debug.WriteLine("ResourceManager result 2 :" + (O.GetType()));
            }
            catch (Exception e)
            {

                Debug.WriteLine("ERROR :" + e.Message);
            }
        }

        internal static void generateSticker(List<StickerData> stickerData, Institution institution, string saveToPath)
        {

            Debug.WriteLine("institution: " + institution);
            Debug.WriteLine("SAVE TO PATH: " + saveToPath);
            try {
                //get image
                Image Image = Image.FromFile("Resources/kiis.jpg");
                Debug.WriteLine("ResourceManager result :" + (Image == null ? "TRUE" : "FALSE" + Image.GetType()));

                if(null!= Image)
                {

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
            catch(Exception e)
            {
                
                Debug.WriteLine("ERROR :"+ e.Message);
            }

        }
    }
}

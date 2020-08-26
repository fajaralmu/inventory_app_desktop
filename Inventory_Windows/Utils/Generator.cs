using System;
using System.Collections.Generic;
using Inventory_Windows.Models;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Linq;

namespace Inventory_Windows.Utils
{
    class Generator
    {
        static Random random = new Random();
        private Institution institution;
        private string saveToPath;


        const int STICKER_WIDTH = 188;
        const int STICKER_HEIGHT = 66;

        const int PAPER_HEIGHT = 792;
        const int PAPER_WIDTH = 622;

        private int count = 0;


        public Generator(Institution institution, string saveToPath)
        {
            this.institution = institution;
            this.saveToPath = saveToPath;
        }

        string randomNumber()
        {
            return DateTime.Now.Millisecond.ToString();
        }

        internal void generateSticker(List<StickerData> stickerData)
        {
            List<Image> images = new List<Image>();
            Debug.WriteLine("generateSticker , count: " + stickerData.Count);

            try
            {
                for (int i = 0; i < stickerData.Count; i++)
                {
                    Image sticker = generateOneSticker(stickerData[i]);
                    images.Add(sticker);
                }
                combineStickers(images);
                Process.Start("explorer.exe", @saveToPath);
            }
            catch (Exception e)
            {
                MyDialog.info("ERROR :" + e.Message);
            }
        }

        internal Image generateOneSticker(StickerData stickerData)
        {

            Debug.WriteLine("institution: " + institution);
            Debug.WriteLine("SAVE TO PATH: " + saveToPath);
            try
            {
                string imgName;
                if (institution.Equals(Institution.MTS_ALKAHFI))
                {
                    imgName = "ALKAHFI.png";
                }
                else
                {
                    imgName = "kiis.jpg";
                }
                //get image
                Image Image = Image.FromFile("Resources/" + imgName);
                Debug.WriteLine("ResourceManager result :" + (Image == null ? "TRUE" : "FALSE" + Image.GetType()));

                if (null != Image)
                {
                    //write image 
                    PixelFormat pf = PixelFormat.Format32bppArgb;
                    Bitmap Canvas = new Bitmap(STICKER_WIDTH, STICKER_HEIGHT, pf); //This is the Bitmap Image; you have not yet selected a file,
                    Brush BackgroundBrush = new SolidBrush(Color.White);                               //Bitmap BM = new Bitmap(Image.FromFile(@"D:\Resources\International\Picrofo_Logo.png"), rect.Width, rect.Height);

                    Graphics g = Graphics.FromImage(Canvas);

                    //draw background 
                    g.FillRectangle(BackgroundBrush, 0, 0, STICKER_WIDTH, STICKER_HEIGHT);

                    //draw logo
                    g.DrawImage(Image, 3, 2, 60, 60);

                    //draw content
                    //g2d.setColor(Color.BLACK);

                    float stringXIndex = STICKER_HEIGHT + 3;
                    //Institution
                    String institutionAlias = getInstitutionAlias(stickerData.institution);
                    //if (institutionAlias.length() <= 17)
                    //{
                    //    g2d.setFont(new Font("Arial", Font.BOLD, 13));
                    //}
                    //else {
                    //    g2d.setFont(new Font("Arial", Font.BOLD, 10));
                    //}
                    Brush fontBrush = new SolidBrush(Color.Black);
                    Font Font = new Font("Arial", 8);
                    Font TitleFont = new Font("Arial", 8, FontStyle.Bold);

                    int reducer = 12;
                    g.DrawString(institutionAlias, TitleFont, fontBrush, stringXIndex, 15 - reducer);
                    g.DrawString(stickerData.itemName, Font, fontBrush, stringXIndex, 32 - reducer);
                    g.DrawString(stickerData.date, Font, fontBrush, stringXIndex, 47 - reducer);
                    g.DrawString(stickerData.code, Font, fontBrush, stringXIndex, 62 - reducer);

                    //draw borders 
                    //GENERAL BORDER
                    Pen outerPen = new Pen(Color.Black, 4);
                    Pen contentPen = new Pen(Color.Black, 1);

                    g.DrawRectangle(outerPen, 0, 0, STICKER_WIDTH - 1, STICKER_HEIGHT - 1);
                    //contents borders
                    int borderXIndex = STICKER_WIDTH - STICKER_HEIGHT;
                    g.DrawRectangle(contentPen, STICKER_HEIGHT, 0, borderXIndex, 18); //institution
                    g.DrawRectangle(contentPen, STICKER_HEIGHT, 18, borderXIndex, 16); //name
                    g.DrawRectangle(contentPen, STICKER_HEIGHT, 34, borderXIndex, 16); //date
                    g.DrawRectangle(contentPen, STICKER_HEIGHT, 50, borderXIndex, 16); //code 

                    string fullPath = saveToPath + "/" + institution + "-" + stickerData.itemName + "_" + count + ".png";
                    Canvas.Save(fullPath, ImageFormat.Png);

                    Debug.WriteLine("SUCCESS SAVING IMAGE:" + fullPath);
                    count++;
                    return Canvas;

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

            return null;

        }

        private string getInstitutionAlias(Institution institution)
        {
            try
            {
                Type t = institution.GetType(); 
                Debug.WriteLine("TYPE: " + t.Name);
                Debug.WriteLine("props Count: " + t.GetMembers().Length);
                MemberInfo[] memberInfos = t.GetMember(institution.ToString());
                MemberInfo memberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType.Name == typeof(Institution).Name);
                Debug.WriteLine("prop: " + memberInfo.Name);
                InstitutionInfo info = (InstitutionInfo)memberInfo.GetCustomAttribute(typeof(InstitutionInfo));

                return info.Alias;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error getting institution alias: " + e.Message);
                return institution.ToString();
            }
        }


        private void combineStickers(List<Image> stickerImages)
        {
            PixelFormat pf = PixelFormat.Format32bppArgb;
            Bitmap Canvas = new Bitmap(PAPER_WIDTH, PAPER_HEIGHT, pf);
            Brush BackgroundBrush = new SolidBrush(Color.White);                               //Bitmap BM = new Bitmap(Image.FromFile(@"D:\Resources\International\Picrofo_Logo.png"), rect.Width, rect.Height);

            Graphics g = Graphics.FromImage(Canvas);

            //draw background 
            g.FillRectangle(BackgroundBrush, 0, 0, PAPER_WIDTH, PAPER_HEIGHT);

            //draw background  
            int topAndRightOffset = 20; //6 mm
            int bottomAndLeftOffset = 10;//2mm;

            for (int i = 0, xCounter = 0, yCounter = 0; i < stickerImages.Count; i++, xCounter++)
            {
                Image stickerImage = stickerImages[i];

                int x = 11 + (STICKER_WIDTH + topAndRightOffset) * xCounter;
                int y = 24 + (STICKER_HEIGHT + bottomAndLeftOffset) * yCounter; //9

                g.DrawImage(stickerImage, x, y, stickerImage.Width, stickerImage.Height);

                if (xCounter >= 2)
                {
                    xCounter = -1;
                    yCounter++;
                }

            }
            Pen b = new Pen(Color.Black);
            g.DrawRectangle(b, 0, 0, PAPER_WIDTH - 1, PAPER_HEIGHT - 1);

            //FileUtil.writeImageToFile(result, fullFilePath + "/" + id + institution.name() + "_STICKER_GENERATED.png", "png");
            Canvas.Save(saveToPath + "/" + institution + "-ALL.png", ImageFormat.Png);

        }
    }
}

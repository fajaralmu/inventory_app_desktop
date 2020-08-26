﻿using System;
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
        private Institution institution;
        private string saveToPath;


        const int STICKER_WIDTH = 188;
        const int STICKER_HEIGHT = 66;

        const int PAPER_HEIGHT = 792;
        const int PAPER_WIDTH = 622;


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
            Debug.WriteLine("generateSticker , count: " + stickerData.Count);
            for (int i = 0; i < stickerData.Count; i++)
            {
                generateOneSticker(stickerData[i]);
            }
        }

        internal void generateOneSticker(StickerData stickerData)
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
                Image Image = Image.FromFile("Resources/"+imgName);
                Debug.WriteLine("ResourceManager result :" + (Image == null ? "TRUE" : "FALSE" + Image.GetType()));

                if (null != Image)
                {
                    //write image 
                    PixelFormat pf = PixelFormat.Format32bppArgb;
                    Bitmap BM = new Bitmap(STICKER_WIDTH, STICKER_HEIGHT, pf); //This is the Bitmap Image; you have not yet selected a file,
                    Brush BackgroundBrush = new SolidBrush(Color.White);                               //Bitmap BM = new Bitmap(Image.FromFile(@"D:\Resources\International\Picrofo_Logo.png"), rect.Width, rect.Height);

                    Graphics g = Graphics.FromImage(BM);

                    //draw background 
                    g.FillRectangle(BackgroundBrush, 0, 0, STICKER_WIDTH, STICKER_HEIGHT);

                    //draw logo
                    g.DrawImage(Image, 3, 3, 60, 60);

                    //draw content
                    //g2d.setColor(Color.BLACK);

                    float stringXIndex = STICKER_HEIGHT + 3;
                    //Institution
                    String institutionAlias = stickerData.institution.ToString();
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

                    int reducer = 11;
                    g.DrawString(stickerData.institution.ToString(), TitleFont, fontBrush, stringXIndex, 15 - reducer);
                    g.DrawString(stickerData.itemName, Font, fontBrush, stringXIndex, 32 - reducer);
                    g.DrawString(stickerData.date, Font, fontBrush, stringXIndex, 47 - reducer);
                    g.DrawString(stickerData.code, Font, fontBrush, stringXIndex, 62 - reducer);

                    //Name, Date, Code
                    //g2d.setFont(new Font("Arial", Font.PLAIN, 12));
                    //g2d.drawString(stickerData.getItemName(), stringXIndex, 32);
                    //g2d.drawString(stickerData.getDate(), stringXIndex, 47);
                    //g2d.drawString(stickerData.getCode(), stringXIndex, 62);

                    //draw borders
                    //Stroke oldStroke = g2d.getStroke();
                    //g2d.setStroke(new BasicStroke(4));
                    //g2d.drawRect(0, 0, STICKER_WIDTH - 1, STICKER_HEIGHT - 1); //main border
                    //GENERAL BORDER
                    g.DrawRectangle(new Pen(Color.Black, 4), 0, 0, STICKER_WIDTH - 1, STICKER_HEIGHT - 1);

                    Pen pen2 = new Pen(Color.Black, 1); 
                    //g.DrawRectangle(pen, 0, 0, STICKER_HEIGHT, STICKER_HEIGHT);

                    //contents borders
                    int borderXIndex = STICKER_WIDTH - STICKER_HEIGHT;
                    g.DrawRectangle(pen2, STICKER_HEIGHT, 0, borderXIndex, 18); //institution
                    g.DrawRectangle(pen2, STICKER_HEIGHT, 18, borderXIndex, 16); //name
                    g.DrawRectangle(pen2, STICKER_HEIGHT, 34, borderXIndex, 16); //date
                    g.DrawRectangle(pen2, STICKER_HEIGHT, 50, borderXIndex, 16); //code 

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

using Inventory_Windows.Models;
using Inventory_Windows.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Windows.Views
{
    public partial class StickerGenerator : Form
    {
        public Institution institution { get; set; }
        private Form parent;
        //private FolderBrowserDialog folderChooser;
        private string saveToPath;

        public StickerGenerator(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            //this.folderChooser = new FolderBrowserDialog();
        }



        public void ShowPage()
        {
            this.Show();
            parent.Hide();
            init();
        }

        private void init()
        {
            this.txtInstitutionName.Text = institution.ToString();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (MyDialog.confirm("Do you want to exit?"))
            {
                Application.Exit();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            parent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setSaveToPath();
        }

        private void setSaveToPath()
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                //setup here

                if (dialog.ShowDialog() == DialogResult.OK)  //check for OK...they might press cancel, so don't do anything if they did.
                {
                    saveToPath = dialog.SelectedPath;
                    txtSavePath.Text = saveToPath;
                    //do something with path
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            generateStickers();
        }

        private void generateStickers()
        {
            if (saveToPath == null || saveToPath.Equals(""))
            {
                MyDialog.info("Please choose folder to save file");
                return;
            }
            List<StickerData> stickerData = getStickerData();

            Generator Generator = new Generator(institution, saveToPath);
            Generator.generateSticker(stickerData);
        }

        private List<StickerData> getStickerData()
        {
            List<StickerData> result = new List<StickerData>();
            if (checkBoxTestMode.Checked)
            {
                result = generateTestData();
            }
            return result;
        }

        private List<StickerData> generateTestData()
        {
            List<StickerData> result = new List<StickerData>();
            for (int i = 1; i <= 27; i++)
            {
                StickerData data = new StickerData
                {
                    itemName = "Test " + i,
                    date = DateTime.Now.ToString(),
                    code = "CODE" + i,
                    institution = institution
                };
                result.Add(data);
            }
            return result;
        }
    }
}

using Inventory_Windows.Models;
using Inventory_Windows.Views;
using System; 
using System.Windows.Forms;

namespace Inventory_Windows
{
    public partial class Home : Form
    {
        private Form parent;
        private StickerGenerator sticketGenerator;

        public Home(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            sticketGenerator = new StickerGenerator(this);
        }

        public virtual void ShowPage()
        {
            parent.Hide();
            base.Show();
            
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.Hide();
            this.parent.Show();
        }

        private void btnMtsKafila_Click(object sender, EventArgs e)
        {
            gotoStickerGeneratorPage(Institution.MTS_KAFILA);
        }

        private void btnMtsFullDay_Click(object sender, EventArgs e)
        {
            gotoStickerGeneratorPage(Institution.MTS_FULLDAY);
        }

        private void btnMtsAlkahfi_Click(object sender, EventArgs e)
        {
            gotoStickerGeneratorPage(Institution.MTS_ALKAHFI);
        }

        private void btnMasKafila_Click(object sender, EventArgs e)
        {
            gotoStickerGeneratorPage(Institution.MAS_KAFILA);
        }

        private void btnYayasan_Click(object sender, EventArgs e)
        {
            gotoStickerGeneratorPage(Institution.YAYASAN_KAFILA_THOYIBA);
        }

        private void gotoStickerGeneratorPage(Institution institution)
        {
            
            sticketGenerator.institution = institution;
            sticketGenerator.ShowPage();
           
        }
    }
}

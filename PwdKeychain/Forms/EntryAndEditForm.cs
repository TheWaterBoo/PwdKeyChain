using System.Windows.Forms;

namespace PwdKeychain
{
    public partial class EntryAndEditForm : Form
    {
        public string Website
        {
            get => websiteTxtBox.Text;
            set => websiteTxtBox.Text = value;
        }
        
        public EntryAndEditForm()
        {
            InitializeComponent();
        }
    }
}
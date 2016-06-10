
using ReporteKad.Clases;
using System.Windows.Forms;

namespace ReporteKad
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            IteractionBD.ConectionSQL(RutaBD.BDConection());
        }
    }
}

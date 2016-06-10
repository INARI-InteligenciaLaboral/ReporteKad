
using ReporteKad.Clases;
using System.Data;
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
            DataTable m_Empleados = new DataTable();
            m_Empleados = IteractionBD.ConectionSQL(RutaBD.BDConection());
            clbEmpleados.DataSource = m_Empleados;
            clbEmpleados.DisplayMember = "Employee";
            clbEmpleados.ValueMember = "id";
        }

        private void btnGenerar_Click(object sender, System.EventArgs e)
        {
            foreach(DataRowView drv in clbEmpleados.CheckedItems)
            {
                MessageBox.Show(drv[clbEmpleados.ValueMember].ToString());
            }
        }
    }
}

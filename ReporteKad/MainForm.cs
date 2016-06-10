
using ReporteKad.Clases;
using System.Data;
using System.Windows.Forms;

namespace ReporteKad
{
    public partial class MainForm : Form
    {
        public bool m_EsClick = true;
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

        private void cbxAll_CheckedChanged(object sender, System.EventArgs e)
        {
            if (m_EsClick)
            {
                if (cbxAll.Checked)
                {
                    for (int index = 0; index < clbEmpleados.Items.Count; index++)
                        clbEmpleados.SetItemChecked(index, true);
                }
                else
                {
                    for (int index = 0; index < clbEmpleados.Items.Count; index++)
                        clbEmpleados.SetItemChecked(index, false);
                }
            }
        }

        private void clbEmpleados_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (clbEmpleados.Items.Count == clbEmpleados.CheckedItems.Count)
            {
                m_EsClick = false;
                cbxAll.Checked = true;
                m_EsClick = true;
            }
            else
            {
                m_EsClick = false;
                cbxAll.Checked = false;
                m_EsClick = true;
            }
        }
    }
}

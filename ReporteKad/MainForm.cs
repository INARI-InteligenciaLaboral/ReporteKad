
using System.Windows.Forms;
using System.Data.SQLite;

namespace ReporteKad
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void ConectionSQL()
        {
            
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            string m_Conexion = "Data Source=C:\\Users\\TI-proganalista\\Documents\\AccessPROTimeNet.db;Version=3;";
            System.Data.SQLite.SQLiteConnection objcon = new SQLiteConnection(m_Conexion);
            System.Data.SQLite.SQLiteCommand objcomand;
            System.Data.SQLite.SQLiteDataReader objreader;
            try
            {
                objcon.Open();
                objcomand = objcon.CreateCommand();
                objcomand.CommandText = "SELECT hr_employee.id || ' ' || emp_firstname || ' ' || emp_lastname as Employee, att_punches.punch_time FROM att_punches INNER JOIN hr_employee ON att_punches.emp_id = hr_employee.id ORDER BY hr_employee.id, punch_time desc";
                objreader = objcomand.ExecuteReader();
                while (objreader.Read())
                {
                    MessageBox.Show("Leido");
                }
            }
            catch { }
        }
    }
}

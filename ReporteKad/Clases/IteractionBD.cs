using System.Data;
using System.Data.SQLite;

namespace ReporteKad.Clases
{
    public class IteractionBD
    {
        public static DataTable ConectionSQL(string m_Cadena)
        {
            DataTable m_empleados = new DataTable();
            string m_Conexion = "Data Source=" + m_Cadena + ";Version=3;";
            string m_Comand = "SELECT id, hr_employee.id || ' ' || emp_firstname || ' ' || emp_lastname ";
            m_Comand += "as Employee FROM hr_employee ORDER BY hr_employee.id";
            SQLiteConnection objcon = new SQLiteConnection(m_Conexion);
            SQLiteCommand m_adapter = new SQLiteCommand(m_Comand, objcon);
            try
            {
                objcon.Open();
                m_empleados.Load(m_adapter.ExecuteReader());
                objcon.Close();
            }
            catch { }
            return m_empleados;
        }
    }
}

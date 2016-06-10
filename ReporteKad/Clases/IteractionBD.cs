using System.Data.SQLite;

namespace ReporteKad.Clases
{
    public class IteractionBD
    {
        public static string ConectionSQL(string m_Cadena)
        {
            string m_Conexion = "Data Source=" + m_Cadena + ";Version=3;";
            SQLiteConnection objcon = new SQLiteConnection(m_Conexion);
            SQLiteCommand objcomand;
            SQLiteDataReader objreader;
            try
            {
                objcon.Open();
                objcomand = objcon.CreateCommand();
                objcomand.CommandText = "SELECT hr_employee.id || ' ' || emp_firstname || ' ' || emp_lastname as Employee, att_punches.punch_time FROM att_punches INNER JOIN hr_employee ON att_punches.emp_id = hr_employee.id ORDER BY hr_employee.id, punch_time desc";
                objreader = objcomand.ExecuteReader();
                while (objreader.Read())
                {
                    
                }
            }
            catch { }
            return "";
        }
    }
}

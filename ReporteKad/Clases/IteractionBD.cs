using System;
using System.Collections;
using System.Data;
using System.Data.SQLite;

namespace ReporteKad.Clases
{
    public class IteractionBD
    {
        public static DataTable ObtenerEmpleados(string m_Cadena)
        {
            DataTable m_empleados = new DataTable();
            string m_Conexion = "Data Source=" + m_Cadena + ";Version=3;";
            string m_Comand = "SELECT id, hr_employee.id || ' ' || emp_firstname || ' ' || emp_lastname ";
            m_Comand += "as Employee FROM hr_employee WHERE emp_active = 1 ORDER BY hr_employee.id";
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
        public static DataTable ObtenerRegistros(string m_IDEmpledo, DateTime m_FechaInicio, DateTime m_FechaFin, string m_Cadena)
        {
            DataTable m_registros = new DataTable();
            string m_Conexion = "Data Source=" + m_Cadena + ";Version=3;";
            string m_command = "SELECT punch_time, emp_id FROM att_punches ";
            m_command += "WHERE emp_id = " + m_IDEmpledo + " AND punch_time BETWEEN @FechaInicio AND @FechaFin";
            using (SQLiteConnection m_conexion = new SQLiteConnection(m_Conexion))
            {
                SQLiteCommand command = new SQLiteCommand(m_command, m_conexion);
                command.Parameters.Add(new SQLiteParameter("@FechaInicio", m_FechaInicio));
                command.Parameters.Add(new SQLiteParameter("@FechaFin", m_FechaFin.AddDays(1)));
                try
                {
                    m_conexion.Open();
                    m_registros.Load(command.ExecuteReader());
                    m_conexion.Close();
                }
                catch { }
            }
            return m_registros;
        }
        public static DataTable ObtenerPermisos(string m_IDEmpledo, DateTime m_FechaInicio, DateTime m_FechaFin, string m_Cadena)
        {
            DataTable m_permisos = new DataTable();
            string m_Conexion = "Data Source=" + m_Cadena + ";Version=3;";
            string m_command = "SELECT exc.exception_date, exc.starttime, exc.endtime, exc.employee_id, pay.pc_desc  FROM ";
            m_command += "att_exceptionassign AS exc INNER JOIN att_paycode AS pay ON exc.paycode_id = pay.id ";
            m_command += "WHERE exc.employee_id = " + m_IDEmpledo + " AND exc.exception_date BETWEEN @FechaInicio AND @FechaFin";
            using (SQLiteConnection m_conexion = new SQLiteConnection(m_Conexion))
            {
                SQLiteCommand command = new SQLiteCommand(m_command, m_conexion);
                command.Parameters.Add(new SQLiteParameter("@FechaInicio", m_FechaInicio));
                command.Parameters.Add(new SQLiteParameter("@FechaFin", m_FechaFin.AddDays(1)));
                try
                {
                    m_conexion.Open();
                    m_permisos.Load(command.ExecuteReader());
                    m_conexion.Close();
                }
                catch { }
            }
            return m_permisos;
        }
        public static DataTable ObtenerHorario(string m_IDEmpledo, string m_Cadena)
        {
            DataTable m_Horarios = new DataTable();
            string m_Conexion = "Data Source=" + m_Cadena + ";Version=3;";
            string m_Comand = "SELECT shift_name, shift_start, shift_end, strftime('%w', sdet.schedule_date) AS dia_semana, schedule_date ";
            m_Comand += "FROM att_shift AS shi INNER JOIN att_schedule_details AS sdet ON shi.id = sdet.shift_id INNER JOIN ";
            m_Comand += "hr_employee AS emp ON emp.schedule_id = sdet.schedule_id  WHERE emp.id = " + m_IDEmpledo;
            SQLiteConnection objcon = new SQLiteConnection(m_Conexion);
            SQLiteCommand m_adapter = new SQLiteCommand(m_Comand, objcon);
            try
            {
                objcon.Open();
                m_Horarios.Load(m_adapter.ExecuteReader());
                objcon.Close();
            }
            catch { }
            return m_Horarios;
        }
        public static DataTable ObtenerHorMin(string m_Cadena)
        {
            DataTable m_permisos = new DataTable();
            string m_Conexion = "Data Source=" + m_Cadena + ";Version=3;";
            string m_command = "SELECT shift_name, shift_start, shift_end, strftime('%w', @FechaInicio) AS dia_semana, date(@FechaInicio) AS schedule_date FROM att_shift";
            using (SQLiteConnection m_conexion = new SQLiteConnection(m_Conexion))
            {
                SQLiteCommand command = new SQLiteCommand(m_command, m_conexion);
                command.Parameters.Add(new SQLiteParameter("@FechaInicio", DateTime.Parse("13/06/2016 00:00:00.00")));
                try
                {
                    m_conexion.Open();
                    m_permisos.Load(command.ExecuteReader());
                    m_conexion.Close();
                }
                catch { }
            }
            return m_permisos;
        }
    }
}

using System;
using System.Collections;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace ReporteKad.Clases
{
    public class GenerarInsidencias
    {
        public static string GenInsEmp(string m_cadena, ArrayList m_empleados, DateTime m_FecInicio, DateTime m_FecFin)
        {
            int m_filaexcel = 1;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            Excel.Range chartRange;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


            string m_Reporte = string.Empty;
            foreach (var m_Row in m_empleados)
            {
                var m_ObjEmp = (Modelos.Empleados)m_Row;
                DataTable m_Horario = new DataTable();
                DataTable m_permisos = new DataTable();
                DataTable m_Registros = new DataTable();
                m_Horario = IteractionBD.ObtenerHorario(m_ObjEmp.Id, m_cadena);
                if (!(m_Horario.Rows.Count > 0 ))
                    m_Horario = generarHorMin( m_cadena);
                m_permisos = IteractionBD.ObtenerPermisos(m_ObjEmp.Id,m_FecInicio, m_FecFin, m_cadena);
                m_Registros = IteractionBD.ObtenerRegistros(m_ObjEmp.Id, m_FecInicio, m_FecFin, m_cadena);

                xlWorkSheet.get_Range("a" + m_filaexcel, "e" + (m_filaexcel)).Merge(false);
                chartRange = xlWorkSheet.get_Range("a" + m_filaexcel, "e" + (m_filaexcel));
                chartRange.FormulaR1C1 = "Registro de Asistencia";
                chartRange.HorizontalAlignment = 3;
                chartRange.VerticalAlignment = 3;
                chartRange.Font.Size = 12;
                m_filaexcel ++;

                xlWorkSheet.get_Range("a" + m_filaexcel, "e" + (m_filaexcel)).Merge(false);
                chartRange = xlWorkSheet.get_Range("a" + m_filaexcel, "e" + (m_filaexcel));
                chartRange.FormulaR1C1 = m_ObjEmp.NombreCompleto;
                chartRange.HorizontalAlignment = 3;
                chartRange.VerticalAlignment = 3;
                chartRange.Font.Size = 10;
                chartRange.Font.Bold = true;
                m_filaexcel++;
            }
            xlWorkBook.SaveAs("e:\\csharp.net-informations.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlApp);
            releaseObject(xlWorkBook);
            releaseObject(xlWorkSheet);

            return m_Reporte;

        }
        private static DataTable generarHorMin(string m_cadena)
        {
            DataTable m_Horario = new DataTable();
            DataTable m_HorarioReturn = new DataTable();
            m_HorarioReturn.Columns.Add("shift_name", typeof(string));
            m_HorarioReturn.Columns.Add("shift_start", typeof(string));
            m_HorarioReturn.Columns.Add("shift_end", typeof(string));
            m_HorarioReturn.Columns.Add("dia_semana", typeof(int));
            m_HorarioReturn.Columns.Add("schedule_date", typeof(DateTime));
            m_Horario = IteractionBD.ObtenerHorMin(m_cadena);
            foreach (DataRow m_Rows in m_Horario.Rows)
            {
                DataRow m_rowretun;
                m_rowretun = m_HorarioReturn.NewRow();
                m_rowretun["shift_name"] = m_Rows[0].ToString();
                m_rowretun["shift_start"] = m_Rows[1].ToString();
                m_rowretun["shift_end"] = m_Rows[2].ToString();
                m_rowretun["dia_semana"] = int.Parse(m_Rows[3].ToString());
                m_rowretun["schedule_date"] = DateTime.Parse(m_Rows[4].ToString());
                m_HorarioReturn.Rows.Add(m_rowretun);
                for (int i = 1; i < 5; i++)
                {
                    DataRow m_row;
                    m_row = m_HorarioReturn.NewRow();
                    m_row["shift_name"] = m_Rows[0].ToString();
                    m_row["shift_start"] = m_Rows[1].ToString();
                    m_row["shift_end"] = m_Rows[2].ToString();
                    m_row["dia_semana"] = int.Parse(m_Rows[3].ToString()) + i;
                    m_row["schedule_date"] = DateTime.Parse(m_Rows[4].ToString()).AddDays(i);
                    m_HorarioReturn.Rows.Add(m_row);
                }
            }
            return m_HorarioReturn;
        }
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}

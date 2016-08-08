using System;
using System.Collections;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace ReporteKad.Clases
{
    public class GenerarInsidencias
    {
        public static bool GenInsEmp(string m_cadena, ArrayList m_empleados, DateTime m_FecInicio, DateTime m_FecFin, string m_ruta_archivo)
        {
            int m_filaexcel = 1;
            DateTime m_FechaResp = m_FecInicio;
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            Excel.Range chartRange;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


            string m_Reporte = string.Empty;
            xlWorkSheet.get_Range("a" + m_filaexcel, "i" + (m_filaexcel)).Merge(false);
            chartRange = xlWorkSheet.get_Range("a" + m_filaexcel, "i" + (m_filaexcel));
            chartRange.FormulaR1C1 = "Registro de Asistencia";
            chartRange.HorizontalAlignment = 3;
            chartRange.VerticalAlignment = 3;
            chartRange.Font.Size = 12;
            chartRange.Font.Bold = true;
            m_filaexcel++;
            xlWorkSheet.get_Range("a" + m_filaexcel, "i" + (m_filaexcel)).Merge(false);
            chartRange = xlWorkSheet.get_Range("a" + m_filaexcel, "i" + (m_filaexcel));
            chartRange.FormulaR1C1 = "Reporte del " + m_FecInicio.ToString("dd/MM/yyyy") + " al " + m_FecFin.ToString("dd/MM/yyyy");
            chartRange.HorizontalAlignment = 3;
            chartRange.VerticalAlignment = 3;
            chartRange.Font.Size = 12;
            chartRange.Font.Bold = true;
            m_filaexcel++;
            xlWorkSheet.Cells[m_filaexcel, 1] = "Nombre";
            DateTime m_fec = m_FecInicio;
            for (int x = 2; m_FecFin >= m_fec; x++)
            {
                if (((int)m_fec.DayOfWeek) != 0)
                {
                    xlWorkSheet.Cells[m_filaexcel, x + 1] = m_fec.ToString("dddd\n dd");
                    m_fec = m_fec.AddDays(1);
                }
                else
                {
                    m_fec = m_fec.AddDays(1);
                    x--;
                }
            }
            m_filaexcel++;
            foreach (var m_Row in m_empleados)
            {
                var m_ObjEmp = (Modelos.Empleados)m_Row;
                DataTable m_Horario = new DataTable();
                DataTable m_permisos = new DataTable();
                DataTable m_Registros = new DataTable();
                m_Horario = IteractionBD.ObtenerHorario(m_ObjEmp.Id, m_cadena);
                if (!(m_Horario.Rows.Count > 0))
                    m_Horario = generarHorMin(m_cadena);
                m_permisos = IteractionBD.ObtenerPermisos(m_ObjEmp.Id, m_FecInicio, m_FecFin, m_cadena);
                m_Registros = IteractionBD.ObtenerRegistros(m_ObjEmp.Id, m_FecInicio, m_FecFin, m_cadena);
                xlWorkSheet.Cells[m_filaexcel, 1] = m_ObjEmp.NombreCompleto;
                xlWorkSheet.Cells[m_filaexcel, 2] = "Hor. Ent.";
                xlWorkSheet.Cells[m_filaexcel + 1, 2] = "Hor. Sal.";
                string m_Insidencias = "";
                int x = 2;
                while (m_FecFin >= m_FechaResp)
                {
                    DataRow[] r_DiaLaborable = m_Horario.Select("dia_semana = " + ((int)m_FechaResp.DayOfWeek).ToString());
                    DateTime? m_HoraIni = null;
                    DateTime? m_HoraFin = null;
                    if (r_DiaLaborable.Length > 0)
                    {
                        DataRow[] r_Permisos = m_permisos.Select("exception_date >= '" + m_FechaResp.ToString() + "' AND exception_date <= '" + (m_FechaResp.AddDays(1)).AddSeconds(-1).ToString() + "'");
                        DataRow[] r_Registros = m_Registros.Select("punch_time >= '" + m_FechaResp.ToString() + "' AND punch_time <= '" + (m_FechaResp.AddDays(1)).AddSeconds(-1).ToString() + "'", "punch_time DESC");
                        if (r_Permisos.Length > 0)
                        {
                            foreach (DataRow rowresult in r_Permisos)
                            {
                                if (!m_Insidencias.Equals(""))
                                    m_Insidencias += "\n";
                                m_Insidencias  += rowresult[4].ToString();
                            }
                        }
                        if (r_Registros.Length > 0)
                        {
                            foreach (DataRow rowresult in r_Registros)
                            {
                                if (!m_HoraFin.HasValue)
                                {
                                    m_HoraFin = DateTime.Parse(rowresult[0].ToString());
                                }
                                m_HoraIni = DateTime.Parse(rowresult[0].ToString());
                            }
                            if (((int)m_FechaResp.DayOfWeek) == 6)
                            {
                                xlWorkSheet.Cells[m_filaexcel, x + 1] = m_HoraIni.Value.ToString("HH:mm");
                                xlWorkSheet.Cells[m_filaexcel + 1, x + 1] = m_HoraFin.Value.ToString("HH:mm");
                            }
                            else
                            {
                                xlWorkSheet.Cells[m_filaexcel, x + 1] = m_HoraIni.Value.ToString("HH:mm");
                                if (m_HoraIni == m_HoraFin)
                                {
                                    xlWorkSheet.Cells[m_filaexcel + 1, x + 1] = "";
                                }
                                else
                                {
                                    xlWorkSheet.Cells[m_filaexcel + 1, x + 1] = m_HoraFin.Value.ToString("HH:mm");
                                }
                            }
                        }
                        else
                        {
                            if (r_Permisos.Length == 0)
                            {
                                xlWorkSheet.Cells[m_filaexcel, x + 1] = "Falta";
                                xlWorkSheet.Cells[m_filaexcel + 1, x + 1] = "";
                            }
                        }
                        if (((int)m_FechaResp.DayOfWeek) != 0)
                            x++;
                    }
                    else
                    {
                        DataRow[] r_Registros = m_Registros.Select("punch_time >= '" + m_FechaResp.ToString() + "' AND punch_time <= '" + (m_FechaResp.AddDays(1)).AddSeconds(-1).ToString() + "'", "punch_time DESC");
                        if (r_Registros.Length > 0)
                        {
                            foreach (DataRow rowresult in r_Registros)
                            {
                                if (!m_HoraFin.HasValue)
                                {
                                    m_HoraFin = DateTime.Parse(rowresult[0].ToString());
                                }
                                m_HoraIni = DateTime.Parse(rowresult[0].ToString());
                            }
                            xlWorkSheet.Cells[m_filaexcel, x + 1] = m_HoraIni.Value.ToString("HH:mm");
                            xlWorkSheet.Cells[m_filaexcel + 1, x + 1] = m_HoraFin.Value.ToString("HH:mm");
                        }
                        if (((int)m_FechaResp.DayOfWeek) != 0)
                            x++;
                    }
                    m_FechaResp = m_FechaResp.AddDays(1);
                }
                xlWorkSheet.Cells[m_filaexcel, x + 1] = m_Insidencias;
                m_filaexcel += 2;
                m_FechaResp = m_FecInicio;

            }
            chartRange = xlWorkSheet.get_Range("a1", "z" + (m_filaexcel));
            chartRange.Columns.AutoFit();

            xlWorkBook.SaveAs(m_ruta_archivo, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlApp);
            releaseObject(xlWorkBook);
            releaseObject(xlWorkSheet);
            return true;
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

using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Windows.Forms;
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
                chartRange.FormulaR1C1 = m_ObjEmp.NombreCompleto;
                chartRange.HorizontalAlignment = 3;
                chartRange.VerticalAlignment = 3;
                chartRange.Font.Size = 10;
                m_filaexcel++;

                xlWorkSheet.Cells[m_filaexcel, 1] = "Fecha";
                xlWorkSheet.Cells[m_filaexcel, 2] = "";
                xlWorkSheet.Cells[m_filaexcel, 3] = "Incidencia";
                xlWorkSheet.Cells[m_filaexcel, 4] = "";
                xlWorkSheet.Cells[m_filaexcel, 5] = "Hora de Entrada";
                xlWorkSheet.Cells[m_filaexcel, 6] = "";
                xlWorkSheet.Cells[m_filaexcel, 7] = "Hora de Salida";
                xlWorkSheet.Cells[m_filaexcel, 8] = "";
                xlWorkSheet.Cells[m_filaexcel, 9] = "Comentarios";
                m_filaexcel++;
                while (m_FecFin >= m_FechaResp)
                {
                    DataRow[] r_DiaLaborable = m_Horario.Select("dia_semana = " + ((int) m_FechaResp.DayOfWeek).ToString());
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
                                xlWorkSheet.Cells[m_filaexcel, 1] = m_FechaResp.ToString("dd/MM/yyyy.");
                                xlWorkSheet.Cells[m_filaexcel, 2] = "";
                                xlWorkSheet.Cells[m_filaexcel, 3] = "Permisos";
                                xlWorkSheet.Cells[m_filaexcel, 4] = "";
                                xlWorkSheet.Cells[m_filaexcel, 5] = (DateTime.Parse(rowresult[1].ToString())).ToString("HH:mm:00");
                                xlWorkSheet.Cells[m_filaexcel, 6] = "";
                                xlWorkSheet.Cells[m_filaexcel, 7] = (DateTime.Parse(rowresult[2].ToString())).ToString("HH:mm:00");
                                xlWorkSheet.Cells[m_filaexcel, 8] = "";
                                xlWorkSheet.Cells[m_filaexcel, 9] = rowresult[4].ToString();
                                m_filaexcel++;
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
                                xlWorkSheet.Cells[m_filaexcel, 1] = m_FechaResp.ToString("dd /MM/yyyy.");
                                xlWorkSheet.Cells[m_filaexcel, 2] = "";
                                xlWorkSheet.Cells[m_filaexcel, 3] = "Sabado";
                                xlWorkSheet.Cells[m_filaexcel, 4] = "";
                                xlWorkSheet.Cells[m_filaexcel, 5] = m_HoraIni.Value.ToString("HH:mm:ss");
                                xlWorkSheet.Cells[m_filaexcel, 6] = "";
                                xlWorkSheet.Cells[m_filaexcel, 7] = m_HoraFin.Value.ToString("HH:mm:ss");
                                xlWorkSheet.Cells[m_filaexcel, 8] = "";
                                xlWorkSheet.Cells[m_filaexcel, 9] = "Dia no laboral trabajado";
                                m_filaexcel++;
                            }
                            else
                            {
                                xlWorkSheet.Cells[m_filaexcel, 1] = m_FechaResp.ToString("dd/MM/yyyy.");
                                xlWorkSheet.Cells[m_filaexcel, 2] = "";
                                xlWorkSheet.Cells[m_filaexcel, 3] = "Asistencia";
                                xlWorkSheet.Cells[m_filaexcel, 4] = "";
                                xlWorkSheet.Cells[m_filaexcel, 5] = m_HoraIni.Value.ToString("HH:mm:ss");
                                xlWorkSheet.Cells[m_filaexcel, 6] = "";
                                if (m_HoraIni == m_HoraFin)
                                {
                                    xlWorkSheet.Cells[m_filaexcel, 7] = "";
                                    xlWorkSheet.Cells[m_filaexcel, 8] = "";
                                    xlWorkSheet.Cells[m_filaexcel, 9] = "No existe registro de salida";
                                }
                                else
                                {
                                    xlWorkSheet.Cells[m_filaexcel, 7] = m_HoraFin.Value.ToString("HH:mm:ss");
                                    xlWorkSheet.Cells[m_filaexcel, 8] = "";
                                    xlWorkSheet.Cells[m_filaexcel, 9] = "";
                                }
                                m_filaexcel++;
                            }
                        }
                        else
                        {
                            if (r_Permisos.Length == 0)
                            {
                                xlWorkSheet.Cells[m_filaexcel, 1] = m_FechaResp.ToString("dd/MM/yyyy.");
                                xlWorkSheet.Cells[m_filaexcel, 2] = "";
                                xlWorkSheet.Cells[m_filaexcel, 3] = "Falta";
                                xlWorkSheet.Cells[m_filaexcel, 4] = "";
                                xlWorkSheet.Cells[m_filaexcel, 5] = "";
                                xlWorkSheet.Cells[m_filaexcel, 6] = "";
                                xlWorkSheet.Cells[m_filaexcel, 7] = "";
                                xlWorkSheet.Cells[m_filaexcel, 8] = "";
                                xlWorkSheet.Cells[m_filaexcel, 9] = "No existen registros o permisos asignados";
                                m_filaexcel++;
                            }
                        }
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
                            xlWorkSheet.Cells[m_filaexcel, 1] = m_FechaResp.ToString("dd /MM/yyyy.");
                            xlWorkSheet.Cells[m_filaexcel, 2] = "";
                            xlWorkSheet.Cells[m_filaexcel, 3] = "Sabado";
                            xlWorkSheet.Cells[m_filaexcel, 4] = "";
                            xlWorkSheet.Cells[m_filaexcel, 5] = m_HoraIni.Value.ToString("HH:mm:ss");
                            xlWorkSheet.Cells[m_filaexcel, 6] = "";
                            xlWorkSheet.Cells[m_filaexcel, 7] = m_HoraFin.Value.ToString("HH:mm:ss");
                            xlWorkSheet.Cells[m_filaexcel, 8] = "";
                            xlWorkSheet.Cells[m_filaexcel, 9] = "Dia no laboral trabajado";
                            m_filaexcel++;
                        }
                    }
                    m_FechaResp = m_FechaResp.AddDays(1);
                }
                m_filaexcel += 2;
                m_FechaResp = m_FecInicio;

            }
            chartRange = xlWorkSheet.get_Range("a1", "i" + (m_filaexcel));
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

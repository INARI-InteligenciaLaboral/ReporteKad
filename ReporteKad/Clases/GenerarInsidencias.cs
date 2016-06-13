using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReporteKad.Clases
{
    public class GenerarInsidencias
    {
        public static string GenInsEmp(string m_cadena, ArrayList m_empleados, DateTime m_FecInicio, DateTime m_FecFin)
        {
            string m_Reporte = string.Empty;
            foreach (var m_Row in m_empleados)
            {
                var m_ObjEmp = (Modelos.Empleados)m_Row;
                m_Reporte += m_ObjEmp.Id + m_ObjEmp.NombreCompleto + "\n";
            }
            return m_Reporte;
        }
    }
}

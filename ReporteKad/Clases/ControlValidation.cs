using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReporteKad.Clases
{
    public class ControlValidation
    {
        public static bool validarFechas(DateTime m_FechaInicio, DateTime m_FechaFin)
        {
            if (m_FechaInicio <= m_FechaFin)
                return true;
            else
                return false;
        }
    }
}


using ReporteKad.Clases;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace ReporteKad
{
    public partial class MainForm : Form
    {
        public bool m_EsClick = true;
        public bool m_Mensaje = true;
        public string m_RutaArchivo = "";
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            DataTable m_Empleados = new DataTable();
            m_Empleados = IteractionBD.ObtenerEmpleados(RutaBD.BDConection());
            clbEmpleados.DataSource = m_Empleados;
            clbEmpleados.DisplayMember = "Employee";
            clbEmpleados.ValueMember = "id";
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (clbEmpleados.CheckedItems.Count > 0 )
            {
                eprEmpleados.Clear();
                if (ControlValidation.validarFechas(DateTime.Parse(dtpFechaInicio.Text), DateTime.Parse(dtpFechaFin.Text)))
                {
                    eprFecInic.Clear();
                    SaveFileDialog m_Archivo = new SaveFileDialog();
                    m_Archivo.Filter = "XLS|*.xls";
                    m_Archivo.Title = string.Format(" {0} - {1} ", "Inari", "Reporte");
                    try
                    {
                        if (m_Archivo.ShowDialog() == DialogResult.OK)
                        {
                            m_RutaArchivo = m_Archivo.FileName;
                            btnGenerar.Enabled = false;
                            BackgroundWorker Procesar = new BackgroundWorker();
                            Procesar.DoWork += ProcesarReporte;
                            Procesar.RunWorkerCompleted += ProcesarTerminado;
                            Procesar.RunWorkerAsync();
                        }
                    }
                    catch
                    {  }
                }
                else
                {
                    eprFecInic.SetError(dtpFechaInicio, "La fecha de inicio debe ser menor o igual que la fecha fin");
                }
            }
            else
            {
                eprEmpleados.SetError(lblEmployee, "Seleccione por lo menos a un empleado");
            }
            
        }

        private void cbxAll_CheckedChanged(object sender, EventArgs e)
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

        private void clbEmpleados_SelectedIndexChanged(object sender, EventArgs e)
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

        private void btnGenerar_EnabledChanged(object sender, EventArgs e)
        {
            if (btnGenerar.Enabled)
            {
                if (m_Mensaje)
                    MessageBox.Show("Reporte creado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Problemas al generar reporte", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ProcesarReporte(object o, DoWorkEventArgs e)
        {
            string m_empleados = string.Empty;
            ArrayList ListaEmpleados = new ArrayList();
            foreach (DataRowView item in clbEmpleados.CheckedItems)
            {
                ListaEmpleados.Add(new Modelos.Empleados() { Id = item["Id"].ToString(), NombreCompleto = item["Employee"].ToString() });
            }
            m_Mensaje = GenerarInsidencias.GenInsEmp(RutaBD.BDConection(), ListaEmpleados, DateTime.Parse(dtpFechaInicio.Text), DateTime.Parse(dtpFechaFin.Text), m_RutaArchivo);
        }
        public void ProcesarTerminado(object o, RunWorkerCompletedEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                this.btnGenerar.Enabled = true;
            }));

        }
    }
}

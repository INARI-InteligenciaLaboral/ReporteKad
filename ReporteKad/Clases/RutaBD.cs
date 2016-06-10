using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ReporteKad.Clases
{
    public class RutaBD
    {
        public static string BDConection()
        {
            string m_UbicacionArchivo = "";
            if (!File.Exists(Application.StartupPath + "\\RutaBD.txt"))
            {
                m_UbicacionArchivo = solicitarRutaBD();
                crearArchivo(m_UbicacionArchivo);
            }
            else
            {
                string line;
                StreamReader file = new StreamReader(Application.StartupPath + "\\RutaBD.txt");
                while ((line = file.ReadLine()) != null)
                {
                    m_UbicacionArchivo = line;
                }
                file.Close();
                if (!File.Exists(m_UbicacionArchivo))
                {
                    File.Delete(Application.StartupPath + "\\RutaBD.txt");
                    m_UbicacionArchivo = solicitarRutaBD();
                    crearArchivo(m_UbicacionArchivo);
                }
            }
            return m_UbicacionArchivo;
        }

        private static string solicitarRutaBD()
        {
            string m_Ubicacion = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos db y SQLite (*.db;*.SQLite)|*.db;*.SQLite";
            dialog.Title = "Seleccione el archivo db";
            dialog.FileName = string.Empty;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
               m_Ubicacion = dialog.FileName;
            }
            return m_Ubicacion;
        }
        private static void crearArchivo(string m_UbicacionArchivo)
        {
            string m_archivo = Application.StartupPath + "\\RutaBD.txt";
            using (var fileStream = File.Create(m_archivo))
            {
                var texto = new UTF8Encoding(true).GetBytes(m_UbicacionArchivo);
                fileStream.Write(texto, 0, texto.Length);
                fileStream.Flush();
            }
        }
    }
}

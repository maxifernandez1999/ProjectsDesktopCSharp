
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class;
using Excel = Microsoft.Office.Interop.Excel;
namespace NoteManagement
{
    public partial class FormStudents : Form
    {
        private string path;
        private Excel._Workbook libro;
        private Excel._Worksheet hoja;
        private Excel.Application excel;
        public FormStudents()
        {
            InitializeComponent();
            path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\ejemplo.xlsx";
            Alumnos alumnos = new Alumnos("pepe", "Fernandez", "42039574", 1, 1, 1);
            CrearArchivoExcel(alumnos);



        }

       
        /// <summary>
        /// Metodo que crea un archivo xlsx
        /// </summary>
        public void CrearArchivoExcel(Alumnos alumno)
        {
            this.excel = new Excel.Application();
            //Instancia el libro y la hoja
            this.libro = (Excel._Workbook)excel.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            this.hoja = (Excel._Worksheet)libro.Worksheets.Add();
            try
            { 
                //Agrega las cabeceras
                AgregarCabeceras(3, ref hoja);
                
                if (File.Exists(this.path))
                {
                    this.hoja.Cells[4, 1] = alumno.Nombre;
                    this.hoja.Cells[4, 2] = alumno.Apellido;
                    this.hoja.Cells[4, 3] = alumno.Dni;
                    this.hoja.Cells[4, 4] = alumno.NotaUno;
                    this.hoja.Cells[4, 5] = alumno.NotaDos;
                    this.hoja.Cells[4, 6] = alumno.NotaFinal;
                    
                    this.libro.SaveAs(path);
                   


                }
                else
                {
                    //Elimina la hoja por defecto de excel
                    this.hoja.Name = "Libro1";
                    ((Excel._Worksheet)excel.ActiveWorkbook.Sheets["Hoja1"]).Delete();
                    this.libro.SaveAs(this.path);
                    this.libro.Saved = true;
                }
                




                //liberar recursos
                this.libro.Close();
                LiberarRecursos(this.libro);
                this.excel.UserControl = false;
                this.excel.Quit();
                LiberarRecursos(this.excel);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error en la creacion del archivo xlsx" + ex.ToString());
            }
        }

        
        /// <summary>
        /// Metodo que libera recursos al cerrar un archivo xlsx
        /// </summary>
        /// <param name="obj"></param>
        public void LiberarRecursos(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Error mientras se liberaba el objeto", ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        /// <summary>
        /// Agrega las cabeceras en los archivos xlsx
        /// </summary>
        /// <param name="fila">Fila donde se agrega la cabecera</param>
        /// <param name="hoja">Hoja donde se agrega la cabecera</param>
        private void AgregarCabeceras(int fila, ref Excel._Worksheet hoja)
        {
            try
            {
                Excel.Range rango;
                //Agregar titulo
                //hoja.Cells[1, 1] = "Gestor de notas de alumnos";

                //Agregar encabezados
                hoja.Cells[3, 1] = "Nombre";
                hoja.Cells[3, 2] = "Apellido";
                hoja.Cells[3, 3] = "Dni";
                hoja.Cells[3, 4] = "NotaUno";
                hoja.Cells[3, 5] = "NotaDos";
                hoja.Cells[3, 6] = "NotaFinal";
                


                //poner bordes a las celdas
                rango = hoja.Range["A3", "F3"];
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                //centrar textos
                rango = hoja.Rows[fila];
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                rango = hoja.Columns[1];
                rango.ColumnWidth = 20;
                rango = hoja.Columns[2];
                rango.ColumnWidth = 20;
                rango = hoja.Columns[3];
                rango.ColumnWidth = 20;
                rango = hoja.Columns[4];
                rango.ColumnWidth = 20;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error generando los estilos",ex.ToString());
            }
            
        }
    }
}

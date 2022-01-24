using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaDeNegocios;

using System.Xml;


using System.Data.OleDb;

namespace CapaUsuario.CargaInicial
{
    public partial class frmCargaInicial : Form
    {
        private List<cTrabajador> ListaTrabajadores = new List<cTrabajador>();

        private cTrabajador trabajadorPlantilla = new cTrabajador();

        public frmCargaInicial()
        {
            InitializeComponent();
        }

        private void frmCargaInicial_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog fichero = new OpenFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls|Excel (*.xlsx)|*.xlsx|xml(*.xml) |*.xml";
            fichero.FileName = "r07.xml";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                LLenarGrid(fichero.FileName, "Hoja1");
            }
        }

        private void LLenarGrid(string archivo, string hoja)
        {
            

            XmlDocument miXML = new XmlDocument();
            miXML.Load(archivo);

            foreach (XmlNode item in miXML.ChildNodes)
            {
                if (item.Name == "ss:Workbook")
                {
                    foreach (XmlNode item2 in item.ChildNodes)
                    {
                        if (item2.Name == "ss:Worksheet")
                        {
                            if (item2.HasChildNodes)
                            {
                                foreach (XmlNode item3 in item2.ChildNodes)
                                {
                                    if (item3.Name == "ss:Table")
                                    {
                                        if (item3.HasChildNodes)
                                        {
                                            foreach (XmlNode item4 in item3.ChildNodes)
                                            {
                                                if (item4.Name == "ss:Row")
                                                {
                                                    int numero = Convert.ToInt32(item4.Attributes[0].Value);

                                                    if (numero >= 14)
                                                    {
                                                        cTrabajador nuevoTrabajador = new cTrabajador();
                                                        nuevoTrabajador.MiNacionalidad = trabajadorPlantilla.MiNacionalidad;
                                                        nuevoTrabajador.MiDistrito = trabajadorPlantilla.MiDistrito;
                                                        nuevoTrabajador.MiTipoZOna = trabajadorPlantilla.MiTipoZOna;
                                                        nuevoTrabajador.MiTipoVia = trabajadorPlantilla.MiTipoVia;
                                                        nuevoTrabajador.NumeroVia = "0";
                                                        foreach (XmlNode item5 in item4.ChildNodes)
                                                        {
                                                            

                                                            // nodo cell
                                                            switch (item5.Attributes[0].Value)
                                                            {
                                                                //NODO CELL
                                                                //dni
                                                                case "2":
                                                                    nuevoTrabajador.Dni = item5.ChildNodes[0].ChildNodes[0].Value;
                                                                    break;
                                                                //apellido paterno
                                                                case "3":
                                                                    nuevoTrabajador.ApellidoPaterno = item5.ChildNodes[0].ChildNodes[0].Value;
                                                                    break;
                                                                //apellido materno
                                                                case "4":
                                                                    nuevoTrabajador.ApellidoMaterno = item5.ChildNodes[0].ChildNodes[0].Value;
                                                                    break;
                                                                //nombres
                                                                case "5":
                                                                    nuevoTrabajador.Nombres = item5.ChildNodes[0].ChildNodes[0].Value;
                                                                    break;
                                                                default:
                                                                    break;
                                                            }

                                                           
                                                        }
                                                        ListaTrabajadores.Add(nuevoTrabajador);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
    
                        }
                    }
                }
            }
            dtgDatosExcel.DataSource = ListaTrabajadores;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListaTrabajadores.Count == 0)
                {
                    MessageBox.Show("No hay datos para guardar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    foreach (cTrabajador item in ListaTrabajadores)
                    {
                        int id;
                        id = item.AgregarTrabajadorConID(item);
                        item.IdTrabajador = id;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al salvar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDatosFijos_Click(object sender, EventArgs e)
        {
            try
            {
                frmDatosFijos fDatosFijos = new frmDatosFijos();
                fDatosFijos.miNacionalidad = new cNacionalidad();
                fDatosFijos.miDistrito = new cDistrito();
                fDatosFijos.miTipoVia = new cTipoVia();
                fDatosFijos.miTipoZona = new cTipoZona();

                if (fDatosFijos.ShowDialog() == DialogResult.OK)
                {
                    trabajadorPlantilla.MiNacionalidad = fDatosFijos.miNacionalidad;
                    trabajadorPlantilla.MiDistrito = fDatosFijos.miDistrito;
                    trabajadorPlantilla.MiTipoVia = fDatosFijos.miTipoVia;
                    trabajadorPlantilla.MiTipoZOna = fDatosFijos.miTipoZona;
                    trabajadorPlantilla.NumeroVia = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al dar datos fijos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

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

namespace CapaUsuario.Clasificadores
{
    public partial class frmListaClasificadoresGasto : Form
    {
        CapaDeNegocios.Clasificadores.cClasificadorGasto oClasificadorGasto = new CapaDeNegocios.Clasificadores.cClasificadorGasto();

        CapaDeNegocios.Clasificadores.cGenerica oGenericaSeleccionada;
        CapaDeNegocios.Clasificadores.cSubgenerica oSubgenericaSeleccionada;
        CapaDeNegocios.Clasificadores.cSubgenerica2 oSubgenerica2Seleccionada;
        CapaDeNegocios.Clasificadores.cEspecifica oEspecificaSeleccionada;
        

        public frmListaClasificadoresGasto()
        {
            InitializeComponent();
        }

        private void frmListaClasificadoresGasto_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            dtgListaGenericas.DataSource = oClasificadorGasto.ObtenerListaGenericas();    
        }

        private void tabSubgenericas_Selected(object sender, TabControlEventArgs e)
        {
            
        }

        private void btnNuevaGenerica_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoGenerica fNuevoGenerica = new frmNuevoGenerica();
                fNuevoGenerica.oGenerica = new CapaDeNegocios.Clasificadores.cGenerica();
                if (fNuevoGenerica.ShowDialog() == DialogResult.OK)
                {
                    oClasificadorGasto.CrearGenerica(fNuevoGenerica.oGenerica);
                }
                else
                {
                    MessageBox.Show("Se canceló la operacion");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear generica. " + ex.Message);
            }
            
        }

        private void btnModificarGenerica_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (dtgListaGenericas.SelectedRows.Count > 0)
                {
                    frmNuevoGenerica fNuevoGenerica = new frmNuevoGenerica();
                    fNuevoGenerica.oGenerica = new CapaDeNegocios.Clasificadores.cGenerica();
                    
                    fNuevoGenerica.oGenerica.Idtgenerica = Convert.ToInt16(dtgListaGenericas.SelectedRows[0].Cells["Idtgenerica"].Value.ToString());
                    fNuevoGenerica.oGenerica.Codigo = dtgListaGenericas.SelectedRows[0].Cells["Codigo"].Value.ToString();
                    fNuevoGenerica.oGenerica.Nombre = dtgListaGenericas.SelectedRows[0].Cells["Nombre"].Value.ToString();
                    fNuevoGenerica.oGenerica.Descripcion = dtgListaGenericas.SelectedRows[0].Cells["Descripcion"].Value.ToString();
                    if (fNuevoGenerica.ShowDialog() == DialogResult.OK)
                    {
                        oClasificadorGasto.ModificarGenerica(fNuevoGenerica.oGenerica);
                        dtgListaGenericas.DataSource = oClasificadorGasto.ObtenerListaGenericas();
                    }
                    else
                    {
                        MessageBox.Show("Se canceló la operacion");
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una generica.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtgListaGenericas.Focus();
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear generica. " + ex.Message);
            }
        }

        private void btnEliminarGenerica_Click(object sender, EventArgs e)
        {
            try
            {

                if (dtgListaGenericas.SelectedRows.Count > 0)
                {
                    CapaDeNegocios.Clasificadores.cGenerica oGenerica = new CapaDeNegocios.Clasificadores.cGenerica();

                    oGenerica.Idtgenerica = Convert.ToInt16(dtgListaGenericas.SelectedRows[0].Cells["Idtgenerica"].Value.ToString());
                    oGenerica.Codigo = dtgListaGenericas.SelectedRows[0].Cells["Codigo"].Value.ToString();
                    oGenerica.Nombre = dtgListaGenericas.SelectedRows[0].Cells["Nombre"].Value.ToString();
                    oGenerica.Descripcion = dtgListaGenericas.SelectedRows[0].Cells["Descripcion"].Value.ToString();

                    if (MessageBox.Show("Desea eliminar la generica: " + oGenerica.Codigo,"Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                    {
                        oClasificadorGasto.EliminarGenerica(oGenerica);
                    }
                    else
                    {
                        MessageBox.Show("Se canceló la operacion");
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una generica.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtgListaGenericas.Focus();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear generica. " + ex.Message);
            }
        }

        private void btnNuevaSubGenerica_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoSubGenerica fMantenimientoSubGenerica = new frmMantenimientoSubGenerica();
                fMantenimientoSubGenerica.oSubgenerica = new CapaDeNegocios.Clasificadores.cSubgenerica();
                fMantenimientoSubGenerica.oSubgenerica.Generica = oGenericaSeleccionada;
                if (fMantenimientoSubGenerica.ShowDialog() == DialogResult.OK)
                {
                    oClasificadorGasto.CrearSubgenerica(fMantenimientoSubGenerica.oSubgenerica);
                    dtgSubgenericas.DataSource = oClasificadorGasto.ObtenerListaSubgenericas(oGenericaSeleccionada);

                }
                else
                {
                    MessageBox.Show("Se cancelo la operacion");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la subgenerica: " + ex.Message);
            }
        }

        private void btnModificarSubGenerica_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgSubgenericas.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar una subgenerica.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    frmMantenimientoSubGenerica fMantenimientoSubGenerica = new frmMantenimientoSubGenerica();
                    fMantenimientoSubGenerica.oSubgenerica = new CapaDeNegocios.Clasificadores.cSubgenerica();
                    fMantenimientoSubGenerica.oSubgenerica.Idtsubgenerica = Convert.ToInt16(dtgSubgenericas.SelectedRows[0].Cells["idtsubgenerica"].Value.ToString());
                    fMantenimientoSubGenerica.oSubgenerica.Codigo = dtgSubgenericas.SelectedRows[0].Cells["codigoSub"].Value.ToString();
                    fMantenimientoSubGenerica.oSubgenerica.Nombre = dtgSubgenericas.SelectedRows[0].Cells["nombreSub"].Value.ToString();
                    fMantenimientoSubGenerica.oSubgenerica.Descripcion = dtgSubgenericas.SelectedRows[0].Cells["descripcionSub"].Value.ToString();

                    fMantenimientoSubGenerica.oSubgenerica.Generica = oGenericaSeleccionada;
                    if (fMantenimientoSubGenerica.ShowDialog() == DialogResult.OK)
                    {
                        oClasificadorGasto.CrearSubgenerica(fMantenimientoSubGenerica.oSubgenerica);
                        dtgSubgenericas.DataSource = oClasificadorGasto.ObtenerListaSubgenericas(oGenericaSeleccionada);

                    }
                    else
                    {
                        MessageBox.Show("Se cancelo la operacion");
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la subgenerica: " + ex.Message);
            }
        }

        private void btnEliminarSubGenerica_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgSubgenericas.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar una subgenerica.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    CapaDeNegocios.Clasificadores.cSubgenerica oSubgenerica = new CapaDeNegocios.Clasificadores.cSubgenerica();
                    oSubgenerica = new CapaDeNegocios.Clasificadores.cSubgenerica();
                    oSubgenerica.Idtsubgenerica = Convert.ToInt16(dtgSubgenericas.SelectedRows[0].Cells["idtsubgenerica"].Value.ToString());
                    oSubgenerica.Codigo = dtgSubgenericas.SelectedRows[0].Cells["codigoSub"].Value.ToString();
                    oSubgenerica.Nombre = dtgSubgenericas.SelectedRows[0].Cells["nombreSub"].Value.ToString();
                    oSubgenerica.Descripcion = dtgSubgenericas.SelectedRows[0].Cells["descripcionSub"].Value.ToString();

                    oSubgenerica.Generica = oGenericaSeleccionada;
                    if (MessageBox.Show("Desea eliminar la subgenerica.", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes) 
                    {
                        oClasificadorGasto.EliminarSubgenerica(oSubgenerica);
                        dtgSubgenericas.DataSource = oClasificadorGasto.ObtenerListaSubgenericas(oGenericaSeleccionada);

                    }
                    else
                    {
                        MessageBox.Show("Se cancelo la operacion");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la subgenerica: " + ex.Message);
            }
        }

        private void tabSubgenerica2_Enter(object sender, EventArgs e)
        {
            if (dtgSubgenericas.SelectedRows.Count > 0)
            {
                CapaDeNegocios.Clasificadores.cSubgenerica oSubgenerica = new CapaDeNegocios.Clasificadores.cSubgenerica();
                oSubgenerica.Idtsubgenerica = Convert.ToInt16(dtgSubgenericas.SelectedRows[0].Cells["idtsubgenerica"].Value.ToString());
                oSubgenerica.Codigo = dtgSubgenericas.SelectedRows[0].Cells["CodigoSub"].Value.ToString();
                oSubgenerica.Nombre = dtgSubgenericas.SelectedRows[0].Cells["NombreSub"].Value.ToString();
                oSubgenerica.Descripcion = dtgSubgenericas.SelectedRows[0].Cells["DescripcionSub"].Value.ToString();
                oSubgenericaSeleccionada = oSubgenerica;
                dtgSubgenerica2.DataSource = oClasificadorGasto.ObtenerListaSubgenericas2(oSubgenerica);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una subgenerica.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                tabSubgenericas.Select();
                tabClasificadorGastos.SelectedIndex = 1;
            }
        }

        private void btnNuevaSubgenerica2_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoSubGenerica2 fMantenimientoSubGenerica2 = new frmMantenimientoSubGenerica2();
                fMantenimientoSubGenerica2.oSubgenerica2 = new CapaDeNegocios.Clasificadores.cSubgenerica2();
                fMantenimientoSubGenerica2.oSubgenerica2.Subgenerica = oSubgenericaSeleccionada;
                if (fMantenimientoSubGenerica2.ShowDialog() == DialogResult.OK)
                {
                    oClasificadorGasto.CrearSubgenerica2(fMantenimientoSubGenerica2.oSubgenerica2);
                    dtgSubgenerica2.DataSource = oClasificadorGasto.ObtenerListaSubgenericas2(oSubgenericaSeleccionada);
                }
                else
                {
                    MessageBox.Show("Operacion cancelada");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar subgenerica level 2: " + ex.Message);
            }
        }

        private void btnModificarSubgenerica2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgSubgenerica2.SelectedRows.Count > 0)
                {
                    frmMantenimientoSubGenerica2 fMantenimientoSubgenerica2 = new frmMantenimientoSubGenerica2();
                    fMantenimientoSubgenerica2.oSubgenerica2 = new CapaDeNegocios.Clasificadores.cSubgenerica2();
                    fMantenimientoSubgenerica2.oSubgenerica2.Idtsubgenerica2 = Convert.ToInt16(dtgSubgenerica2.SelectedRows[0].Cells["idtsubgenerica2"].Value);
                    fMantenimientoSubgenerica2.oSubgenerica2.Codigo = dtgSubgenerica2.SelectedRows[0].Cells["codigoSub2"].Value.ToString();
                    fMantenimientoSubgenerica2.oSubgenerica2.Nombre = dtgSubgenerica2.SelectedRows[0].Cells["nombreSub2"].Value.ToString();
                    fMantenimientoSubgenerica2.oSubgenerica2.Descripcion = dtgSubgenerica2.SelectedRows[0].Cells["descripcionSub2"].Value.ToString();

                    fMantenimientoSubgenerica2.oSubgenerica2.Subgenerica = oSubgenericaSeleccionada;

                    if (fMantenimientoSubgenerica2.ShowDialog() == DialogResult.OK)
                    {
                        oClasificadorGasto.ModificarSubgenerica2(fMantenimientoSubgenerica2.oSubgenerica2);
                        dtgSubgenerica2.DataSource = oClasificadorGasto.ObtenerListaSubgenericas2(oSubgenericaSeleccionada);
                    }
                    else
                    {
                        MessageBox.Show("Operacion Cancelada");
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar subgenerica level 2: " + ex.Message);
            }
        }

        private void btnEliminarSubgenerica2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgSubgenerica2.SelectedRows.Count > 0)
                {
                   
                    CapaDeNegocios.Clasificadores.cSubgenerica2 oSubgenerica2 = new CapaDeNegocios.Clasificadores.cSubgenerica2();
                    oSubgenerica2.Idtsubgenerica2 = Convert.ToInt16(dtgSubgenerica2.SelectedRows[0].Cells["idtsubgenerica2"].Value);
                    oSubgenerica2.Codigo = dtgSubgenerica2.SelectedRows[0].Cells["codigoSub2"].Value.ToString();
                    oSubgenerica2.Nombre = dtgSubgenerica2.SelectedRows[0].Cells["nombreSub2"].Value.ToString();
                    oSubgenerica2.Descripcion = dtgSubgenerica2.SelectedRows[0].Cells["descripcionSub2"].Value.ToString();

                    oSubgenerica2.Subgenerica = oSubgenericaSeleccionada;

                    if (MessageBox.Show("Desea eliminar la subgenerica level 2 ","Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                    {
                        oClasificadorGasto.EliminarSubgenerica2(oSubgenerica2);
                        dtgSubgenerica2.DataSource = oClasificadorGasto.ObtenerListaSubgenericas2(oSubgenericaSeleccionada);
                    }
                    else
                    {
                        MessageBox.Show("Operacion Cancelada");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar subgenerica level 2: " + ex.Message);
            }
        }

        private void btnNuevaEspecifica_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoEspecifica fMantenimiento = new frmMantenimientoEspecifica();
                fMantenimiento.oEspecifica = new CapaDeNegocios.Clasificadores.cEspecifica();
                fMantenimiento.oEspecifica.Subgenerica2 = oSubgenerica2Seleccionada;

                if (fMantenimiento.ShowDialog() == DialogResult.OK)
                {
                    oClasificadorGasto.CrearEspecifica(fMantenimiento.oEspecifica);
                    dtgEspecificas.DataSource = oClasificadorGasto.ListaEspecificas(oSubgenerica2Seleccionada);
                }
                else
                {
                    MessageBox.Show("Operacion Cancelada");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar especifica: " + ex.Message);
            }
        }

        private void btnModificarEspecifica_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgEspecificas.SelectedRows.Count > 0)
                {
                    frmMantenimientoEspecifica fMantenimientoEspecifica = new frmMantenimientoEspecifica();
                    fMantenimientoEspecifica.oEspecifica = new CapaDeNegocios.Clasificadores.cEspecifica();
                    fMantenimientoEspecifica.oEspecifica.Idtespecifica = Convert.ToInt16(dtgEspecificas.SelectedRows[0].Cells["idtespecifica"].Value.ToString());
                    fMantenimientoEspecifica.oEspecifica.Codigo = dtgEspecificas.SelectedRows[0].Cells["codigoEsp"].Value.ToString();
                    fMantenimientoEspecifica.oEspecifica.Nombre = dtgEspecificas.SelectedRows[0].Cells["nombreEsp"].Value.ToString();
                    fMantenimientoEspecifica.oEspecifica.Descripcion = dtgEspecificas.SelectedRows[0].Cells["descripcionEsp"].Value.ToString();
                    fMantenimientoEspecifica.oEspecifica.Subgenerica2 = oSubgenerica2Seleccionada;

                    if (fMantenimientoEspecifica.ShowDialog() == DialogResult.OK)
                    {
                        oClasificadorGasto.ModificarEspecifica(fMantenimientoEspecifica.oEspecifica);
                        dtgEspecificas.DataSource = oClasificadorGasto.ListaEspecificas(oSubgenerica2Seleccionada);
                    }
                    else
                    {
                        MessageBox.Show("Operacion Cancelada");
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una especifica.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la especifica: " + ex.Message);
            }
        }

        private void btnEliminarEspecifica_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgEspecificas.SelectedRows.Count > 0)
                {
                   CapaDeNegocios.Clasificadores.cEspecifica oEspecifica = new CapaDeNegocios.Clasificadores.cEspecifica();
                    oEspecifica.Idtespecifica = Convert.ToInt16(dtgEspecificas.SelectedRows[0].Cells["idtespecifica"].Value.ToString());
                    oEspecifica.Codigo = dtgEspecificas.SelectedRows[0].Cells["codigoEsp"].Value.ToString();
                    oEspecifica.Nombre = dtgEspecificas.SelectedRows[0].Cells["nombreEsp"].Value.ToString();
                    oEspecifica.Descripcion = dtgEspecificas.SelectedRows[0].Cells["descripcionEsp"].Value.ToString();
                    oEspecifica.Subgenerica2 = oSubgenerica2Seleccionada;

                    if (MessageBox.Show("Desea eliminar la especifica?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                    {
                        oClasificadorGasto.EliminarEspecifica(oEspecifica);
                        dtgEspecificas.DataSource = oClasificadorGasto.ListaEspecificas(oSubgenerica2Seleccionada);
                    }
                    else
                    {
                        MessageBox.Show("Operacion Cancelada");
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una especifica.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la especifica: " + ex.Message);
            }
        }

        private void btnNuevaEspecifica2_Click(object sender, EventArgs e)
        {
            try
            {
                frmMantenimientoEspecifica2 fMantenimientoEspecifica2 = new frmMantenimientoEspecifica2();
                fMantenimientoEspecifica2.oEspecifica2 = new CapaDeNegocios.Clasificadores.cEspecifica2();
                fMantenimientoEspecifica2.oEspecifica2.Especifica = oEspecificaSeleccionada;
                if (fMantenimientoEspecifica2.ShowDialog() == DialogResult.OK)
                {
                    oClasificadorGasto.CrearEspecifica2(fMantenimientoEspecifica2.oEspecifica2);
                    dtgEspecificas2.DataSource = oClasificadorGasto.ListaEspecificas2(oEspecificaSeleccionada);
                }
                else
                {
                    MessageBox.Show("Operacion Cancelada");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la especifica level 2: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarEspecifica2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgEspecificas2.SelectedRows.Count > 0)
                {
                    CapaDeNegocios.Clasificadores.cEspecifica2 oEspecifica2 = new CapaDeNegocios.Clasificadores.cEspecifica2();
                    oEspecifica2.IdtEspecifica2 = Convert.ToInt16(dtgEspecificas2.SelectedRows[0].Cells["idtespecifica2"].Value.ToString());
                    oEspecifica2.Codigo = dtgEspecificas2.SelectedRows[0].Cells["codigoEsp2"].Value.ToString();
                    oEspecifica2.Nombre = dtgEspecificas2.SelectedRows[0].Cells["nombreEsp2"].Value.ToString();
                    oEspecifica2.Descripcion = dtgEspecificas2.SelectedRows[0].Cells["descripcionEsp2"].Value.ToString();
                    oEspecifica2.Especifica = oEspecificaSeleccionada;

                    if (MessageBox.Show("Desea eliminar la especifica level 2?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        oClasificadorGasto.EliminarEspecifica2(oEspecifica2);
                        dtgEspecificas2.DataSource = oClasificadorGasto.ListaEspecificas2(oEspecificaSeleccionada);
                    }
                    else
                    {
                        MessageBox.Show("Operacion Cancelada");
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una especifica level 2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar especifica level 2: " +ex.Message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarEspecifica2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgEspecificas2.SelectedRows.Count > 0)
                {
                    frmMantenimientoEspecifica2 fMantenimientoEspecifica2 = new frmMantenimientoEspecifica2();
                    fMantenimientoEspecifica2.oEspecifica2 = new CapaDeNegocios.Clasificadores.cEspecifica2();
                    fMantenimientoEspecifica2.oEspecifica2.IdtEspecifica2 = Convert.ToInt16(dtgEspecificas2.SelectedRows[0].Cells["idtespecifica2"].Value.ToString());
                    fMantenimientoEspecifica2.oEspecifica2.Codigo = dtgEspecificas2.SelectedRows[0].Cells["codigoEsp2"].Value.ToString();
                    fMantenimientoEspecifica2.oEspecifica2.Nombre = dtgEspecificas2.SelectedRows[0].Cells["nombreEsp2"].Value.ToString();
                    fMantenimientoEspecifica2.oEspecifica2.Descripcion = dtgEspecificas2.SelectedRows[0].Cells["descripcionEsp2"].Value.ToString();
                    fMantenimientoEspecifica2.oEspecifica2.Especifica = oEspecificaSeleccionada;

                    if (fMantenimientoEspecifica2.ShowDialog() == DialogResult.OK)
                    {
                        oClasificadorGasto.ModificarEspecifica2(fMantenimientoEspecifica2.oEspecifica2);
                        dtgEspecificas2.DataSource = oClasificadorGasto.ListaEspecificas2(oEspecificaSeleccionada);
                    }
                    else
                    {
                        MessageBox.Show("Operacion Cancelada");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar especifica level 2: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabEspecifica_Enter(object sender, EventArgs e)
        {
            if (dtgSubgenerica2.SelectedRows.Count > 0)
            {

                CapaDeNegocios.Clasificadores.cSubgenerica2 oSubgenerica2 = new CapaDeNegocios.Clasificadores.cSubgenerica2();
                oSubgenerica2.Idtsubgenerica2 = Convert.ToInt16(dtgSubgenerica2.SelectedRows[0].Cells["idtsubgenerica2"].Value);
                oSubgenerica2.Codigo = dtgSubgenerica2.SelectedRows[0].Cells["codigosub2"].Value.ToString();
                oSubgenerica2.Nombre = dtgSubgenerica2.SelectedRows[0].Cells["nombresub2"].Value.ToString();
                oSubgenerica2.Descripcion = dtgSubgenerica2.SelectedRows[0].Cells["descripcionsub2"].Value.ToString();

                dtgEspecificas.DataSource = oClasificadorGasto.ListaEspecificas(oSubgenerica2);
                oSubgenerica2Seleccionada = oSubgenerica2;

               
            }
            else
            {
                MessageBox.Show("Debe seleccionar una subcategoria level 2");
                tabClasificadorGastos.SelectedIndex = 2;
            }
        }

        private void dtgEspecificas2_Enter(object sender, EventArgs e)
        {
            
        }

        private void tabEspecifica2_Enter(object sender, EventArgs e)
        {
            if (dtgEspecificas.SelectedRows.Count > 0)
            {
                CapaDeNegocios.Clasificadores.cEspecifica oEspecifica = new CapaDeNegocios.Clasificadores.cEspecifica();
                oEspecifica.Idtespecifica = Convert.ToInt16(dtgEspecificas.SelectedRows[0].Cells["idtespecifica"].Value.ToString());
                oEspecifica.Codigo = dtgEspecificas.SelectedRows[0].Cells["codigoEsp"].Value.ToString();
                oEspecifica.Nombre = dtgEspecificas.SelectedRows[0].Cells["nombreEsp"].Value.ToString();
                oEspecifica.Descripcion = dtgEspecificas.SelectedRows[0].Cells["descripcionEsp"].Value.ToString();
                oEspecifica.Subgenerica2 = oSubgenerica2Seleccionada;

                oEspecificaSeleccionada = oEspecifica;
                dtgEspecificas2.DataSource = oClasificadorGasto.ListaEspecificas2(oEspecifica);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una especifica.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tabSubgenericas_Enter(object sender, EventArgs e)
        {
            if (dtgListaGenericas.SelectedRows.Count > 0)
            {
                CapaDeNegocios.Clasificadores.cGenerica oGenerica = new CapaDeNegocios.Clasificadores.cGenerica();
                oGenerica.Idtgenerica = Convert.ToInt16(dtgListaGenericas.SelectedRows[0].Cells["Idtgenerica"].Value.ToString());
                oGenerica.Codigo = dtgListaGenericas.SelectedRows[0].Cells["Codigo"].Value.ToString();
                oGenerica.Nombre = dtgListaGenericas.SelectedRows[0].Cells["Nombre"].Value.ToString();
                oGenerica.Descripcion = dtgListaGenericas.SelectedRows[0].Cells["Descripcion"].Value.ToString();
                oGenericaSeleccionada = oGenerica;
                dtgSubgenericas.DataSource = oClasificadorGasto.ObtenerListaSubgenericas(oGenerica);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una generica.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                tabGenerica.Select();
                tabClasificadorGastos.SelectedIndex = 0;
            }
        }
    }
}

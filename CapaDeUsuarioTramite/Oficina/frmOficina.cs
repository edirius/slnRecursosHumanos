﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeDatos;
using CapaDeNegociosTramite;
using CapaDeNegociosTramite.Oficina;

namespace CapaDeUsuarioTramite.Oficina
{
    public partial class frmOficina : Form
    {
        cOficina miOficina = new cOficina();
        DataTable Tabla = new DataTable();
        string mensaje = "";
        string respuesta = "";

        public frmOficina()
        {
            InitializeComponent();
            ActualizarLista();
        }
        public void ActualizarLista()
        {
            dgvListarOficinas.DataSource =  miOficina.ListarOficina();
        }
        public void ConfiguracionInicial()
        {
            txtDependencia.Text = "";
            txtDescripcion.Text = "";
            txtNombreOficina.Text = "";
            txtDependencia.Focus();
        }
        private void Agregar()
        {
            if (txtNombreOficina.Text != "")
            {
                miOficina.NombreOficina = txtNombreOficina.Text;
                miOficina.Dependencia = txtDependencia.Text;
                miOficina.DescripcionOficina = txtDescripcion.Text;
                Tabla = miOficina.AgregarOficina();
                respuesta = Tabla.Rows[0][0].ToString();
                mensaje = Tabla.Rows[0][1].ToString();
                if (respuesta == "1")
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConfiguracionInicial();
                    ActualizarLista();
                }
                else if (respuesta == "0")
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ConfiguracionInicial();
                }
            }
            else
                MessageBox.Show("Por favor llene los campos necesarios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Modificar()
        {
            if (txtNombreOficina.Text != "")
            {
                int valor = dgvListarOficinas.CurrentCell.RowIndex;
                miOficina.CodigoOficina = int.Parse(dgvListarOficinas[0, valor].Value.ToString());
                miOficina.NombreOficina = txtNombreOficina.Text;
                miOficina.Dependencia = txtDependencia.Text;
                miOficina.DescripcionOficina = txtDescripcion.Text;
                Tabla = miOficina.ModificarOficina();
                respuesta = Tabla.Rows[0][0].ToString();
                mensaje = Tabla.Rows[0][1].ToString();
                if (respuesta == "1")
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConfiguracionInicial();
                    ActualizarLista();
                }
                else if (respuesta == "0")
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ConfiguracionInicial();
                }
            }
            else
                MessageBox.Show("Por favor llene los campos necesarios", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Eliminar()
        {
            if (txtNombreOficina.Text != "")
            {
                int valor = dgvListarOficinas.CurrentCell.RowIndex;
                miOficina.CodigoOficina = int.Parse(dgvListarOficinas[0, valor].Value.ToString());
                miOficina.NombreOficina = txtNombreOficina.Text;
                Tabla = miOficina.EliminarOficina();
                respuesta = Tabla.Rows[0][0].ToString();
                mensaje = Tabla.Rows[0][1].ToString();
                if (respuesta == "1")
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ConfiguracionInicial();
                    ActualizarLista();
                }
                else if (respuesta == "0")
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ConfiguracionInicial();
                }
            }
            else
                MessageBox.Show("No ha seleccionado la oficina que desea eliminar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnInsertar_Click_1(object sender, EventArgs e)
        {
            Agregar();
            ConfiguracionInicial();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
            ConfiguracionInicial();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            ConfiguracionInicial();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            ConfiguracionInicial();
        }
        private void dgvListarOficinas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int valor = dgvListarOficinas.CurrentCell.RowIndex;
            miOficina.CodigoOficina = int.Parse(dgvListarOficinas[0, valor].Value.ToString());
            txtDependencia.Text = dgvListarOficinas[2, valor].Value.ToString();
            txtNombreOficina.Text = dgvListarOficinas[3, valor].Value.ToString();
            txtDescripcion.Text = dgvListarOficinas[4, valor].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmOficina_Load(object sender, EventArgs e)
        {
            
        }

    }
}

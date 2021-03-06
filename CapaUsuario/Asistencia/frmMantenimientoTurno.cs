﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios;

namespace CapaUsuario.Asistencia
{
    public partial class frmMantenimientoTurno : Form
    {

        public CapaDeNegocios.Asistencia.cTurno oTurno;

        public frmMantenimientoTurno()
        {
            InitializeComponent();
        }

        private void frmMantenimientoTurno_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {
            txtNombreTurno.Text = oTurno.NombreTurno;
            dtpInicioTurno.Value = oTurno.InicioTurno;
            dtpFinTurno.Value = oTurno.FinTurno;
            numTolerancia.Value = oTurno.ToleranciaInicio;
            numToleranciaFalta.Value = oTurno.ToleranciaFalta;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreTurno.Text != "")
                {
                    oTurno.NombreTurno = txtNombreTurno.Text;
                    oTurno.InicioTurno = dtpInicioTurno.Value;
                    oTurno.FinTurno = dtpFinTurno.Value;
                    oTurno.ToleranciaFalta = Convert.ToInt16(numToleranciaFalta.Value);
                    oTurno.ToleranciaInicio = Convert.ToInt16(numTolerancia.Value);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Debe escribir un nombre al turno.", "Agregar turno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el turno: " + ex.Message, "Agregar Turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

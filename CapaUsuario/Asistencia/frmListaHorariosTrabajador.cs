using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaUsuario.Asistencia
{
    public partial class frmListaHorariosTrabajador : Form
    {
        public List<CapaDeNegocios.Asistencia.cHorarioTrabajador> ListaHorarioTrabajador = new List<CapaDeNegocios.Asistencia.cHorarioTrabajador>();
        CapaDeNegocios.Asistencia.cCatalogoAsistencia ocatalogo = new CapaDeNegocios.Asistencia.cCatalogoAsistencia();

        public frmListaHorariosTrabajador()
        {
            InitializeComponent();
        }
        
        private void frmListaHorariosTrabajador_Load(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void Iniciar()
        {

        }
    }
}

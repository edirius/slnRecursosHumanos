using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios.Reloj
{
    public class cCatalogoPrivilegiosReloj
    {

        public List<cPrivilegioReloj> ObtenerListaPrivilegiosReloj()
        {
            try
            {
                List<cPrivilegioReloj> NuevaLista = new List<cPrivilegioReloj>();

                cPrivilegioReloj Nuevo1 = new cPrivilegioReloj();
                Nuevo1.Codigo = 1;
                Nuevo1.Descripcion = "Normal";
                NuevaLista.Add(Nuevo1);

                cPrivilegioReloj Nuevo2 = new cPrivilegioReloj();
                Nuevo2.Codigo = 2;
                Nuevo2.Descripcion = "Normal";
                NuevaLista.Add(Nuevo2);

                cPrivilegioReloj Nuevo3 = new cPrivilegioReloj();
                Nuevo3.Codigo = 1;
                Nuevo3.Descripcion = "Normal";
                NuevaLista.Add(Nuevo3);

                cPrivilegioReloj Nuevo4 = new cPrivilegioReloj();
                Nuevo4.Codigo = 1;
                Nuevo4.Descripcion = "Normal";
                NuevaLista.Add(Nuevo4);

                cPrivilegioReloj Nuevo5 = new cPrivilegioReloj();
                Nuevo5.Codigo = 1;
                Nuevo5.Descripcion = "Normal";
                NuevaLista.Add(Nuevo5);

                return NuevaLista;
            }
            catch (Exception ex)
            {
                throw new cReglaNegociosException("Error al obtener lista de privilegios del reloj: " + ex.Message);
            }
        }
    }
}

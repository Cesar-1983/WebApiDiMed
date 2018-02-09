using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosLayer.Administracion;
using EntidadesLayer.Administracion;
using EntidadesLayer;

namespace NegocioLayer.Administracion
{
    public class TipoEspecialidadBL
    {
        private TipoEspecialidadDAL dal = new TipoEspecialidadDAL();
        public List<TipoEspecialidad> GetAllTipoEspecialidad()
        {
            return dal.GetAllTipoEspecialidad();
        }
        public ClaseBase.ErrorMesaje BorrarEspecialidad(int pId)
        {
            return dal.BorrarEspecialidad(pId);
        }
        public ClaseBase.ErrorMesaje AgregarTipoEspecialidad(string TipoEspecialidad)
        {
            return dal.AgregarTipoEspecialidad(TipoEspecialidad);
        }
        public ClaseBase.ErrorMesaje ActualizarTipoEspecialidad(TipoEspecialidad TipoEspecialidad)
        {
            return dal.ActualizarTipoEspecialidad(TipoEspecialidad);
        }
    }
}

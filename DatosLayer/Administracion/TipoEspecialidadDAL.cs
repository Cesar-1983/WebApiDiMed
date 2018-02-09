using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesLayer.Administracion;
using EntidadesLayer;
using DatosLayer;
using System.Data.SqlClient;
using System.Data;

namespace DatosLayer.Administracion
{
    public class TipoEspecialidadDAL
    {
        public List<TipoEspecialidad> GetAllTipoEspecialidad() {
            List<TipoEspecialidad> lista = new List<TipoEspecialidad>();
            using (var context = new DBDirMedEntities())
            {
                lista =  context.Database.SqlQuery<TipoEspecialidad>("EXEC dbo.usp_GetAllTipoEspecialidad").ToList();
            }
            return lista;
        }

        public ClaseBase.ErrorMesaje BorrarEspecialidad (int pId){
            SqlParameter Id = new SqlParameter { ParameterName = "@Id", DbType = System.Data.DbType.Int32, Value = pId };
            using (var context = new DBDirMedEntities())
            {
               return context.Database.SqlQuery<ClaseBase.ErrorMesaje>("EXEC dbo.usp_DelTipoEspecialidad @Id", Id).FirstOrDefault();
            }
        }
        public ClaseBase.ErrorMesaje AgregarTipoEspecialidad(string TipoEspecialidad) {
            SqlParameter Desc_TipoEspecialidad = new SqlParameter { ParameterName= "@Desc_TipoEspecialidad",SqlDbType = SqlDbType.NVarChar, Value = TipoEspecialidad };
            using (var context = new DBDirMedEntities())
            {
                return context.Database.SqlQuery<ClaseBase.ErrorMesaje>("EXEC dbo.usp_DelTipoEspecialidad @Desc_TipoEspecialidad", Desc_TipoEspecialidad).FirstOrDefault();
            }
        }
        public ClaseBase.ErrorMesaje ActualizarTipoEspecialidad(TipoEspecialidad TipoEspecialidad)
        {
            SqlParameter Id = new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = TipoEspecialidad.TipoEspecialidadId };
            SqlParameter Desc_TipoEspecialidad = new SqlParameter { ParameterName = "@Desc_TipoEspecialidad", SqlDbType = SqlDbType.NVarChar, Value = TipoEspecialidad.Desc_TipoEspecialidad };
            using (var context = new DBDirMedEntities())
            {
                return context.Database.SqlQuery<ClaseBase.ErrorMesaje>("EXEC dbo.usp_DelTipoEspecialidad @Id, @Desc_TipoEspecialidad", Desc_TipoEspecialidad).FirstOrDefault();
            }
        }

    }
}

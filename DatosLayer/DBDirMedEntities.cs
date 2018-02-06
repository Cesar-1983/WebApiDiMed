using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesLayer.Administracion;
namespace DatosLayer
{
    public class DBDirMedEntities : DbContext
    {
        public DBDirMedEntities() : base("name=DBNicaMedEntities") {

        }
        
    }
}

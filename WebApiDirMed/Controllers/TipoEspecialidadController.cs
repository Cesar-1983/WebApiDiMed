using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDirMed.Models;
using NegocioLayer.Administracion;
using Newtonsoft.Json;

namespace WebApiDirMed.Controllers
{
    [RoutePrefix("api/TipoEspecialidad")]
    public class TipoEspecialidadController : ApiController
    {
        private TipoEspecialidadBL _blTipoEspecialidad = new TipoEspecialidadBL();

        [HttpPost]
        
        [Route("GetAllTipoEspecialidad")]
        public List<TipoEspecialidadModel> GetAllTipoEspecialidad()
        {
            var a =  _blTipoEspecialidad.GetAllTipoEspecialidad();
            List<TipoEspecialidadModel> lista = new List<TipoEspecialidadModel>();
            foreach (var item in a)
            {
                lista.Add(new TipoEspecialidadModel { TipoEspecialidadId = item.TipoEspecialidadId, Desc_TipoEspecialidad = item.Desc_TipoEspecialidad });

            }
            return lista;
        }

        [HttpPost]
        [Route("BorrarTipoEspecialidad")]
        public HttpResponseMessage BorrarTipoEspecialidad([FromBody]TipoEspecialidadRequest model) {

            var a = _blTipoEspecialidad.BorrarEspecialidad(model.IdTipoEspecialidad);
            var a1 = JsonConvert.SerializeObject(a);
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(a1) };
            //Ok(a);
        
        }
    }
}

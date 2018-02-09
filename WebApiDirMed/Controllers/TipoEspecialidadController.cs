using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDirMed.Models;
using NegocioLayer.Administracion;
using Newtonsoft.Json;
using EntidadesLayer;
using EntidadesLayer.Administracion;
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
        [HttpPost]
        [Route("AgregarTipoEspecialidad")]
        public HttpResponseMessage AgregarTipoEspecialidad([FromBody]TipoEspecialidadRequest model)
        {
            var respond = new HttpResponseMessage();
            ClaseBase.ErrorMesaje error = new ClaseBase.ErrorMesaje(); 
            try
            {
                error = _blTipoEspecialidad.AgregarTipoEspecialidad(model.TipoEspecilidad);
                if (error.Error == 0)
                    respond.StatusCode = HttpStatusCode.OK;
                else
                    respond.StatusCode = HttpStatusCode.InternalServerError;
                respond.Content = new StringContent(JsonConvert.SerializeObject(error));
            }
            catch (Exception ex)
            {
                respond.StatusCode = HttpStatusCode.InternalServerError;
                error = new ClaseBase.ErrorMesaje { Error = 1, Mensaje = ex.Message };
                respond.Content = new StringContent(JsonConvert.SerializeObject(error));
                throw;
            }
            return respond;

        }

        [HttpPost]
        [Route("ActualizarTipoEspecialidad")]
        public HttpResponseMessage ActualizarTipoEspecialidad([FromBody]TipoEspecialidadRequest model)
        {
            var respond = new HttpResponseMessage();
            ClaseBase.ErrorMesaje error = new ClaseBase.ErrorMesaje();
            TipoEspecialidad tipoespecialidad = new TipoEspecialidad { TipoEspecialidadId = model.IdTipoEspecialidad, Desc_TipoEspecialidad = model.TipoEspecilidad };
            try
            {
                error = _blTipoEspecialidad.ActualizarTipoEspecialidad(tipoespecialidad);
                if (error.Error == 0)
                    respond.StatusCode = HttpStatusCode.OK;
                else
                    respond.StatusCode = HttpStatusCode.InternalServerError;
                respond.Content = new StringContent(JsonConvert.SerializeObject(error));
            }
            catch (Exception ex)
            {
                respond.StatusCode = HttpStatusCode.InternalServerError;
                error = new ClaseBase.ErrorMesaje { Error = 1, Mensaje = ex.Message };
                respond.Content = new StringContent(JsonConvert.SerializeObject(error));
                throw;
            }
            return respond;

        }

    }
}

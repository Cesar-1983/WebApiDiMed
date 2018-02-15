using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDirMed.Models;
using WebApiDirMed.Utilidades;
namespace WebApiDirMed.Controllers
{
    [RoutePrefix("api/Cuenta")]
    public class CuentaController : ApiController
    {
        [HttpPost]
        [Route("Encriptar")]

        public HttpResponseMessage Encriptar([FromBody]TipoEspecialidadRequest model)
        {
            //var a = CriptoRijndael.Encriptar(texto, "Key@Segura");
            var a = CriptoRijndael.Encrytar(model.TipoEspecilidad);

            //var a = _blTipoEspecialidad.BorrarEspecialidad(model.IdTipoEspecialidad);
            var a1 = JsonConvert.SerializeObject(a);
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(a1) };
            //Ok(a);

        }

        [HttpPost]
        [Route("DesEncriptar")]

        public HttpResponseMessage DesEncriptar([FromBody]TipoEspecialidadRequest model)
        {
            var a = CriptoRijndael.Encrytar(model.TipoEspecilidad);

            //var a = _blTipoEspecialidad.BorrarEspecialidad(model.IdTipoEspecialidad);
            var a1 = JsonConvert.SerializeObject(a.ToString());
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(a1) };
            //Ok(a);

        }

    }
}

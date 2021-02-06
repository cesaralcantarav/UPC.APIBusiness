using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UPC.Business.API.Controllers
{   
    /// <summary>
    /// 
    /// </summary>
    public class ApartmentController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IApartmentRepository _ApartmentRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ApartmentRepository"></param>
        public ApartmentController(IApartmentRepository ApartmentRepository)
        {
            _ApartmentRepository = ApartmentRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// [Produces("application/json")]
        [SwaggerOperation("GetApartments")]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetApartments")]
        public ActionResult GetApartments()
        {
            var ret = _ApartmentRepository.GetApartments();

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idApartment"></param>
        /// <returns></returns>
        [SwaggerOperation("GetApartmentById")]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetApartmentById")]
        public ActionResult GetApartmentById(int idApartment)
        {
            var ret = _ApartmentRepository.GetApartmentById(idApartment);

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProject"></param>
        /// <returns></returns>
        [SwaggerOperation("GetApartmentsByIdProject")]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetApartmentsByIdProject")]
        public ActionResult GetApartmentsByIdProject(int idProject)
        {
            var ret = _ApartmentRepository.GetApartmentsByIdProject(idProject);

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }
    }
}

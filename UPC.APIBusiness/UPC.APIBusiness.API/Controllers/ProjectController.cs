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
    [Produces("application/json")]
    [Route("api/Project")]
    public class ProjectController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IProjectRepository _ProjectRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectRepository"></param>
        public ProjectController(IProjectRepository ProjectRepository)
        {
            _ProjectRepository = ProjectRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerOperation("GetProjects")]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetProjects")]
        public ActionResult GetProjects()
        {
            var ret = _ProjectRepository.GetProjects();

            if (ret == null)
                return StatusCode(401);

            return Json(ret);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerOperation("GetProjectById")]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetProjectById")]
        public ActionResult GetProjectById(int idProject)
        {
            var ret = _ProjectRepository.GetProjectByIdProject(idProject);

            if (ret == null)
                return StatusCode(401);

            return Json(ret);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerOperation("GetProjectsByParams")]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetProjectsByParams")]

        public ActionResult GetProjectsByParams(string parameters)
        {
            var ret = _ProjectRepository.GetProjectsByParams(parameters);

            if (ret == null)
                return StatusCode(401);

            return Json(ret);

        }
    }
}

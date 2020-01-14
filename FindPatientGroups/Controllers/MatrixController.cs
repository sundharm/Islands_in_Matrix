using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindPatientGroups.Models;
using FindPatientGroups.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FindPatientGroups.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MatrixController : Controller
    {

        private readonly IMatrixServices _services;

        public MatrixController(IMatrixServices services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("patient-groups/calculate")]
        //just display the matrix received from request for now
        public ActionResult<int> FindNumberOfPatientGroups(MatrixClass matrix)
        {
            
            var numberOfGroups = _services.numberOfGroups(matrix);
            
            if (numberOfGroups < 0)
            {
                return NotFound("Invalid patients group");
            }

            Dictionary<string, int> response = new Dictionary<string, int>();
            response.Add("numberOfGroups", numberOfGroups);

            return Json(response);
        }
    }
}

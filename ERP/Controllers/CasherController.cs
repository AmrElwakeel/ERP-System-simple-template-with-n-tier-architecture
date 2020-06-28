using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasherController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CasherController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> ChangeDepartment(int id,int dept)
        {
            _unitOfWork.CasherRepository.ChangeCasherDepartment(id, dept);
            if (await _unitOfWork.SaveChanges())
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}

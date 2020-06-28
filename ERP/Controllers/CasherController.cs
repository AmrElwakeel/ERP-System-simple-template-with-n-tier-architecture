using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using ERP.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasherController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CasherController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var allCashers = _unitOfWork.CasherRepository.GetAll();
            return Ok(_mapper.Map<IEnumerable<CasherDto>>(allCashers));
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

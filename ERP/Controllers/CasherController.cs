using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using DAL.Entities;
using ERP.Dto.CasherDto;
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
        public ActionResult<IEnumerable<CasherViewDto>> Get()
        {
            var allCashers = _unitOfWork.CasherRepository.GetAll();

            return Ok(_mapper.Map<IEnumerable<CasherViewDto>>(allCashers));
        }

        [HttpGet("{id}",Name ="GetById")]
        public ActionResult<CasherViewDto> Get(int id)
        {
            var casher = _unitOfWork.CasherRepository.FindById(id);
            if (casher == null)
                return NotFound();
            return Ok(_mapper.Map<CasherViewDto>(casher));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCasherDto createCasherDto)
        {
            var createModel = _mapper.Map<Casher>(createCasherDto);
            _unitOfWork.CasherRepository.Create(createModel);
            if (!await _unitOfWork.SaveChanges())
                return BadRequest();

            var GetModel = _mapper.Map<CasherViewDto>(createModel);

            return CreatedAtRoute(nameof(Get), new { id = GetModel.Id }, GetModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeDepartment(int id,int dept)
        {
            try
            {
                if (_unitOfWork.CasherRepository.FindById(id) == null)
                    return NotFound();

                _unitOfWork.CasherRepository.ChangeCasherDepartment(id, dept);
                if (! await _unitOfWork.SaveChanges())
                {
                    return BadRequest();
                }
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

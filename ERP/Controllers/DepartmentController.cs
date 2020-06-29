using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using DAL.Entities;
using ERP.Dto.DepartmentDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DepartmentViewDto>> Get()
        {
            var AllDept = _unitOfWork.DepartmentRepository.GetAll();
            
            return Ok(_mapper.Map<IEnumerable<DepartmentViewDto>>(AllDept));
        }

        [HttpGet("{id}",Name ="GetDepartmentById")]
        public ActionResult<DepartmentViewDto> Get(int id)
        {
            var Dept = _unitOfWork.DepartmentRepository.FindById(id);
            if (Dept == null)
                return NotFound();

            return Ok(_mapper.Map<DepartmentViewDto>(Dept));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentDto createDepartmentDto)
        {
            var DeptModel = _mapper.Map<Department>(createDepartmentDto);
            _unitOfWork.DepartmentRepository.Create(DeptModel);
            if (!await _unitOfWork.SaveChanges())
                return BadRequest();

            var model = _mapper.Map<DepartmentViewDto>(DeptModel);

            return CreatedAtRoute(nameof(Get), new { id = model.Id }, model);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateDepartmentDto updateDepartmentDto)
        {
            if (_unitOfWork.DepartmentRepository.FindById(updateDepartmentDto.Id) == null)
                return NotFound();

            var DeptModel = _mapper.Map<Department>(updateDepartmentDto);
            _unitOfWork.DepartmentRepository.Update(DeptModel);
            if (!await _unitOfWork.SaveChanges())
                return BadRequest();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_unitOfWork.DepartmentRepository.FindById(id) == null)
                return NotFound();
            _unitOfWork.DepartmentRepository.Delete(id);
            if (!await _unitOfWork.SaveChanges())
                return BadRequest();
            return NoContent();
        }
    }
}

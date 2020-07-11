using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Core.Inrefaces;
using DAL.Entities;
using ERP.Dto.ApplicationUserDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountManager accountManager;
        private readonly IMapper mapper;

        public AccountController(IAccountManager accountManager,IMapper mapper)
        {
            this.accountManager = accountManager;
            this.mapper = mapper;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<Tuple<bool,string[]>>> Create(CreateUserDto createUserDto)
        {
            var user= mapper.Map<CreateUserDto, ApplicationUser>(createUserDto);

            return await accountManager.CreateUserAsync(user,createUserDto.Password);
        }
    }
}

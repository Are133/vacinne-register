using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacinneRegister.API.Response;
using VacinneRegister.Core.DTOs;
using VacinneRegister.Core.Entities;
using VacinneRegister.Core.Interfaces;

namespace VacinneRegister.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonController(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPersonWithVacinne(PersonDTO personDTO)
        {
            var person = _mapper.Map<Person>(personDTO);

            await _personRepository.RegisterPerson(person);

            personDTO = _mapper.Map<PersonDTO>(person);

            var response = new APIResponse<PersonDTO>(personDTO);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetPersonsAndVacinnes(int id)
        {
            var vp = await _personRepository.GetPersonsAndVacinnes(id);
            return Ok(vp);
        }
    }
}

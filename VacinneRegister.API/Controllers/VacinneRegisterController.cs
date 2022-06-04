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
    public class VacinneRegisterController : ControllerBase
    {
        private readonly IVacinneRepository _vacinneRepository;
        private readonly IMapper _mapper;
        public VacinneRegisterController(IVacinneRepository vacinneRepository, IMapper mapper)
        {
            _vacinneRepository = vacinneRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<Vacinne>FindVacinne(int id)
        {
            var vacinne = await _vacinneRepository.FindBydIdVacinne(id);
            return vacinne;
        }

        [HttpGet]
        public async Task<IActionResult> GetVacinnes()
        {
            var vacinnes = await _vacinneRepository.GetVacinnes();

            var vacinnesDTO = _mapper.Map<IEnumerable<VacinneDTo>>(vacinnes);

            var response = new APIResponse<IEnumerable<VacinneDTo>>(vacinnesDTO);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult>RegisterVacinne(VacinneDTo vacinneDTO)
        {
            var vacinne = _mapper.Map<Vacinne>(vacinneDTO);

            await _vacinneRepository.RegisterVacinne(vacinne);

            vacinneDTO = _mapper.Map<VacinneDTo>(vacinne);

            var response = new APIResponse<VacinneDTo>(vacinneDTO);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVacinne(int id, VacinneDTo vacinneDTo)
        {
            var vacinne = _mapper.Map<Vacinne>(vacinneDTo);
            vacinne.Id = id;
            await _vacinneRepository.UpdateVacinne(vacinne);

            return Ok(vacinne);
        }

        [HttpDelete]
        public async Task<IActionResult>DeleteVacinne(int id)
        {
            var result = await _vacinneRepository.DeleteVacinne(id);
            return Ok(result);
        }
    }
}

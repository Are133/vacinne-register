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
    public class MunicipalityController : ControllerBase
    {
        private readonly IMunicipalityRepository _municipalityRepository;

        private readonly IMapper _mapper;

        public MunicipalityController(IMunicipalityRepository municipalityRepository, IMapper mapper)
        {
            _municipalityRepository = municipalityRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<Municipality> FindVacinne(int id)
        {
            var vacinne = await _municipalityRepository.FindBydIdMunicipality(id);
            return vacinne;
        }

        [HttpGet]
        public async Task<IActionResult> GetMunicipalities()
        {
            var municipalities = await _municipalityRepository.GetMunicipalities();

            var municipalitiesDTo = _mapper.Map<IEnumerable<MunicipalityDTo>>(municipalities);

            var response = new APIResponse<IEnumerable<MunicipalityDTo>>(municipalitiesDTo);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterMunicipality(MunicipalityDTo municipalityDTo)
        {
            var municipalitie = _mapper.Map<Municipality>(municipalityDTo);

            await _municipalityRepository.RegisterMunicipality(municipalitie);

            municipalityDTo = _mapper.Map<MunicipalityDTo>(municipalitie);

            var response = new APIResponse<MunicipalityDTo>(municipalityDTo);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMunicipality(int id, MunicipalityDTo municipalityDTo)
        {
            var municipalitie = _mapper.Map<Municipality>(municipalityDTo);
            municipalitie.Id = id;
            await _municipalityRepository.UpdateMunicipality(municipalitie);

            return Ok(municipalitie);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMunicipality(int id)
        {
            var result = await _municipalityRepository.DeleteMunicipality(id);
            return Ok(result);
        }
    }
}

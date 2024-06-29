using AutoMapper;
using Fiap.Api.Residuos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Residuos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LixeiraController : ControllerBase
    {
        private readonly ILixeiraService _lixeiraService;
        private readonly IMapper _mapper;

        public LixeiraController(ILixeiraService lixeiraService, IMapper mapper1) 
        {
            _lixeiraService = lixeiraService;
            _mapper = mapper1;
        }


    }
}

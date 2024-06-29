using AutoMapper;
using Fiap.Api.Residuos.Data;
using Fiap.Api.Residuos.Models;
using Fiap.Api.Residuos.Services;
using Fiap.Api.Residuos.ViewModel;
using Microsoft.AspNetCore.Authorization;
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
        private DatabaseContext @object;

        public LixeiraController(ILixeiraService lixeiraService, IMapper mapper1)
        {
            _lixeiraService = lixeiraService;
            _mapper = mapper1;
        }


        //campo abaixo apenas para tentativa da implementação dos tests
        public LixeiraController(DatabaseContext @object)
        {
            this.@object = @object;
        }





        [HttpGet]
        [Authorize(Roles = "user, gerente, admin")]
        public ActionResult<IEnumerable<LixeiraViewModel>> Get()
        {
            var lista = _lixeiraService.ListarLixeiras();
            var viewModelList = _mapper.Map<IEnumerable<LixeiraViewModel>>(lista);

            if (viewModelList == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(viewModelList);
            }
        }



        [HttpGet("{id}")]
        [Authorize(Roles = "user, gerente, admin")]
        public ActionResult<LixeiraViewModel> Get([FromRoute]int id)
        {
            var model = _lixeiraService.ObterLixeiraPorId(id);

            if (model == null)
            {
                return NotFound();
            } else
            {
                var viewModel = _mapper.Map<LixeiraViewModel>(model);
                return Ok(viewModel);
            }
        }


        [HttpPost]
        [Authorize(Roles = "admin, gerente")]
        public ActionResult Post([FromBody] LixeiraViewModel viewModel)
        {
            var model = _mapper.Map<LixeiraModel>(viewModel);
            _lixeiraService.CriarLixeira(model);

            return CreatedAtAction( nameof(Get), new { id = model.LixeiraId}, model);
        } 
        
        
        [HttpPut("{id}")]
        [Authorize(Roles = "admin, gerente")]
        public ActionResult Put([FromRoute] int id,[FromBody] LixeiraViewModel viewModel)
        {
            if (viewModel.LixeiraId == id)

            {
                var model = _mapper.Map<LixeiraModel>(viewModel);
                _lixeiraService.AtualizarLixeira(model);

                return NoContent();
            }
            else
            { 
                return BadRequest();
            }

            
        }








        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult Delete([FromRoute] int id)
        {
            _lixeiraService.DeletarLixeira(id);
            return NoContent();
        }


    }
}

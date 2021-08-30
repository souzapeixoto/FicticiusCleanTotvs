using Application.Interface;
using AutoMapper;
using Domain.DTOs;
using Domain.DTOs.InputModel;
using Domain.Entities;
using Infrastructure.CrossCutting.UnitOfWork.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFicticiusCleanTotvs.Controllers
{
    [Route("api/Veiculos")]
    public class VeiculosController : ControllerBase
    {
        private readonly IAppServiceVeiculo _appServiceVeiculo;
        private readonly IMapper _map;
        private readonly IUnitOfWork _unitOfWork;
        public VeiculosController(IAppServiceVeiculo appServiceVeiculo, IMapper map, IUnitOfWork unitOfWork)
        {
            _map = map;
            _appServiceVeiculo = appServiceVeiculo;
            _unitOfWork = unitOfWork;
        }
        // PUT api/values/5
        [HttpGet]
        public IEnumerable<DTOVeiculo> Get()
        {
            ICollection<DTOVeiculo> veiculos =
                _map.Map<List<DTOVeiculo>>(_appServiceVeiculo.GetAll().ToList());

            return veiculos;
        }

        [HttpGet("{id}")]
        public ActionResult<DTOVeiculo> GetById(int id)
        {
            var veiculo = _appServiceVeiculo.GetById(id);
            var resp = _map.Map<DTOVeiculo>(veiculo);
            return resp;
        }

        [HttpGet]
        [Route("/PrevisaoDeGastos")]
        public ActionResult<DTOVeiculo> GetPrevisaoDeGastos(InputModelPrevisaoDeGastos model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
            }

            try
            {                
                return Ok(_appServiceVeiculo.CalculaPrevisaoDeGastos(model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpPost]
        public async Task<ActionResult> Post(DTOVeiculo model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
            }
            
            try
            {
                var veiculo = _map.Map<Veiculo>(model);
                _appServiceVeiculo.Insert(veiculo);
                _unitOfWork.Commit();
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }
        [HttpPut]
        public async Task<ActionResult> Put(DTOVeiculo model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
            }

            try
            {
                if(model.Id > 0)
                {
                    var veiculo = _appServiceVeiculo.GetById(model.Id);
                    _map.Map(model, veiculo);
                    _appServiceVeiculo.Update(veiculo);
                }
                else
                {
                    _appServiceVeiculo.Insert(_map.Map<Veiculo>(model));
                }
               
                _unitOfWork.Commit();
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <=0)
            {
                return BadRequest();
            }

            try
            {
                var veiculo = _appServiceVeiculo.GetById(id);
                _appServiceVeiculo.Delete(veiculo);

                _unitOfWork.Commit();
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }


}

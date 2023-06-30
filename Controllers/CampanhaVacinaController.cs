    using CampanhaVacinacao.Models;
    using CampanhaVacinacao.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;



namespace CampanhaVacinacao.Controllers
{
    [ApiController]
    [Route("api/vacinacao")]
    public class VacinacaoController : ControllerBase
    {
        private readonly SolicitanteRepository _solicitanteRepository;
        private readonly RelatorioRepository _relatorioRepository;
        private readonly CampanhaVacinaService _campanhaVacinaService;

        public VacinacaoController(
            SolicitanteRepository solicitanteRepository,
            RelatorioRepository relatorioRepository,
            CampanhaVacinaService campanhaVacinaService)
        {
            _solicitanteRepository = solicitanteRepository;
            _relatorioRepository = relatorioRepository;
            _campanhaVacinaService = campanhaVacinaService;
        }

        [HttpPost("consulta")]
        public async Task<IActionResult> ConsultarVacinacao([FromBody] ConsultaVacinacaoRequest request)
        {
            Solicitantes solicitante = _solicitanteRepository.GetByCPF(request.CPF);

            if (solicitante == null)
            {
                solicitante = new Solicitantes { Nome = request.Nome, CPF = request.CPF };
                _solicitanteRepository.Add(solicitante);
            }

            int quantidadeVacinados = await _campanhaVacinaService.GetQuantidadeVacinadosPfizerNoRJ(request.Data);

            Relatorio relatorio = new Relatorio
            {
                DataSolicitacao = DateTime.Now,
                Descricao = $"Relatório Vacinas Pfizer aplicadas no RJ_{request.Data:yyyy-MM-dd}",
                DataAplicacao = request.Data,
                QuantidadeTotalVacinados = quantidadeVacinados,
                Solicitante = solicitante
            };

            _relatorioRepository.Add(relatorio);

            return Ok(relatorio);
        }

        [HttpGet("relatorios")]
        public IActionResult ListarRelatorios()
        {
            var relatorios = _relatorioRepository.GetAll();
            return Ok(relatorios);
        }
    }

    public class ConsultaVacinacaoRequest
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Data { get; set; }
    }
}

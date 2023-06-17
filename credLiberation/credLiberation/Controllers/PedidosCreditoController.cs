using credLiberation.Data;
using credLiberation.Data.Enum;
using credLiberation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace credLiberation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosCreditoController : ControllerBase
    {
        private readonly ApiContext _context;
        public PedidosCreditoController(ApiContext context)
        {
            _context = context;
        }

        //Create
        [HttpPost]
        public JsonResult Create(PedidoDeCredito pedido)
        {
            if (pedido.Id == 0)
            {
                int statusPedido = 1;

                #region Variáveis

                var validacoes = pedido.Validacao;
                var tipoClienteValidacao = validacoes.TipoCliente.Trim().ToLower();
                var tipoCliente = pedido.Tipo.Trim().ToLower();
                var intervaloDtPrimeiroVencimento = (pedido.DtPrimeiroVencimento - DateTime.Today).Days; 

                #endregion

                #region Juros

                double taxaJuros = 1;

                switch (tipoCliente)
                {
                    case "direto": taxaJuros = Convert.ToDouble(TipoCredito.Direto); break;
                    case "consignado": taxaJuros = Convert.ToDouble(TipoCredito.Consignado); break;
                    case "pessoajurídica":
                    case "pessoajuridica": taxaJuros = Convert.ToDouble(TipoCredito.PessoaJuridica); break;
                    case "pessoafísica":
                    case "pessoafisica": taxaJuros = Convert.ToDouble(TipoCredito.PessoaFisica); break;
                    case "imobiliário":
                    case "imobiliario": taxaJuros = Convert.ToDouble(TipoCredito.Imobiliario); break;
                    default:
                        return new JsonResult(BadRequest());
                }

                var valorJuros = (pedido.Valor * taxaJuros);
                var valorTotal = (pedido.Valor * valorJuros);

                #endregion

                #region Validações

                if (pedido.Valor > validacoes.ValorMax)
                    statusPedido = 0;

                if ((pedido.QtdParcelas < validacoes.QtdParcelasMin) || (pedido.QtdParcelas > validacoes.QtdParcelasMax))
                    statusPedido = 0;

                if (tipoClienteValidacao.Equals(tipoCliente) && pedido.Valor < validacoes.ValorMinTipoCliente)
                    statusPedido = 0;

                if (intervaloDtPrimeiroVencimento < validacoes.DtPrimeiroVencimentoMin || intervaloDtPrimeiroVencimento > validacoes.DtPrimeiroVencimentoMax)
                    statusPedido = 0;

                #endregion

                if (statusPedido == 1)
                {
                    Resultado resultado = new Resultado
                    {
                        Status = statusPedido,
                        ValorJuros = valorJuros,
                        TotalComJuros = valorTotal
                    };

                    _context.Pedidos.Add(pedido);
                    _context.SaveChanges();

                    return new JsonResult(Ok(resultado));
                }
                else
                {
                    Resultado resultado = new Resultado
                    {
                        Status = statusPedido,
                        ValorJuros = valorJuros,
                        TotalComJuros = valorTotal
                    };

                    return new JsonResult(BadRequest(resultado));
                }
            }
            else
            {
                return new JsonResult(BadRequest("Para fazer um pedido use Id = 0"));
            }
        }
    }
}

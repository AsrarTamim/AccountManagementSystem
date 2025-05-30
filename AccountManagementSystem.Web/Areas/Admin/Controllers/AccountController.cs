using AccountManagementSystem.Application.Features.Accounts.Query;
using AccountManagementSystem.Domain;
using AccountManagementSystem.Web.Areas.Admin.Models.Account;
using AccountManagemnetSystem.Domain.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace AccountManagementSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController(ILogger<AccountController> logger, IMapper mapper, IMediator mediator) : Controller
    {
        private readonly ILogger<AccountController> _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IMediator _mediator = mediator;

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> GetAccountJsonData([FromBody] AcountListModel model)
        {
            try
            {
                var searchDto = _mapper.Map<AccountSearchDto>(model.SearchItem);
                var query = new GetAccountQuery
                {
                    PageIndex = model.PageIndex,
                    PageSize = model.PageSize,
                    OrderBy = model.FormatSortExpression("AccountName", "Description", "Price", "Id"),
                    Search = searchDto
                };
                Console.WriteLine(" Controller hit!");
                Console.WriteLine($"OrderBy: {query.OrderBy}");

                var (data, total, totalDisplay) = await _mediator.Send(query);

                var Accounts = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = data.Select(record => new string[]
                    {
                HttpUtility.HtmlEncode(record.Name),
                HttpUtility.HtmlEncode(record.AccountType),
                record.IsActive.ToString(),
                record.Id.ToString()
                    }).ToArray()
                };

                return Json(Accounts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was a problem in getting Accounts");
                return Json(DataTables.EmptyResult);
            }
        }
    }
}


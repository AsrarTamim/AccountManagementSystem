using AccountManagementSystem.Application.Features.Accounts.Command;
using AccountManagementSystem.Application.Features.Accounts.Query;
using AccountManagementSystem.Domain;
using AccountManagementSystem.Web.Areas.Admin.Models;
using AccountManagementSystem.Web.Areas.Admin.Models.Account;
using AccountManagemnetSystem.Domain.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Web;
using AccountManagementSystem.Infrastructure;
using Microsoft.AspNetCore.Authorization;
namespace AccountManagementSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin, HR")]
    public class AccountController(ILogger<AccountController> logger, IMapper mapper, IMediator mediator) : Controller
    {
        private readonly ILogger<AccountController> _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IMediator _mediator = mediator;

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            var model = new AccountAddCommand();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AccountAddCommand AccountAddCommand)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _mediator.Send(AccountAddCommand);

                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Account added",
                        Type = ResponseTypes.Success
                    });

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to add Account");

                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Failed to add Account",
                        Type = ResponseTypes.Danger
                    });
                }
            }
            return View(AccountAddCommand);
        }
        public async Task<IActionResult> Update(Guid id)
        {
            var command = await _mediator.Send(new GetAccountByIdQuery { Id = id });
            var model = _mapper.Map<UpdateAccountModel>(command);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateAccountModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var command = _mapper.Map<AccountUpdateCommand>(model);
                    await _mediator.Send(command);

                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Account updated",
                        Type = ResponseTypes.Success
                    });

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Update failed: {Message}", ex.Message);

                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Failed to update Account: " + ex.Message,
                        Type = ResponseTypes.Danger
                    });
                }

            }

            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _mediator.Send(new AccountDeleteCommand { Id = id });

                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Account deleted",
                    Type = ResponseTypes.Success
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete Account");

                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Failed to delete Account",
                    Type = ResponseTypes.Danger
                });
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<JsonResult> GetAccountJsonData([FromBody] AccountListModel model, string v)
         
        
        {
            try
            {

                var searchDto = _mapper.Map<AccountSearchDto>(model.SearchItem);

                var query = new GetAccountQuery
                {
                    PageIndex = model.PageIndex,
                    PageSize = model.PageSize,
                    OrderBy = model.FormatSortExpression("Name", "AccountType", "Cash", "Id"),
                    Search = searchDto
                };


                var (data, total, totalDisplay) = await _mediator.Send(query);

                var result = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = data.Select(record => new string[]
                    {
                        HttpUtility.HtmlEncode(record.Name),
                        HttpUtility.HtmlEncode(record.AccountType),
                        record.Cash.ToString(),
                        record.Id.ToString()
                    }).ToArray()
                };
                _logger.LogInformation("Total: {Total}, Display: {Display}, Records: {Count}", total, totalDisplay, data.Count());

                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was a problem in getting Accounts");
                return Json(DataTables.EmptyResult);
            }
        }

    }
}


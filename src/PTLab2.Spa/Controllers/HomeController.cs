using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PTLab2.Application.Products.Get;
using PTLab2.Application.Products.GetById;
using PTLab2.Application.Promocodes.GetByCode;
using PTLab2.Application.Purchases.Buy;
using PTLab2.Spa.Models;

namespace PTLab2.Spa.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ISender _sender;

    public HomeController(
        ILogger<HomeController> logger, 
        ISender sender)
    {
        _logger = logger;
        _sender = sender;
    }

    public async Task<IActionResult> Index()
    {
        var command = new GetProductsCommand();
        var result = await _sender.Send(command);
        ViewBag.Products = result;
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Buy(int id)
    {
        var command = new GetProductByIdCommand(id);
        var result = await _sender.Send(command);
        ViewBag.Product = result;
        return View();
    }

    [HttpPost]
    public async Task<string> Buy(BuyPurchaseCommand command)
    {
        await _sender.Send(command);
        return "Спасибо за покупку, " + command.Person + "!";
    }

    [HttpPost]
    public async Task<ActionResult> ApplyPromoCode(string promoCode, int price)
    {
        var command = new GetPromoCodeByCodeCommand(promoCode);
        
        try{
            var result = await _sender.Send(command);
            return Json(new { Message = "Промокод активирован", NewPrice = price * ((100 - result.Discount)/100.0), Sucess = true });
        } catch (Exception ex) {
            return Json(new { Message = ex.Message, NewPrice = price, Sucess = false });
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

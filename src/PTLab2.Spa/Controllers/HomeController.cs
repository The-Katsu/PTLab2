using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PTLab2.Application.Products.Get;
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
    public IActionResult Buy(int id)
    {
        ViewBag.ProductId = id;
        return View();
    }

    [HttpPost]
    public async Task<string> Buy(BuyPurchaseCommand command)
    {
        await _sender.Send(command);
        return "Спасибо за покупку, " + command.Person + "!";
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

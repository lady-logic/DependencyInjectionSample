using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using sample.Models;
using sample.Services;

namespace sample.Controllers;

public class HomeController : Controller
{
    private readonly ISingletonService _singletonService;
    private readonly ITransientService _transientService;
    private readonly ITransientService _transientService2;
    private readonly IScopedService _scopedService;
    private readonly IScopedService _scopedService2;

    public HomeController(
        ISingletonService singletonService,
        ITransientService transientService,
        ITransientService transientService2,
        IScopedService scopedService,
        IScopedService scopedService2)
    {
        _singletonService = singletonService;
        _transientService = transientService;
        _transientService2 = transientService2;
        _scopedService = scopedService;
        _scopedService2 = scopedService2;
    }

    //[HttpGet("test")]
    public IActionResult Index()
    {
        ViewBag.Singleton = _singletonService.GetOperationId();
        ViewBag.Transient = _transientService.GetOperationId();
        ViewBag.Transient2 = _transientService2.GetOperationId();
        ViewBag.Scoped = _scopedService.GetOperationId();
        ViewBag.Scoped2 = _scopedService2.GetOperationId();

        return View();
    }
}

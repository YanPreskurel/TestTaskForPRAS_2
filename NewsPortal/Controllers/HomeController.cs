using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Data;
using System;

public class HomeController : Controller
{
    private readonly AppDbContext _db;

    public HomeController(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var lang = Request.Cookies["lang"] ?? "ru";

        var model = await _db.WhoWeArePages.FirstOrDefaultAsync();
        var cases = await _db.Cases.ToListAsync();

        ViewBag.Cases = cases;
        ViewBag.Lang = lang;

        return View(model);
    }
}

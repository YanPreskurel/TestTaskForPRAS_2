using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Data;

public class CaseController : BaseController
{
    private readonly AppDbContext _db;

    public CaseController(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Details(int id)
    {
        var lang = Request.Cookies["lang"] ?? "ru";

        var item = await _db.Cases.FirstOrDefaultAsync(x => x.Id == id);

        ViewBag.Lang = lang;

        if (item == null)
            return NotFound();

        return View(item);
    }
}

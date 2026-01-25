using MVCExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MVCExample.Controllers;

public class SiteController : Controller
{
    readonly DatabaseContext databaseContext = new();

    public async Task<ActionResult> Home()
    {
        return View();
    }

    public async Task<ActionResult<Moon>> All()
    {
        try
        {
            ViewData["Moons"] = await databaseContext.Moons.Include("Planet").OrderBy(m => m.Name).ToListAsync();
            return View();
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = e.Message;
            return RedirectToAction("Error");
        }
    }

    [HttpGet]
    public async Task<ActionResult> AddPlanet()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> AddPlanet(string planetName)
    {
        try
        {
            if (planetName == null)
            {
                throw new Exception("Planet name can not be null or empty...");
            }
            databaseContext.Planets.Add(new Planet { Name = planetName });
            await databaseContext.SaveChangesAsync();
            return RedirectToAction("All");
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = e.Message;
            return RedirectToAction("Error");
        }
    }

    [HttpGet]
    public async Task<ActionResult> AddMoon()
    {
        try
        {
            ViewData["Planets"] = await databaseContext.Planets.OrderBy(p => p.Name).ToListAsync();
            return View();
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = e.Message;
            return RedirectToAction("Error");
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddMoon(string moonName, int planetId)
    {
        try
        {
            if (moonName == null)
            {
                throw new Exception("Moon name can not be null or empty...");
            }
            else if (planetId == 0)
            {
                throw new Exception("Planet can not be null or empty...");
            }
            databaseContext.Moons.Add(new Moon { Name = moonName, PlanetId = planetId });
            await databaseContext.SaveChangesAsync();
            return RedirectToAction("All");
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = e.Message;
            return RedirectToAction("Error");
        }
    }

    [HttpGet]
    public async Task<ActionResult> EditMoon(int moonId)
    {
        try
        {
            Moon? moon = await databaseContext.Moons.Include("Planet").Where(m => m.Id == moonId).FirstOrDefaultAsync();
            ViewData["Moon"] = moon;
            ViewData["Planets"] = await databaseContext.Planets.Where(p => p.Id != moon!.PlanetId).OrderBy(p => p.Name).ToListAsync();;
            return View();
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = e.Message;
            return RedirectToAction("Error");
        }
    }

    [HttpPost]
    public async Task<ActionResult> EditMoon(int moonId, string moonName, int planetId)
    {
        try
        {
            if (moonName == null)
            {
                throw new Exception("Moon name can not be null or empty...");
            }
            Moon? moon = await databaseContext.Moons.Where(m => m.Id == moonId).FirstOrDefaultAsync();
            moon!.Name = moonName;
            moon.PlanetId = planetId;
            databaseContext.Moons.Update(moon);
            await databaseContext.SaveChangesAsync();
            return RedirectToAction("All");
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = e.Message;
            return RedirectToAction("Error");
        }
    }

    public async Task<ActionResult> DeleteMoon(int moonId)
    {
        try
        {
            Moon? moon = await databaseContext.Moons.Where(m => m.Id == moonId).FirstOrDefaultAsync();
            //databaseContext.Moons.Remove(moon!);
            //await databaseContext.SaveChangesAsync();
            return RedirectToAction("All");
        }
        catch (Exception e)
        {
            TempData["ErrorMessage"] = e.Message;
            return RedirectToAction("Error");
        }
    }

    public async Task<ActionResult> Error()
    {
        ViewData["ErrorMessage"] = TempData["ErrorMessage"];
        return View();
    }
}

using DoctorsOffice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoctorsOffice.Controllers
{
  public class SpecialtiesController : Controller
  {
    private readonly DoctorsOfficeContext _db;

    public SpecialtiesController(DoctorsOfficeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Specialties.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Specialty specialty)
    {
      if(!_db.Specialties.Any(x => x.Name == specialty.Name))
      {
        _db.Specialties.Add(specialty);
        _db.SaveChanges();
      }

      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisSpecialty = _db.Specialties
      .Include(specialty => specialty.Doctors)
      .ThenInclude(join => join.Doctor)
      .FirstOrDefault(specialty => specialty.SpecialtyId == id);
      return View(thisSpecialty);
    }

    public ActionResult AddDoctor(int id)
    {
      var thisSpecialty = _db.Specialties.FirstOrDefault(specialties => specialties.SpecialtyId == id);
      ViewBag.DoctorId = new SelectList(_db.Doctors, "DoctorId", "Name");
      return View(thisSpecialty);
    } 

    [HttpPost]
    public ActionResult AddDoctor(Specialty specialty, int DoctorId)
    {
      if(DoctorId != 0 && !_db.DoctorSpecialty.Any(x => x.DoctorId == DoctorId && x.SpecialtyId == specialty.SpecialtyId))
      {
        _db.DoctorSpecialty.Add(new DoctorSpecialty() { DoctorId = DoctorId, SpecialtyId = specialty.SpecialtyId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = specialty.SpecialtyId});
    }
  }
}
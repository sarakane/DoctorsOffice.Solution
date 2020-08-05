using DoctorsOffice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DoctorsOffice.Controllers
{
  public class PatientsController : Controller
  {
    private readonly DoctorsOfficeContext _db;

    public PatientsController(DoctorsOfficeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Patients.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.DoctorId = new SelectList(_db.Doctors, "DoctorId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Patient patient, int DoctorId)
    {
      _db.Patients.Add(patient);
      if(DoctorId != 0 && !_db.DoctorPatient.Any(x => x.DoctorId == DoctorId && x.PatientId == patient.PatientId))
      {
        _db.DoctorPatient.Add(new DoctorPatient() {DoctorId = DoctorId, PatientId = patient.PatientId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisPatient = _db.Patients
      .Include(patient => patient.Doctors)
      .ThenInclude(join => join.Doctor)
      .FirstOrDefault(patient => patient.PatientId == id);
      return View(thisPatient);
    }

    public ActionResult Edit(int id)
    {
      var thisPatient = _db.Patients.FirstOrDefault(patients => patients.PatientId == id);
      return View(thisPatient);
    }

    [HttpPost]
    public ActionResult Edit(Patient patient)
    {
      _db.Entry(patient).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = patient.PatientId});
    }
  }
}
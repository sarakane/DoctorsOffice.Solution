using Microsoft.AspNetCore.Mvc;

namespace DoctorsOffice.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}
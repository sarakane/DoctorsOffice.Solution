using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoctorsOffice.Models
{
  public class Patient
  {
    public Patient()
    {
      this.Doctors = new HashSet<DoctorPatient>();
    }

    public int PatientId { get; set; }
    public string Name { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd MM yyy}")]
    public System.DateTime Birthday { get; set; }
    public ICollection<DoctorPatient> Doctors { get; }
  }
}
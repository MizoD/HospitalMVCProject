using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HospitalMVCProject.Models;
using HospitalMVCProject.Data;
using Microsoft.EntityFrameworkCore;
using HospitalMVCProject.ModelsVM;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HospitalMVCProject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context = new();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult DoctorPage(DoctorFilter doctor, int page = 1)
    {
        IQueryable<Doctor> Doctors = _context.Doctors.Include(e=> e.Specialty).OrderByDescending(e=> e.Traffic);
        var Specialties = _context.Specialties;
        const double totalNumberOfDoctorsInPages = 9.0;

        if (doctor.doctorName is not null)
        {
            Doctors = Doctors.Where(e => e.FirstName.Contains(doctor.doctorName) || e.LastName.Contains(doctor.doctorName));
            ViewBag.doctorName = doctor.doctorName;
        }

        if (doctor.SpecialtyId > 0 && doctor.SpecialtyId < Specialties.Count())
        {
            Doctors = Doctors.Where(e => e.SpecialtyId == doctor.SpecialtyId);
            ViewData["specialtyId"] = doctor.SpecialtyId;
        }
        if(doctor.isAvailable) {
            Doctors = Doctors.Where(e=> e.Available);
            ViewBag.isAvailable = doctor.isAvailable;
        }

        //Pagination
        var totalNumberOfPages = Math.Ceiling(Doctors.Count() / totalNumberOfDoctorsInPages);

        if (totalNumberOfPages < page)
            return NotFound();

        Doctors = Doctors.Skip((page - 1) * (int)totalNumberOfDoctorsInPages).Take((int)totalNumberOfDoctorsInPages);

        ViewBag.totalNumberOfPages = totalNumberOfPages;
        ViewBag.currentPage = page;

        ViewData["listOfSpecialties"] = Specialties.ToList();
        return View(Doctors.ToList());
    }
    [HttpGet]
    public IActionResult BookingForm(int doctorId)
    {
        var doctor = _context.Doctors.FirstOrDefault(d => d.DoctorID == doctorId);
        if (doctor == null)
        {
            return NotFound();
        }
        return View(doctorId);
    }

    [HttpPost]
    public IActionResult BookingForm(Appointment appointment)
    {
        var doctor = _context.Doctors.First(d => d.DoctorID == appointment.DoctorId);

        ModelState.Remove("Doctor");
        if (!ModelState.IsValid)
        {
            return View(appointment);
        }
        
        if (doctor == null) return NotFound();

        
        doctor.Traffic++;
        _context.Appointments.Add(appointment);
        _context.SaveChanges();

        return RedirectToAction("DoctorPage");
    }

    public IActionResult Booked(string doctorFirstName, DateTime date, string phone ,int page = 1)
    {
        if (HttpContext.Session.GetString("IsAuthorized") != "true")
        {
            return RedirectToAction("EnterPin");
        }
        IQueryable<Appointment> appointments = _context.Appointments.Include(e=> e.Doctor).OrderByDescending(e=> e.Date);
        const double totalNumberInPages = 3.0;
        if (appointments is null) return NotFound();

        if (!string.IsNullOrWhiteSpace(phone) && phone != "1234")
        {
            appointments = appointments.Where(e => e.PatientPhone.Trim() == phone.Trim());
            ViewBag.phone = phone;
        }


        if (doctorFirstName is not null)
        {
            appointments = appointments.Where(e => e.Doctor.FirstName.Contains(doctorFirstName));
            ViewBag.doctorFirstName = doctorFirstName;
        }
        if(date != default(DateTime))
        {
            appointments = appointments.Where(e => e.Date == date);
            ViewBag.date = date;
        }

        //Pagination
        var totalNumberOfPages = Math.Ceiling(appointments.Count() / totalNumberInPages);

        if (totalNumberOfPages < page)
            return NotFound();

        appointments = appointments.Skip((page - 1) * (int)totalNumberInPages).Take((int)totalNumberInPages);

        ViewBag.totalNumberOfPages = totalNumberOfPages;
        ViewBag.currentPage = page;

        return View(appointments.ToList());
    }

    [HttpGet]
    public IActionResult EnterPin()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CheckPin(string phone)
    {
        if (_context.Appointments.Any(a => a.PatientPhone == phone) || phone == "1234")
        {
            HttpContext.Session.SetString("IsAuthorized", "true");
            return RedirectToAction("Booked", new { phone = phone });
        }

        ViewBag.Error = "There is no appointments with this phone number. Please try again.";
        return View("EnterPin");
    }

    [HttpPost]
    public IActionResult DeleteAppointment(int id)
    {
        var appointment = _context.Appointments.FirstOrDefault(a => a.AppointmentId == id);
        if (appointment == null)
        {
            return NotFound();
        }

        _context.Appointments.Remove(appointment);
        _context.SaveChanges();

        // Redirect to the list or a confirmation page
        return RedirectToAction("Booked");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

using Microsoft.AspNetCore.Mvc;
using ServiceManagerApp3.Data;
using ServiceManagerApp3.Models;
namespace ServiceManagerApp3.Controllers
{
    public class ServiceRequestController : Controller
    {
        private ApplicationContext _context;
        public ServiceRequestController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var request=_context.ServiceRequests.ToList();
            return View(request);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ServiceRequest request)
        {
            if (ModelState.IsValid)
            {
                request.CreateTime= DateTime.Now;
                _context.ServiceRequests.Add(request);
                _context.SaveChanges();
                
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var request = _context.ServiceRequests.Find(id);
            if(request==null)
                return NotFound();
            return View(request);
        }
        [HttpPost]
        public IActionResult Edit(ServiceRequest request)
        {
            if (ModelState.IsValid)
            {
                _context.ServiceRequests.Update(request);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var request= _context.ServiceRequests.Find(id); 
            if (request==null)
                return NotFound();

            
            return View(request);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var request = _context.ServiceRequests.Find(id);
            if (request == null)
                return NotFound();
            _context.ServiceRequests.Remove(request);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var request = _context.ServiceRequests.Find(id);
            if (request == null)
            {
                return NotFound();
            }
            return View(request);
        }
    }
}

using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MedicineTrackerMVC.Models;
using MedicineTrackerMVC.Helper;
using System.Net.Http;
using Newtonsoft.Json;

namespace MedicineTrackerMVC.Controllers
{
    /// <summary>
    /// Calling Web API HTTP client
    /// </summary>
    public class HomeController : Controller
    {
        private readonly MedicineAPI _medicineAPI = new MedicineAPI();

        public async Task<IActionResult> Index()
        {
            List<MedicineData> medicines = new List<MedicineData>();
            HttpClient client = _medicineAPI.Initial();
            HttpResponseMessage res = await client.GetAsync("https://localhost:5001/api/medicine");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                medicines = JsonConvert.DeserializeObject<List<MedicineData>>(results);
            }
            return View(medicines);
        }
    }
}

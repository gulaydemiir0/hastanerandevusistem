using HastaneGD1.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HastaneGD1.Controllers
{
    public class DurumTrueAPI : Controller
    {
        Uri apiAdresi = new Uri("https://localhost:7111/api/Randevus/DurumTrue");
        private readonly HttpClient baglanti;

        public DurumTrueAPI()
        {
            baglanti = new HttpClient();
            baglanti.BaseAddress = apiAdresi;
        }
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await baglanti.GetAsync(apiAdresi);

            if (response.IsSuccessStatusCode)
            {
                string veriyakala = await response.Content.ReadAsStringAsync();
                var durumTrueRandevular = JsonConvert.DeserializeObject<IEnumerable<Randevu>>(veriyakala);

                return View(durumTrueRandevular);
            }
            else
            {
                return View("Error");
            }

            
    }
}
}

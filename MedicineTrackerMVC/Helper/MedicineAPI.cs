using System;
using System.Net.Http;

namespace MedicineTrackerMVC.Helper
{
    //Http Call
    public class MedicineAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5001/");
            return client;
        }
    }
}

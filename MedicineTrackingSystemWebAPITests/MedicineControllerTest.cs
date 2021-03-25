using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MedicineTrackingSystemWebAPI.Controllers;
using MedicineTrackingSystemWebAPI.Data;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace MedicineTrackingSystemWebAPITests
{
    public class MedicineControllerTest
    {
        private readonly MedicineController _controller;
        //private readonly Context _context;
        public MedicineControllerTest(MedicineController controller)
        {
            _controller = controller;
            //_context = context;
            //_controller = new MedicineController(_context);
        }
        [Fact]
        public void GetMedicineTest()
        {
            var response = _controller.GetMedicine();
            //Assert.Equal(200, response.StatusCode);
            //Assert.NotNull(response);
        }
    }
}

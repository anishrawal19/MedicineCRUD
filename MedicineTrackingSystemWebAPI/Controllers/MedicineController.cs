using System;
using System.Linq;
using MedicineTrackingSystemWebAPI.Data;
using MedicineTrackingSystemWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MedicineTrackerMVC.Models;
using System.Net;
using System.ComponentModel.DataAnnotations;

namespace MedicineTrackingSystemWebAPI.Controllers
{
    /// <summary>
    /// Medicine Controller for CRUD
    /// </summary>
    [Route("api/[Controller]")]
    public class MedicineController : ControllerBase
    {
        private readonly Context _context;

        public MedicineController(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all medicines
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMedicine()
        {
            return Ok(_context.medicines.ToList());
        }

        /// <summary>
        /// Create a medicine
        /// </summary>
        /// <param name="medicineData"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddMedicine([FromBody] MedicineRequest medicineData)
        {
            Medicine entity = new Medicine();
            entity.Name = medicineData.Name;
            entity.Notes = medicineData.Notes;
            entity.Price = medicineData.Price;
            entity.Quantity = medicineData.Quantity;
            entity.Brand = medicineData.Brand;
            entity.ExpiryDate = medicineData.ExpiryDate;

            _context.medicines.Add(entity);
            _context.SaveChanges();
            return StatusCode(Convert.ToInt32(HttpStatusCode.Created), medicineData);
        }

        /// <summary>
        /// Update a medicine
        /// </summary>
        /// <param name="medicineData"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateMedicine([FromBody][Required] MedicineRequest medicineData)
        {
            var entity = _context.medicines.ToList().FirstOrDefault(x => x.Id == medicineData.Id);
            if (entity != null)
            {
                entity.Name = medicineData.Name;
                entity.Notes = medicineData.Notes;
                entity.Price = medicineData.Price;
                entity.Quantity = medicineData.Quantity;
                _context.medicines.Update(entity);
                _context.SaveChanges();
                return StatusCode(Convert.ToInt32(HttpStatusCode.OK), medicineData);
            }
            return Ok("Entity Not found");
        }

        //Delete a medicine
        [HttpDelete("{id}")]
        public IActionResult DeleteMedicine(int id)
        {
            var entity = _context.medicines.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                _context.medicines.Remove(entity);
                _context.SaveChanges();
                return Ok(id);
            }
            return Ok("Entity Not found");
        }
    }
}

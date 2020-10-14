using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netCoreWebApi.Contexts;
using netCoreWebApi.Entities;

namespace netCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly DataContext _context;
        public CompaniesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            return Ok(_context.Companies.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetCompanyById(int id)
        {
            return Ok(_context.Companies.FirstOrDefault(I=>I.CompanyId==id));
        }



        [HttpPut("{id}")]
        public IActionResult UpdateCompany(int id , Company company)
        {
            var updatedCompany = _context.Companies.FirstOrDefault(I=>I.CompanyId == id);
            updatedCompany.CompanyName = company.CompanyName;
            updatedCompany.CompanyCountry = company.CompanyCountry;
            updatedCompany.CompanyCity = company.CompanyCity;
            updatedCompany.CompanyTown = company.CompanyTown;
            updatedCompany.CompanyAddress = company.CompanyAddress;
            updatedCompany.PhoneNumber = company.PhoneNumber;
            updatedCompany.LastControlDate = company.LastControlDate;
            updatedCompany.WillControl = company.WillControl;
            updatedCompany.IsOffer = company.IsOffer;
            updatedCompany.PriceOffer = company.PriceOffer;
            updatedCompany.ActiveOrNot = company.ActiveOrNot;
            updatedCompany.DebtAmount = company.DebtAmount;

            _context.SaveChanges();
            return NoContent();
        }
    
        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(int id)
        {
            var deletedCompany = _context.Companies.FirstOrDefault(I => I.CompanyId == id);
            _context.Remove(deletedCompany);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        public IActionResult AddCompany(Company company)
        {
            _context.Add(company);
            _context.SaveChanges();
            return Created("",company);
        }
    }


}
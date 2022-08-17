using System.Net;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using clMortgageBAL;
using BusinessService.Model;
using BusinessService.Authentication;

namespace clMortdageController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MortgageController : ControllerBase
    {
        private readonly IMortgageService _iMortgageService;
        public MortgageController(IMortgageService iMortgageService)
        {
            _iMortgageService = iMortgageService;
        }
        [HttpPost("addloan")]
        public async Task<IActionResult> addLoan([FromBody] LoanDetail model)
        {
            try
            {
                return Ok(await _iMortgageService.Add(model));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }
        [HttpDelete("deleteloan")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            try
            {
                await _iMortgageService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(Guid? id)
        {
            try
            {
                return Ok(await _iMortgageService.Get(id));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _iMortgageService.AllDetail());
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }
        [HttpPut("updateloan")]
        public async Task<IActionResult> UpdateLoan([FromBody] LoanDetail model)
        {
            try
            {
                return Ok(await _iMortgageService.Update(model));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
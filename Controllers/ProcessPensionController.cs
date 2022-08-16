using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessPension.Models;
using ProcessPension.Protocols;
using Newtonsoft.Json;

using ProcessPension.ResponseObject;
using Microsoft.AspNetCore.Authorization;

namespace ProcessPension.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessPensionController : ControllerBase
    {
       
        [HttpGet]
        [Route("GetByAadhar")]
        [Authorize]
        public async Task<IActionResult> GetByAadhar(double aadaharNo)
        {
            PensionApi _api = new PensionApi();
            Pension pension = new Pension();
            PensionOutput output = new PensionOutput(); ;


            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"/Pension/aadhar?aadhar={aadaharNo}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                pension = JsonConvert.DeserializeObject<Pension>(result);
                if (pension != null)
                {
                   
                    output.BankCharge = (pension.BankDetails.BankType == "private") ? 550 : 500;
                    double SelfAmount = 0.8 * (pension.Salaryearned) + pension.Allowances;
                    double FamilyAmount = 0.5 * (pension.Salaryearned) + pension.Allowances;
                    output.PensionAmount = (pension.Pensiontype == "self") ? SelfAmount : FamilyAmount;

                   
                    return Ok(output);
                }
                
            }
            return NotFound(new
            {
                StatusCode = 404,
                Message = "User Not Found"
            }
                         );
        }

    }
}

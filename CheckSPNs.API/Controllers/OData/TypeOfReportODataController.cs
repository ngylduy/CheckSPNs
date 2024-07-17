using CheckSPNs.API.Base;
using CheckSPNs.Service.EF.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace CheckSPNs.API.Controllers.OData
{


    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfReportODataController : OdataControllerBase
    {
        private readonly ITypeOfReportService _typeOfReportService;

        public TypeOfReportODataController(ITypeOfReportService typeOfReportService)
        {
            _typeOfReportService = typeOfReportService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> Get()
        {
            var result = await _typeOfReportService.GetListAsync();
            return Ok(result);
        }
    }
}

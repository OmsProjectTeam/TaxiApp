using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverInformationAPIController : ControllerBase
    {
        IIDriverInformation iDriverInfo;
        ApiResponse response;
        public DriverInformationAPIController(IIDriverInformation iDriverInfo1)
        {
            iDriverInfo = iDriverInfo1;
            response = new ApiResponse();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var allData = await iDriverInfo.GetAllAsync();
                if (allData == null)
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;

                response.Result = allData;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = new List<string> { ex.Message };
                response.IsSuccess = false;
            }

            return Ok(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var allData = await iDriverInfo.GetByIdAsync(id);
                if (allData == null)
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;

                response.Result = allData;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = new List<string> { ex.Message };
                response.IsSuccess = false;
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddData([FromBody] TBDriverInformation data)
        {
            try
            {
                if (!ModelState.IsValid)
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;

                await iDriverInfo.AddDataAsync(data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = new List<string> { ex.Message };
                response.IsSuccess = false;
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateData([FromBody] TBDriverInformation data)
        {
            try
            {
                if (!ModelState.IsValid)
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;

                await iDriverInfo.UpdateDataAsync(data);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = new List<string> { ex.Message };
                response.IsSuccess = false;
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(int id)
        {
            try
            {
                var item = await GetById(id);
                if (item == null)
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;

                await iDriverInfo.DeleteDataAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = new List<string> { ex.Message };
                response.IsSuccess = false;
            }

            return Ok(response);
        }
    }
}

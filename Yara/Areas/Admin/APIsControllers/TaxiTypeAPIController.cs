using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxiTypeAPIController : ControllerBase
    {
        IITaxiType iTaxiType;
        ApiResponse response;
        public TaxiTypeAPIController(IITaxiType iTaxiType1)
        {
            iTaxiType = iTaxiType1;
            response = new ApiResponse();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var allData = await iTaxiType.GetAllAsync();
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
                var allData = await iTaxiType.GetByIdAsync(id);
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
        public async Task<IActionResult> AddData([FromBody] TBTaxiType data)
        {
            try
            {
                if(!ModelState.IsValid)
                    response.StatusCode =System.Net.HttpStatusCode.BadRequest;

                await iTaxiType.AddDataAsync(data);
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
        public async Task<IActionResult> UpdateData([FromBody] TBTaxiType data)
        {
            try
            {
                if (!ModelState.IsValid)
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;

                await iTaxiType.UpdateDataAsync(data);
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
                if(item == null)
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;

                await iTaxiType.DeletDataAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = new List<string> { ex.Message };
                response.IsSuccess = false;
            }

            return Ok(response);
        }

        [HttpDelete("DeletePhoto/{id}")]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            try
            {
                var result = await iTaxiType.DeletePhotoAsync(id);
                if (!result)
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = new List<string> { ex.Message };
                response.IsSuccess = false;
            }

            return Ok(response);
        }

        [HttpDelete("DeletePhotoWithError/{name}")]
        public async Task<IActionResult> DeletePhotoWithError(string name)
        {
            try
            {
                var result = await iTaxiType.DeletePhotoWithErrorAsync(name);
                if (!result)
                    response.StatusCode = System.Net.HttpStatusCode.NotFound;

                response.Result = result;
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

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Yara.Areas.Admin.APIsControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrivingLicenseCategoryAPIController : ControllerBase
    {
        IIDrivingLicenseCategory iDrivingLicenseCategory;
        ApiResponse response;
        public DrivingLicenseCategoryAPIController(IIDrivingLicenseCategory iDrivingLicenseCategory1)
        {
            iDrivingLicenseCategory = iDrivingLicenseCategory1;
            response = new ApiResponse();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var allData = await iDrivingLicenseCategory.GetAllAsync();
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
                var allData = await iDrivingLicenseCategory.GetByIdAsync(id);
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
        public async Task<IActionResult> AddData([FromBody] TBDrivingLicenseCategory data)
        {
            try
            {
                if (!ModelState.IsValid)
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;

                await iDrivingLicenseCategory.AddDataAsync(data);
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
        public async Task<IActionResult> UpdateData([FromBody] TBDrivingLicenseCategory data)
        {
            try
            {
                if (!ModelState.IsValid)
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;

                await iDrivingLicenseCategory.UpdateDataAsync(data);
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

                await iDrivingLicenseCategory.DeletDataAsync(id);
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

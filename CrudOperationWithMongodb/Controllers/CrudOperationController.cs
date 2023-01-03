using CrudOperationWithMongodb.DataAccessLayer;
using CrudOperationWithMongodb.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudOperationWithMongodb.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CrudOperationController : ControllerBase
    {
        private readonly ICrudOperationDL _crudOperationDL;

        public CrudOperationController(ICrudOperationDL crudOperationDL)
        {
            _crudOperationDL = crudOperationDL;
        }
        [HttpPost]
        public async Task<IActionResult> InsertRecord( InsertRecordRequest request) 
        {
            InsertRecordresponse response = new InsertRecordresponse();

            try
            {
                response = await _crudOperationDL.InsertRecord(request);    
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message  = "exception occurs" + ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecord ()
        {
            GetAllRecordResponse response = new GetAllRecordResponse();

            try
            {
                response = await _crudOperationDL.GetAllRecord();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "exception occurs" + ex.Message;
            }

            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetRecordById([FromQuery]string Id)
        {
            GetRecordByIdResponse response = new GetRecordByIdResponse();

            try
            {
                response = await _crudOperationDL.GetRecordById(Id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "exception occurs" + ex.Message;
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRecordById(InsertRecordRequest request)
        {
            UpdateRecordIdByResponse response = new UpdateRecordIdByResponse();

            try
            {
                response = await _crudOperationDL.UpdateRecordById(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "exception occurs" + ex.Message;
            }

            return Ok(response);
        }
    }
}

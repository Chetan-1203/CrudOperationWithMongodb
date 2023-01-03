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
        public async Task<IActionResult> Insert( InsertRecordRequest request) 
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
    }
}

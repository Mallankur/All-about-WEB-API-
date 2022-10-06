using CrudOprationDB.DataacsessLayer;
using CrudOprationDB.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace CrudOprationDB.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CrudOprationController : ControllerBase
    {
        private readonly ICrudOprationDl _crudoprationdl;

        public CrudOprationController(ICrudOprationDl crudoprationdl)
        {
            _crudoprationdl = crudoprationdl;
        }
        [HttpPost]
        public async Task<IActionResult> InsertRecord(InsertRecordRequest request)
        {

            var responce = new InsertRecordResponse();
            responce.isSuucceses = true;
            try
            {
                responce = await _crudoprationdl.InsertRecord(request);

            }
            catch (Exception ex)
            {

                responce.isSuucceses = false;
                responce.Massege = "Expection occur" + ex.Message;
            }
            return Ok(responce);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRecord()
        {

            GetAllRecordResponce responce = new GetAllRecordResponce();
            responce.Issucess = true;
            try
            {
                responce = await _crudoprationdl.GetAllRecor();

            }
            catch (Exception ex)
            {

                responce.Issucess = false;
                responce.Message = "Expection occur" + ex.Message;
            }
            return Ok(responce);

        }
    }
}

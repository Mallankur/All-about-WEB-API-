using CrudOprationDB.Model;
using MongoDB.Driver;

namespace CrudOprationDB.DataacsessLayer
{
    public class CrudOprationDl : ICrudOprationDl
    {
        private readonly IConfiguration _configuration;
        private readonly MongoClient _Mongoclient;
        private readonly IMongoCollection<InsertRecordRequest> _MongoCollections;
        public CrudOprationDl(IConfiguration configuration)
        {
            _configuration = configuration;
            _Mongoclient = new MongoClient(_configuration["DatabaseSettings:ConnectionString"]);
            var _MongoDatabase = _Mongoclient.GetDatabase(_configuration["DatabaseSettings:DatabaseName"]);
            _MongoCollections = _MongoDatabase.GetCollection<InsertRecordRequest>(_configuration["DatabaseSettings:CollectionName"]);


        }

        public async  Task<InsertRecordResponse> InsertRecord(InsertRecordRequest request)
        {
              var response = new InsertRecordResponse();
            response.isSuucceses = true;
            response.Massege = "Data sussefully";

            try
            {
                request.CreateDate = DateTime.Now.ToString();
                request.UpdateDate = string.Empty;
                    await _MongoCollections.InsertOneAsync(request);

            }
            catch (Exception ex )
            {
                response.isSuucceses = false;
                response.Massege= ex.Message;

                
            }
            return response;
        }
        public async Task<GetAllRecordResponce> GetAllRecor()
        {
            GetAllRecordResponce responce = new GetAllRecordResponce();
            responce.Issucess = true;
            responce.Message = "Data fetch succesfully";
            try
            {
                responce.data = new List<InsertRecordRequest>();
                responce.data = await _MongoCollections.Find(x=>true).ToListAsync();

                if (responce.data.Count == 0) responce.Message = "No records found ";

            }
            catch (Exception ex )
            {
                responce.Issucess = false;
                responce.Message = ex.Message;  
                
            }
            return responce;
        }

    }
}

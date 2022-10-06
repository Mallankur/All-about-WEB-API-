using CrudOprationDB.Model;

namespace CrudOprationDB.DataacsessLayer
{

    public interface ICrudOprationDl
    {
        public Task<InsertRecordResponse> InsertRecord(InsertRecordRequest request);
        public Task<GetAllRecordResponce> GetAllRecor();

    }
}

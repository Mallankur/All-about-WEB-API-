namespace CrudOprationDB.Model
{
    public class GetAllRecordResponce
    {
        public bool Issucess { get; set; }
        public string Message { get; set; }

        public List<InsertRecordRequest> data { get; set; } 

    }
}

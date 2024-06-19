namespace EXAMPLE_API.Entities.Response
{
    public class Payload
    {
        public int TypeResult { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public List<Dictionary<string, object>> Data { get; set; } = new List<Dictionary<string, object>>();
    }
}

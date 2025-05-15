namespace SalesProject.Transversal.Common
{
    public class ResponseError
    {
        public ResponseError(string message) 
        {
            Message = new string[] {message};
        }
        public string[] Message { get; set; }
    }
}

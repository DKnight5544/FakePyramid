
namespace FakePyramid.Models
{
    public class ValidationMessage
    {
        public string Message { get; set; }
        public decimal RequiredAmount { get; set; }
        public decimal ActualAmount { get; set; }
        public string UserName { get; set; }
    }
}
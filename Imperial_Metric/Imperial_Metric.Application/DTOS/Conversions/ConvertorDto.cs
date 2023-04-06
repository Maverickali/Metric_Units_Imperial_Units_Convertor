namespace Imperial_Metric.WebApi.Controllers.v1
{
    public class ConvertorDto
    {
        public string FromUnit { get; set; } = null!;
        public int conversionId { get; set; } 
        public string ToUnit { get; set; } = null!;
        public double valueToConvertor { get; set; } = 0;
    }
}
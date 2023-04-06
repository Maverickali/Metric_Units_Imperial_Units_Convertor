using IdentityModel;
using Imperial_Metric.Application.DTOS.Conversions;
using Imperial_Metric.Application.Interfaces;
using Imperial_Metric.Application.Wrappers;
using Imperial_Metric.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Imperial_Metric.WebApi.Controllers.v1
{
    
    [ApiVersion("1.0")]   
    public class ConversionsController : BaseApiController
    {
        public readonly IGenericRepositoryAsync<Conversions> _conversionsRepo;
        public readonly IGenericRepositoryAsync<ConversionsRates> _conversionsRatesRepo;
        public ConversionsController(IGenericRepositoryAsync<Conversions> conversionsRepo, IGenericRepositoryAsync<ConversionsRates> conversionsRatesRepo)
        {
            _conversionsRepo = conversionsRepo;
            _conversionsRatesRepo = conversionsRatesRepo;

        }

        [HttpGet(Name = "GetConversionUnit"), Authorize]
        public async Task<Response<string>> GetConversionUnit([FromBody] ConvertorDto query)
        {
            var conversionsRates = Enumerable.Empty<ConversionsRates>();

            Response<string> response = null!;
            string valueConverted = string.Empty;
            try
            {
                conversionsRates = await _conversionsRatesRepo.GetAllAsync();
                var proccessing = conversionsRates.Where(x => x.ConversionId == query.conversionId
                && x.FromUnit == query.ToUnit).FirstOrDefault();

                if (proccessing is not null)
                {

                    valueConverted = ((query.valueToConvertor * proccessing.ConversionFactor) + proccessing.ConversionOffset).ToString();
                    response.Data = valueConverted;
                    response.Succeeded = true;
                }
            }
            catch (Exception ex)
            {

                Log.Warning(ex, "An error occurred starting the application");
                response.Errors = new List<string>() { ex.Message };

            }
            return response;
        }

        //[HttpGet(Name = "GetConversions"),Authorize]
        
        //public async Task<PagedResponse<IEnumerable<Conversions>>> Get([FromQuery] SearchFilterDto search)
        //{
        //    var conversions = Enumerable.Empty<Conversions>();
        //    try
        //    {
        //         conversions = await _conversionsRepo.GetAllAsync();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    return (PagedResponse<IEnumerable<Conversions>>)(conversions ?? Enumerable.Empty<Conversions>());
        //}

   
        


    }
}

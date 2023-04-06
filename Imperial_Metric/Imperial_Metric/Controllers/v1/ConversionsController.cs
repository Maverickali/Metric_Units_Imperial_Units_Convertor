using IdentityModel;
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
        [HttpGet(Name = "GetConversions")]
        public async Task<PagedResponse<IEnumerable<Conversions>>> Get()
        {
            var conversions = Enumerable.Empty<Conversions>();
            try
            {
                 conversions = await _conversionsRepo.GetAllAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return (PagedResponse<IEnumerable<Conversions>>)(conversions ?? Enumerable.Empty<Conversions>());
        }

        [HttpGet(Name = "Convertor")]
        public async Task<string> Converting ([FromBody] ConvertorDto query)
        {
            var conversionsRates= Enumerable.Empty<ConversionsRates>();
            string valueConverted = string.Empty;
            try
            {
                conversionsRates = await _conversionsRatesRepo.GetAllAsync();
                var proccessing = conversionsRates.Where(x => x.ConversionId == query.conversionId
                && x.FromUnit == query.ToUnit).FirstOrDefault();

                if (proccessing is not null) {
                    
                    valueConverted = ((query.valueToConvertor * proccessing.ConversionFactor) + proccessing.ConversionOffset).ToString();
                }
            }
            catch (Exception ex)
            {

                Log.Warning(ex, "An error occurred starting the application");

            }
            return valueConverted??string.Empty;
        }


    }
}

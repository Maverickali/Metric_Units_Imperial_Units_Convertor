using IdentityModel;
using Imperial_Metric.Application.Interfaces;
using Imperial_Metric.Application.Wrappers;
using Imperial_Metric.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Imperial_Metric.WebApi.Controllers.v1
{
    
    [ApiVersion("1.0")]   
    public class ConversionsController : BaseApiController
    {
        public readonly IGenericRepositoryAsync<Conversions> _conversionsRepo;
        public ConversionsController(IGenericRepositoryAsync<Conversions> conversionsRepo)
        {
            _conversionsRepo = conversionsRepo;
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
    }
}

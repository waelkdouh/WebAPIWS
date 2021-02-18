using Microsoft.AspNetCore.Mvc;
using MyShuttle.Data;
using MyShuttle.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace MyShuttle.API
{

    [NoCacheFilter]
	[ApiController]
    [Route("[controller]")]
    public class AnalyticsController : ControllerBase
    {
        private const int DefaultCarrierID = 0;

        IDriverRepository _driverRepository;

        IVehicleRepository _vehicleRepository;
        ICarrierRepository _carrierRepository;
        IRidesRepository _ridesRepository;

        public AnalyticsController(IDriverRepository driverRepository
            , IVehicleRepository vehicleRepository, ICarrierRepository carrierRepository, IRidesRepository ridesRepository)
        {
            _driverRepository = driverRepository;

            _vehicleRepository = vehicleRepository;
            _carrierRepository = carrierRepository;
            _ridesRepository = ridesRepository;
        }

     
             
        [HttpGet("summary")]
        public async Task<SummaryAnalyticInfo> GetSummaryInfo()
        {
            return await _carrierRepository.GetAnalyticSummaryInfoAsync(DefaultCarrierID);
        }

        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyShuttle.Data;
using MyShuttle.Model;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShuttle.API
{
	[ApiController]
    [Route("[controller]")]
    [NoCacheFilter]
    public class DriversController : ControllerBase
    {

        IDriverRepository _driverRepository;
        private const int DefaultCarrierID = 0;

        public DriversController(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        [HttpGet("Count/{filter?}")]
        public async Task<int> GetCount(string filter)
        
        {
            if (string.IsNullOrEmpty(filter))
                filter = string.Empty;

            return await _driverRepository.GetCountAsync(DefaultCarrierID, filter);
        }

        [HttpPost]
        public async Task<int> Post([FromBody]Driver driver)
        {
            driver.CarrierId = DefaultCarrierID;
            return await _driverRepository.AddAsync(driver);
        }

        [HttpPut]
        public async Task Put([FromBody]Driver driver)
        {
            driver.CarrierId = DefaultCarrierID;
            await _driverRepository.UpdateAsync(driver);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _driverRepository.DeleteAsync(id);
        }

    }
}

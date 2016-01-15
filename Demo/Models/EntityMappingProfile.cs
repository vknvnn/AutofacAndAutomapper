using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Demo.Services;

namespace Demo.Models
{
    internal class EntityMappingProfile : Profile
    {
        private readonly ICustomerService  _customerService;
        public EntityMappingProfile(ICustomerService  customerService)
        {
            _customerService = customerService;
        }
        protected override void Configure()
        {
            base.Configure();
            this.CreateMap<CustomerModel, Customer>().AfterMap((s, d) =>
            {
                d.Name = _customerService.GetNameRandom();
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Services
{
    public interface ICustomerService
    {
        string GetNameRandom();
    }
    public class CustomerService : ICustomerService
    {
        public string GetNameRandom()
        {
            return "Khang Vo";
        }
    }
}

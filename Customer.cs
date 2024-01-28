using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    internal class Customer
    {
        private String customerId;
        private String name;

        public Customer(String customerId, String name)
        {
            this.customerId = customerId;
            this.name = name;
        }

        public String getCustomerId()
        {
            return customerId;
        }

        public String getName()
        {
            return name;
        }
    }
}

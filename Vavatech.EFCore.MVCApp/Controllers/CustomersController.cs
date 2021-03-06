using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vavatech.EFCore.IRepositories;

namespace Vavatech.EFCore.MVCApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            var customers = customerRepository.Get();


            return View(customers);
        }

        public IActionResult Index([FromServices] IOrderRepository orderRepository, int customerId)
        {
            var customer = customerRepository.Get(customerId);

            var orders = orderRepository.GetByCustomer(customer.Id);

            return View(customer);
        }
    }
}

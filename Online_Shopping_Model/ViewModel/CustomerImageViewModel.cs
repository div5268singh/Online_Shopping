using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shopping_Model.ViewModel
{
    public class CustomerImageViewModel : CustomerViewModel
    {
        public IFormFile PhotoPath { get; set; }
    }
}

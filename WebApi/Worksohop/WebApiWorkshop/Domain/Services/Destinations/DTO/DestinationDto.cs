using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Destinations.DTO
{
    public class DestinationDto
    {
        public string? Name { get; set; }
        public string? City { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}

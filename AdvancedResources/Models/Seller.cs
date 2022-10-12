﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AdvancedResources.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
    }
}
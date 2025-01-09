﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetPay.DataProcessor.ImportDtos
{
    [XmlType("Household")]
    public class HouseholdImportDto
    {
        
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        [XmlElement("ContactPerson")]
        public string ContactPerson { get; set; }

        [MinLength(6)]
        [MaxLength(80)]
        [XmlElement("Email")]
        public string Email { get; set; }

        [Required]
        [MinLength(15)]
        [MaxLength(15)]
        [RegularExpression(@"^\+\d{3}/\d{3}-\d{6}$")]
        [XmlAttribute("phone")]
        public string PhoneNumber { get; set; }
    }
}

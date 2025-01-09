﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetPay.DataProcessor.ExportDtos
{
    [XmlType("Household")]
    public class HouseholdExportDto
    {        
        [XmlElement("ContactPerson")]
        public string ContactPerson { get; set; }

        [XmlElement("Email")]
        public string Email { get; set; }
                
        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [XmlArray("Expenses")]
        public ExpenseExportDto[] Expenses { get; set; }
    }
}

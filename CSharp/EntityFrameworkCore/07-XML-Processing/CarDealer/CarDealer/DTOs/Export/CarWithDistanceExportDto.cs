﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
    [XmlType("car")]
    public class CarWithDistanceExportDto
    {
        [XmlElement("make")]
        public string Make {  get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("traveled-distance")]
        public long TraveledDistance { get; set; }
    }
}

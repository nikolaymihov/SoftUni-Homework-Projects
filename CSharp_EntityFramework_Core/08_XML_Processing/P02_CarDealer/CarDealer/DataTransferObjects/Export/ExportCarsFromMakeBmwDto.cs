﻿using System.Xml.Serialization;

namespace CarDealer.DataTransferObjects.Export
{
    [XmlType("car")]
    public class ExportCarsFromMakeBmwDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}

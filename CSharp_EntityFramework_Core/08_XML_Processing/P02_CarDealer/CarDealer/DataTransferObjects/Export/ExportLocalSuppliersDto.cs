﻿using System.Xml.Serialization;

namespace CarDealer.DataTransferObjects.Export
{
    [XmlType("supplier")]
    public class ExportLocalSuppliersDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("parts-count")]
        public int PartsCount { get; set; }
    }
}

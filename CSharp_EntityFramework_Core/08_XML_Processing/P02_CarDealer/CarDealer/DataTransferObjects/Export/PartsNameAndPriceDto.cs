using System.Xml.Serialization;

namespace CarDealer.DataTransferObjects.Export
{
    [XmlType("part")]
    public class PartsNameAndPriceDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}

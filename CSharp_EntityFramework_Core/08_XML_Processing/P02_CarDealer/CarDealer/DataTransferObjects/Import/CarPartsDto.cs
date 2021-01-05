using System.Xml.Serialization;

namespace CarDealer.DataTransferObjects.Import
{
    [XmlType("partId")]
    public class CarPartsDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}

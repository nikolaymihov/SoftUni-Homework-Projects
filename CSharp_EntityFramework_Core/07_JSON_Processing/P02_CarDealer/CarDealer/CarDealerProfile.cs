using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<Customer, CustomersDTO>()
                .ForMember(x => x.BirthDate, y => y.MapFrom(c => c.BirthDate.ToString("dd-mm-yyyy")));

            this.CreateMap<Car, CarsFromMakeDTO>();
        }
    }
}

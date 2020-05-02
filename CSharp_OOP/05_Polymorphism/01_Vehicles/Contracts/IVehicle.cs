namespace Vehicles
{
    public interface IVehicle
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        void Drive(double kilometers);

        void Refuel(double fuelAmmount);
    }
}

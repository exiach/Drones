using System;
using System.Collections.Generic;

namespace Drones
{
    class Program
    {
        static void Main(string[] args)
        {
            DeliveryService deliveryService = new DeliveryService();
            deliveryService.AddDrone(new Drone()
            {
                name = "B1",
                weight = 50
            });
            deliveryService.AddDrone(new Drone()
            {
                name = "B2",
                weight = 60
            });
            deliveryService.AddLocation(new Location()
            {
                name = "Palas I",
                weight = 80
            });
            deliveryService.AddLocation(new Location()
            {
                name = "Palas II",
                weight = 20
            });
            deliveryService.AddLocation(new Location()
            {
                name = "Palas III",
                weight = 30
            });
            deliveryService.AddLocation(new Location()
            {
                name = "Palas IV",
                weight = 50
            });
            deliveryService.DeliveryPackages();
            deliveryService.PrinttripRecord();
            Console.WriteLine("Hello World!");
            
        }
    }
}

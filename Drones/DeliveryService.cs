using System;
using System.Collections.Generic;
using System.Linq;

public class DeliveryService
{
	public List<Drone> drones;
	public List<Location> locations;
	public List<TripRecord> tripsRecord;
	public DeliveryService()
	{
		drones = new List<Drone>();
		locations = new List<Location>();
		tripsRecord = new List<TripRecord>();
	}

	public void AddDrone(Drone drone)
	{
		if (drones.Count <= 100)
        {
			drones.Add(drone);
        }
	}

	public void AddLocation(Location location)
    {
		locations.Add(location);
    }

	public void DeliveryPackages()
    {
		drones = drones.OrderByDescending(x => x.weight).ToList();
		locations = locations.OrderBy(x => x.weight).ToList();
		foreach(var drone in drones)
		{
			var aux = drone.weight;
			var locationNames = new List<string>();
			foreach(var location in locations)
            {
				if (aux >= location.weight) 
				{
					aux -= location.weight;
					location.weight = 0;
					locationNames.Add(location.name);
				}
				else
                {
					location.weight -= aux;
					locationNames.Add(location.name);
					break;
                }
            }
			locations = locations.FindAll(x => x.weight > 0).ToList();
			RegisterTrip(drone.name, locationNames);
		}
		if (locations.Count > 0)
        {
			DeliveryPackages();
        }
	}

	public void PrinttripRecord()
	{
		foreach(var tripRecord in tripsRecord)
        {
			Console.WriteLine(tripRecord.name);
			for(var i = 0; i < tripRecord.trips.Count; i++)
            {
				Console.WriteLine($"Trip # {i + 1}");
				Console.WriteLine(string.Join(", ", tripRecord.trips[i]));
			}
        }
	}
	private void RegisterTrip(string name, List<string> trips)
    {
		var tripRecord = tripsRecord.FirstOrDefault(x => x.name == name);
		if (tripRecord != null)
		{
			tripRecord.trips.Add(trips);
		}
		else
		{
			tripsRecord.Add(new TripRecord()
			{
				name = name,
				trips = new List<List<string>>() { trips }
			});
		}
    }
}

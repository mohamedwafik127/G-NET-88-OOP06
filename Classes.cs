using System;
using System.Collections.Generic;
using System.Text;

public class DeliveryAddress
{
    string City;
    string Street;
    int BuildingNumber;

    public string City_
    {
        get => City;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                City = value;
            }
            else
            {
                Console.WriteLine("City cannot be null or empty.");
            }
        }
    }

    public string Street_
    {
        get => Street;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                Street = value;
            }
            else
            {
                Console.WriteLine("Street cannot be null or empty.");
            }
        }
    }
    public int BuildingNumber_
    {
        get => BuildingNumber;
        set
        {
            if (value > 0)
            {
                BuildingNumber = value;
            }
            else
            {
                Console.WriteLine("Building number must be a positive integer.");
            }
            ;
        }
    }

    public DeliveryAddress(string street, string city, int buildingNumber)
    {
        Street = street;
        City = city;
        BuildingNumber = buildingNumber;
    }

    public override string ToString()
    {
        return $" {BuildingNumber} {Street}, {City}";
    }
}

public partial class Shipment
{
    protected string Description;
    protected double Weight;
    protected string TrackingCode;
    protected decimal DeliveryFee;
    protected DeliveryAddress Destination;
    protected static int TotalShipmentsCreated;

    public Shipment()
    {
        this.Description = "Unknown";
        this.Weight = 1;
        this.DeliveryFee = 50;
        this.TrackingCode = "";
    }

    static Shipment()
    {
        TotalShipmentsCreated = 0;
        Console.WriteLine("Shipment System Initialized");
    }
    public Shipment(string description, double weight, string trackingCode, decimal deliveryFee, DeliveryAddress destination)
    {
        Description = description;
        Weight = weight;
        TrackingCode = trackingCode;
        DeliveryFee = deliveryFee;
        this.Destination = destination;
        TotalShipmentsCreated++;
    }

    public Shipment(string trackingCode) : this("Unknown", 1, trackingCode, 50, new DeliveryAddress("Unknown", "Unknown", 0))
    {
        TotalShipmentsCreated++;
    }

    public string description
    {
        get => Description;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                Description = value;
            }
            else
            {
                Console.WriteLine("Description cannot be null or empty.");
            }

        }
    }

    public double weight
    {
        get => Weight;
        set
        {
            if (value > 0)
            {
                Weight = value;
            }
            else
            {
                Console.WriteLine("Weight must be greater than zero.");
            }
        }
    }

    public string Tracking_Code
    {
        get => TrackingCode;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                TrackingCode = value;
            }
            else
            {
                Console.WriteLine("Tracking code cannot be null or empty.");
            }

        }
    }

    public decimal deliveryFee
    {
        get => DeliveryFee;
        set
        {
            if (value > 0)
            {
                DeliveryFee = value;
            }
            else
            {
                Console.WriteLine("Delivery fee must be greater than zero.");
            }
        }
    }

    public DeliveryAddress destination
    {
        get => Destination;
        set => Destination = value;
    }

    public static void GetTotalShipmentsCreated()
    {
        Console.WriteLine($"Total Shipments Created: {TotalShipmentsCreated}");
    }

    public virtual decimal EstimatedCost()
    {
        return DeliveryFee + (decimal)(Weight * 5);
    }

    public virtual void PrintShipment()
    {
        Console.WriteLine($"Tracking Code: {Tracking_Code}");
        Console.WriteLine($"Description: {description}");
        Console.WriteLine($"Weight: {weight}");
        Console.WriteLine($"Delivery Fee: {deliveryFee}");
        Console.WriteLine($"Destination: {destination}");
    }

    public void UpdateDeliveryFee(decimal newFee)
    {
        if (newFee > 0)
        {
            DeliveryFee = newFee;
        }
        else
        {
            Console.WriteLine("Delivery fee must be greater than zero.");
        }

    }

    public void UpdateWeight(double newWeight)
    {
        if (newWeight > 0)
        {
            Weight = newWeight;
        }
        else
        {
            Console.WriteLine("Weight must be greater than zero.");
        }
    }

    public void UpdateWeight(double newWeight, double extraPackingWeight)
    {
        if (extraPackingWeight < 0)
        {
            Console.WriteLine("Extra packing weight cannot be negative.");
            return;
        }

        double totalWeight = newWeight + extraPackingWeight;

        if (totalWeight > 0)
        {
            Weight = totalWeight;
        }
        else
        {
            Console.WriteLine("Weight must be greater than zero.");
        }
    }

    public partial void OnTrackingStatusChanged(string newStatus)
    {
        Console.WriteLine($"Tracking status changed to: {newStatus}");
    }

    public Shipment CopyShipment()
    {
        return new Shipment
        {
            Tracking_Code = this.Tracking_Code,
            description = this.description,
            weight = this.weight,
            deliveryFee = this.deliveryFee,
            destination = this.destination
        };
    }

    public Shipment ShallowCopy()
    {
        return (Shipment)this.MemberwiseClone();
    }

    public Shipment DeepCopy()
    {
        return new Shipment
        {
            Tracking_Code = this.Tracking_Code,
            description = this.description,
            weight = this.weight,
            deliveryFee = this.deliveryFee,
            destination = new DeliveryAddress(this.destination.City_, this.destination.Street_, this.destination.BuildingNumber_)
        };
    }


    public virtual decimal CalculateInsurance()
    {
        return EstimatedCost() * 5 / 100;
    }

}

public class DeliveryCenter
{
    private Shipment[] shipments;

    public DeliveryCenter()
    {
        shipments = new Shipment[20];
    }

    public Shipment this[int index]
    {
        get
        {
            if (index < shipments.Length && index >= 0)
            {
                return shipments[index];
            }
            else
            {
                return default;
            }
        }

        set
        {
            if (index < shipments.Length && index >= 0)
            {
                shipments[index] = value;
            }
        }
    }

    public Shipment this[string trackingCode]
    {
        get
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] != null && shipments[i].Tracking_Code == trackingCode)
                {
                    return shipments[i];
                }
            }

            return default;
        }
    }

    public string driver { get; set; }

    public bool AddShipment(Shipment shipment)
    {
        for (int i = 0; i < shipments.Length; i++)
        {
            if (shipments[i] == null)
            {
                shipments[i] = shipment;

                return true;
            }
        }
        return false;
    }

    public bool RemoveShipment(string tracingCode)
    {
        for (int i = 0; i < shipments.Length; i++)
        {
            if (shipments[i].Tracking_Code == tracingCode)
            {
                shipments[i] = null;

                return true;
            }
        }
        return false;
    }

    public void PrintAllShipments()
    {

        for (int i = 0; i < shipments.Length; i++)
        {
            if (shipments[i] != null)
            {
                shipments[i].PrintShipment();
                Console.WriteLine("-------------------------------------------------------");
            }
        }
    }

    public void PrintTrackingStatuses()
    {
        foreach (ITrackable T in shipments)
        {
            if (T != null)
            {
                Console.WriteLine(T.GetTrackingStatus());
            }

        }
    }

    public void PrintInsurance()
    {
        foreach (IInsurable T in shipments)
        {
            if (T != null)
            {
                Console.WriteLine($"{T.GetType().Name} Insurance : {T.CalculateInsurance()} EGP");
            }
        }
    }

}

public class StandardShipment : Shipment, ITrackable, IInsurable
{
    public StandardShipment(string description, double weight, string trackingCode, decimal deliveryFee, DeliveryAddress destination) : base(description, weight, trackingCode, deliveryFee, destination)
    {
        TrackingStatus = "In Transit";
        Console.WriteLine("Standard Shipment Created.");
    }

    public override decimal EstimatedCost()
    {
        return DeliveryFee + (decimal)(Weight * 5);
    }

    public override void PrintShipment()
    {
        Console.WriteLine($"Tracking Code: {TrackingCode}\nDescription: {Description}\nWeight: {Weight} KG \nDelivery Fee: {DeliveryFee} EGP\nDestination: {Destination}\nEstimated Cost: {EstimatedCost()} EGP");
    }

    public override string GetTrackingStatus()
    {
        return TrackingStatus;
    }

    public override decimal CalculateInsurance()
    {
        return EstimatedCost() * 5 / 100;
    }
}

public class ExpressShipment : Shipment, IInsurable,ITrackable
{
    private decimal extraFee;
    public ExpressShipment(string description, double weight, string trackingCode, decimal deliveryFee, DeliveryAddress destination, decimal extraFee) : base(description, weight, trackingCode, deliveryFee, destination)
    {
        ExtraFee = extraFee;
        TrackingStatus = "is Out for Delivery.";
        Console.WriteLine("Express Shipment Created.");
    }

    public decimal ExtraFee
    {
        get => extraFee;

        set
        {
            if (value >= 0)
            {
                extraFee = value;
            }
            else
            {
                Console.WriteLine("ExtraFee must be greater than or equal to zero.");
            }
        }
    }

    public override decimal EstimatedCost()
    {
        return DeliveryFee + (decimal)(Weight * 5) + ExtraFee;
    }

    public override string GetTrackingStatus()
    {
        return TrackingStatus;
    }

    public override void PrintShipment()
    {
        Console.WriteLine($"Tracking Code: {TrackingCode}\nDescription: {Description}\nWeight: {Weight} KG \nDelivery Fee: {DeliveryFee} EGP\nDestination: {Destination}\nExtra Fee : {ExtraFee} EGP\nEstimated Cost: {EstimatedCost()} EGP");
    }

    public override decimal CalculateInsurance()
    {
        return EstimatedCost() * 8 / 100;
    }
}

public class InternationalShipment : Shipment, ITrackable, IInsurable
{
    private decimal customsFee;
    private string destinationCountry;

    public InternationalShipment(string description, double weight, string trackingCode, decimal deliveryFee, DeliveryAddress destination, string destinationCountry, decimal customsFee) : base(description, weight, trackingCode, deliveryFee, destination)
    {
        DestinationCountry = destinationCountry;
        CustomsFee = customsFee;
        TrackingStatus = "Delivered.";
        Console.WriteLine("International Shipment Created.");
    }

    public string DestinationCountry
    {
        get => destinationCountry;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                destinationCountry = value;
            }
            else
            {
                Console.WriteLine("Destination country cannot be null or empty.");
            }
        }
    }

    public decimal CustomsFee
    {
        get => customsFee;
        set
        {
            if (value >= 0)
            {
                customsFee = value;
            }
            else
            {
                Console.WriteLine("Customs fee must be greater than or equal to zero.");
            }
        }
    }

    public override decimal EstimatedCost()
    {
        return DeliveryFee + (decimal)(Weight * 5) + CustomsFee;
    }

    public override void PrintShipment()
    {
        Console.WriteLine($"Tracking Code: {TrackingCode}\nDescription: {Description}\nWeight: {Weight} KG \nDelivery Fee: {DeliveryFee} EGP\nDestination: {DestinationCountry}\nCustoms Fee : {CustomsFee} EGP\nEstimated Cost: {EstimatedCost()} EGP");
    }

    public virtual void GenerateCustomsReport()
    {
        Console.WriteLine($"Customs Report - Tracking Code: {TrackingCode}, Destination Country: {DestinationCountry}, Customs Fee: {CustomsFee} EGP");
    }

    public override string GetTrackingStatus()
    {
        return TrackingStatus;
    }

    public override decimal CalculateInsurance()
    {
        return EstimatedCost() * 12 / 100;
    }
}

public class DeliveryHelper
{
    public static void PrintShipmentDetails(Shipment shipment)
    {
        shipment.PrintShipment();
    }
}

public sealed class CompletedShipment : Shipment
{
    public CompletedShipment() : base()
    {
    }

    public override decimal EstimatedCost()
    {
        return DeliveryFee + (decimal)(Weight * 5);
    }

    public override void PrintShipment()
    {
        Console.WriteLine($"Tracking Code: {TrackingCode}\nDescription: {Description}\nWeight: {Weight} KG \nDelivery Fee: {DeliveryFee} EGP\nDestination: {Destination}\nEstimated Cost: {EstimatedCost} EGP");
    }
}

public class DeliveryReport
{
    public void PrintShipment(ITrackable shipment)
    {
        Console.WriteLine(shipment.GetTrackingStatus());
    }

    public void PrintInsurance(IInsurable shipment)
    {
        Console.WriteLine($"Insurance Cost: {shipment.CalculateInsurance()} EGP");
    }
}

public static class DeliveryUtilities
{
    public static void PrintSeparator()
    {
        Console.WriteLine("==========================================");
    }

    public static void PrintSystemTitle()
    {
        PrintSeparator();
        Console.WriteLine("Delivery Center");
        PrintSeparator();
    }
}

public static class ShipmentExtensions
{
    public static string GetSummary(this Shipment shipment)
    {
        return $"{shipment.Tracking_Code} | {shipment.GetType().Name} | {shipment.weight} KG | {shipment.GetTrackingStatus()}";
    }

    public static bool IsDelivered(this Shipment shipment)
    {
        if (shipment.GetTrackingStatus() == "Delivered.") return true;
        return false;
    }
}
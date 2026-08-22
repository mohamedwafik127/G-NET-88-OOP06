using System;
using System.Collections.Generic;
using System.Text;


public interface ITrackable
{
    public string GetTrackingStatus();
}

public interface IInsurable
{
    public decimal CalculateInsurance();
}


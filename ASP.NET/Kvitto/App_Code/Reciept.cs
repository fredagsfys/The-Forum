using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Reciept
/// </summary>
public class Reciept
{
    private double _subtotal;

    public double DiscountRate {  get; private set; }
    public double MoneyOff { get; private set; }

    public double Subtotal
    {
        get
        {
            return _subtotal;
        }
        private set
        {
            if (Subtotal <= 0.0)
            {
                throw new ArgumentOutOfRangeException("Fel inträffade, värdet är mindre än 0");
            }
            else
            {
                _subtotal = value;
            }
        }
    }
    public double Total { get; private set; }


    public void Calculate(double subtotal) 
    {
        
        Subtotal = subtotal;

        Reciept discount = new Reciept(0);

        if (subtotal > 0.0 || subtotal < 499)
        {
            discount.DiscountRate = 0;
        }
        else if (subtotal > 500 || subtotal < 999)
        {
            discount.DiscountRate = 5;
        }
        else if (subtotal > 1000 || subtotal < 4999)
        {
            discount.DiscountRate = 10;
        }
        else if (subtotal > 5000)
        {
            discount.DiscountRate = 15;
        }


    }

    public Reciept(double subtotal) 
    {
        Calculate(subtotal);
    }
}
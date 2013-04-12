using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

/// <summary>
/// Summary description for Person
/// </summary>
[DataObject(false)]
[Serializable]
public class Person : BusinessObjectBase
{
    #region Fält

    private string _firstName;
    private string _lastName;
    private string _addressf;
    private string _postalCode;
    private string _city;
    private string _loginSTR;

    #endregion

    #region Egenskaper

    public int PersonID { get; set; }

    public string FirstName
    {
        get
        {
            return this._firstName;
        }
        set
        {
            // Tar bort eventuella fel
            this.ValidationErrors.Remove("FirstName");

            // Lägger till ett felmeddelande om value är null eller whitespace
            if (String.IsNullOrWhiteSpace(value))
            {
                this.ValidationErrors.Add("FirstName", "Förnamn får inte vara tomt");
            }

            // Lägger till ett felmeddelande om value är längre än 15 tecken
            else if (value.Length > 15)
            {
                this.ValidationErrors.Add("FirstName", "Förnamn får inte vara längre än 15 tecken");
            }
            // Sätter firstName till ett trimmat värde om det inte är null
            this._firstName = value != null ? value.Trim() : null;
        }
    }

    public string LastName
    {
        get
        {
            return this._lastName;
        }
        set
        {
            // Tar bort eventuella fel
            this.ValidationErrors.Remove("LastName");

            // Lägger till ett felmeddelande om value är null eller whitespace
            if (String.IsNullOrWhiteSpace(value))
            {
                this.ValidationErrors.Add("LastName", "Efternamn får inte vara tomt");
            }

            // Lägger till ett felmeddelande om value är längre än 30 tecken
            else if (value.Length > 30)
            {
                this.ValidationErrors.Add("LastName", "Efternamn får inte vara längre än 30 tecken");
            }
            // Sätter lastName till ett trimmat värde om det inte är null
            this._lastName = value != null ? value.Trim() : null;
        }
    }

    public string AddressF
    {
        get
        {
            return this._addressf;
        }
        set
        {
            // Tar bort eventuella fel
            this.ValidationErrors.Remove("Address");

            // Lägger till ett felmeddelande om value är null eller whitespace
            if (String.IsNullOrWhiteSpace(value))
            {
                this.ValidationErrors.Add("AddressF", "Adress får inte vara tomt");
            }

            // Lägger till ett felmeddelande om value är längre än 30 tecken
            else if (value.Length > 30)
            {
                this.ValidationErrors.Add("AddressF", "Adress får inte vara längre än 30 tecken");
            }
            // Sätter addressf till ett trimmat värde om det inte är null
            this._addressf = value != null ? value.Trim() : null;
        }
    }

    public string PostalCode
    {
        get
        {
            return this._postalCode;
        }
        set
        {
            // Tar bort eventuella fel
            this.ValidationErrors.Remove("PostalCode");

            // Lägger till ett felmeddelande om value är null eller whitespace
            if (String.IsNullOrWhiteSpace(value))
            {
                this.ValidationErrors.Add("PostalCode", "Postnr får inte vara tomt");
            }

            // Lägger till ett felmeddelande om value är längre än 6 tecken
            else if (value.Length > 6)
            {
                this.ValidationErrors.Add("PostalCode", "Postnr får inte vara längre än 6 tecken");
            }
            // Sätter postalcode till ett trimmat värde om det inte är null
            this._postalCode = value != null ? value.Trim() : null;
        }
    }

    public string City
    {
        get
        {
            return this._city;
        }
        set
        {
            
            this.ValidationErrors.Remove("City");

            // Lägger till ett felmeddelande om value är null eller whitespace
            if (String.IsNullOrWhiteSpace(value))
            {
                this.ValidationErrors.Add("City", "Ort får inte vara tomt");
            }

            // Lägger till ett felmeddelande om value är längre än 25 tecken
            else if (value.Length > 25)
            {
                this.ValidationErrors.Add("City", "Ort får inte vara längre än 25 tecken");
            }
            // Sätter city till ett trimmat värde om det inte är null
            this._city = value != null ? value.Trim() : null;
        }
    }

    public string LoginSTR
    {
        get
        {
            return this._loginSTR;
        }
        set
        {
            // Tar bort eventuella fel
            this.ValidationErrors.Remove("LoginSTR");

            // Lägger till ett felmeddelande om value är null eller whitespace
            if (String.IsNullOrWhiteSpace(value))
            {
                this.ValidationErrors.Add("LoginSTR", "Användarnamn får inte vara tomt.");
            }
            // Lägger till ett felmeddelande om value är längre än 20 tecken
            else if (value.Length > 20)
            {
                this.ValidationErrors.Add("LoginSTR", "Användarnamn får inte vara längre än 20 tecken");
            }
            // Sätter loginSTR till ett trimmat värde om det inte är null
            this._loginSTR = value != null ? value.Trim() : null;
        }
    }
    #endregion

    #region Metoder

    public Person()
	{
        this.FirstName = null;
        this.LastName = null;
        this.AddressF = null;
        this.PostalCode = null;
        this.City = null;
        this.LoginSTR = null;
	}

    public Person(string firstName, string lastName, string addressf, string postalCode, string city, string loginSTR)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.AddressF = addressf;
        this.PostalCode = postalCode;
        this.City = city;
        this.LoginSTR = loginSTR;
    }

    public Person(int personID, string firstName, string lastName, string addressf, string postalCode, string city)
    {
        this.PersonID = personID;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.AddressF = addressf;
        this.PostalCode = postalCode;
        this.City = city;
    }

    #endregion
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.Configuration;

/// <summary>
/// Summary description for BusinessObjectBase
/// </summary>
public class BusinessObjectBase : IDataErrorInfo
{
#region
    private Dictionary<string, string> _validationErrors;
    protected string CommonErrorMessage;

    public string Error
    {
        get
        {
            // Kontrollerar om det finns några fel och i så fall returneras en allmän 
            // felbeskrivning; finns det inga fel så returneras ingen sträng alls!
            return !this.IsValid ? "Objektets tillstånd är ogiltigt." : null;
        }
    }
    public bool IsValid
    {
        // Finns det inga fel är Dictionary-objektet tomt.
        get { return this.ValidationErrors.Count == 0; }
    }
    public string this[string propertyName]
    {
        get
        {
            // Försöker hitta ett fel för angiven egenskap och...
            string error;
            if (this.ValidationErrors.TryGetValue(propertyName, out error))
            {
                // ...finns det ett fel så returneras felmeddelandet...
                return error;
            }
            // ...annars returneras ingen sträng.
            return null;
        }
    }
    protected Dictionary<string, string> ValidationErrors
    {
        get
        {
            // Bara då _validationErrors refererar till null skapas ett nytt objekt
            return this._validationErrors ?? (this._validationErrors = new Dictionary<string, string>());
        }
    }
#endregion
#region
    //public BusinessObjectBase()
    //    : this("Objektets status är inte giltigt.")
    //{
    //    // Tom.
    //}
#endregion
#region
    //public BusinessObjectBase(string commonErrorMessage)
    //{
    //    this.CommonErrorMessage = commonErrorMessage;
    //}
#endregion
}
    
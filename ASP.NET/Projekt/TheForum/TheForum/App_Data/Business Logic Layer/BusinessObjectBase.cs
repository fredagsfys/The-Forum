using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

/// <summary>
/// Summary description for BusinessObjectBase
/// </summary>
[DataObject(false)]
public abstract class BusinessObjectBase : IDataErrorInfo
{
    #region Fält

    private Dictionary<string, string> _validationErrors;
    protected string CommonErrorMessage;

    #endregion

    #region Egenskaper

    public string Error
    {
        get
        {
            // Kontrollerar om det finns några fel och...
            if (!this.IsValid)
            {
                // ...i så fall returneras en allmän felbeskrivning.
                return this.CommonErrorMessage;
            }
            // Finns det inga fel så returneras ingen sträng alls!
            return null;
        }
    }

    public bool IsValid
    {
        get { return !this.ValidationErrors.Any(); }
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
            return this._validationErrors ?? (this._validationErrors = new Dictionary<string, string>());
        }
    }

    #endregion

    #region Metoder

    public BusinessObjectBase() : this("Inte giltigt") { }
    // Initierar konstrukorn som tar ett commonErrorMessage med 'Inte giltigt' i fall default anropas
    public BusinessObjectBase(string commonErrorMessage)
    {
        this.CommonErrorMessage = commonErrorMessage;
    }

    #endregion
}
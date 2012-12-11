using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Contact
/// </summary>
public class Contact : BusinessObjectBase
{
    #region
    private string _firstName;
    private string _lastName;
    private string _emailAdress;
    
    #endregion
    public Contact()
	{
        this.FirstName = null;
        this.LastName = null;
        this.EmailAdress = null;
	}
    public int ContactId  { get; set; }

    public string FirstName
    {
        get { return this._firstName; }
        set
        {
            // Antar att värdet är korrekt.
            this.ValidationErrors.Remove("Firstname");

            // Undersöker om värdet är korrekt beträffande om strängen är null
            // eller tom för i så fall...
            if (String.IsNullOrWhiteSpace(value))
            {
                // ...är det ett fel varför nyckel Name (namnet på egenskapen)
                // mappas mot ett felmeddelande.
                this.ValidationErrors.Add("Firstname", "A name must be written.");
            }
            else if (value.Length > 50)
            {
                // Om strängen innehåller fler än 30 tecken kan inte det fullständiga 
                // datat inte sparas i databastabellen vilket är att betrakta som ett fel.
                this.ValidationErrors.Add("Firstname", "The name can't exceed 50 letters in length");
            }

            // Tilldelar fältet värdet, oavsett om det är ett korrekt värde 
            // enligt affärsreglerna eller inte.
            this._firstName = value != null ? value.Trim() : null;
        }
    }
    public string LastName
    {
        get { return this._lastName; }
        set
        {
            // Antar att värdet är korrekt.
            this.ValidationErrors.Remove("Lastname");

            // Undersöker om värdet är korrekt beträffande om strängen är null
            // eller tom för i så fall...
            if (String.IsNullOrWhiteSpace(value))
            {
                // ...är det ett fel varför nyckel Name (namnet på egenskapen)
                // mappas mot ett felmeddelande.
                this.ValidationErrors.Add("Lastname", "A lastname must be written.");
            }
            else if (value.Length > 50)
            {
                // Om strängen innehåller fler än 30 tecken kan inte det fullständiga 
                // datat inte sparas i databastabellen vilket är att betrakta som ett fel.
                this.ValidationErrors.Add("Lastname", "The lastname can't exceed 50 letters in length.");
            }

            // Tilldelar fältet värdet, oavsett om det är ett korrekt värde 
            // enligt affärsreglerna eller inte.
            this._lastName = value != null ? value.Trim() : null;
        }
    }
    public string EmailAdress
    {
        get { return this._emailAdress; }
        set
        {
            // Antar att värdet är korrekt.
            this.ValidationErrors.Remove("Emailadress");

            // Undersöker om värdet är korrekt beträffande om strängen är null
            // eller tom för i så fall...
            if (String.IsNullOrWhiteSpace(value))
            {
                // ...är det ett fel varför nyckel Name (namnet på egenskapen)
                // mappas mot ett felmeddelande.
                this.ValidationErrors.Add("Emailadress", "A emailadress must be written.");
            }
            else if (value.Length > 50)
            {
                // Om strängen innehåller fler än 30 tecken kan inte det fullständiga 
                // datat inte sparas i databastabellen vilket är att betrakta som ett fel.
                this.ValidationErrors.Add("Emailadress", "The Emailadress can't exceed 50 letters in length.");
            }

            // Tilldelar fältet värdet, oavsett om det är ett korrekt värde 
            // enligt affärsreglerna eller inte.
            this._emailAdress = value != null ? value.Trim() : null;
        }
    }

}
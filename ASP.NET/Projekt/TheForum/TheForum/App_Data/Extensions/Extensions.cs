using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Reflection;

/// <summary>
/// Summary description for Extensions
/// </summary>
[DataObject(false)]
public static class Extensions
{
    #region Validering

    // Skapar en CustomValidator innehållande ett satt felmeddelande samt validationgroup som sedan läggs till på sidans validators
    public static void AddErrorMessage(this Page page, string message, string validationGroup = null)
    {
        var validator = new CustomValidator
        {
            IsValid = false,
            ErrorMessage = message,
            ValidationGroup = validationGroup
        };

        page.Validators.Add(validator);
    }

    // Tar hjälp utav IDataErrorInfo för att hämta ut felmeddelande som är bundna till Egenskapers namn via Directory och lägger var och en till sidans validators
    public static void AddErrorMessage(this Page page, IDataErrorInfo obj, string validationGroup = null)
    {
        obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => !String.IsNullOrWhiteSpace(obj[p.Name]))
            .Select(p => p.Name)
            .ToList()
            .ForEach(propertyName => Extensions.AddErrorMessage(page, obj[propertyName], validationGroup));
    }

    #endregion
}
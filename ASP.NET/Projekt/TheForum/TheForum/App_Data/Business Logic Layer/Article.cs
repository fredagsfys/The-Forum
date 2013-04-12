using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for Article
/// </summary>
[Serializable]
public class Article : BusinessObjectBase
{
    #region Fält

    private string _name;
    private string _articleContent;

    #endregion

    #region Egenskaper

    public int PersonID { get; set; }
    public int ArticleID { get; set; }
    public DateTime Created { get; set; }
    public string Cbool { get; set; }
    public string Author { get; set; }

    public string Name
    {
        get { return this._name; }
        set
        {
            // Tar bort eventuella fel
            this.ValidationErrors.Remove("Name");

            // Lägger till ett felmeddelande om value är null eller whitespace
            if (String.IsNullOrWhiteSpace(value))
            {
                this.ValidationErrors.Add("Name", "Du måste ange namn på artikeln");
            }
            // Lägger till ett felmeddelande om value är längre än 50 tecken
            else if (value.Length > 50)
            {
                this.ValidationErrors.Add("Name", "Artikelns namn får inte vara längre än 50 tecken");
            }
            // Sätter name till ett trimmat värde om det inte null
            this._name = value != null ? value.Trim() : null;
        }
    }

    public string ArticleContent
    {
        get { return this._articleContent; }
        set
        {
            // Tar bort eventuella fel
            this.ValidationErrors.Remove("ArticleContent");

            // Lägger till ett felmeddelande om value är null eller whitespace
            if (String.IsNullOrWhiteSpace(value))
            {
                this.ValidationErrors.Add("ArticleContent", "Artikeln måste ha innehåll");
            }
            
            // Lägger till ett felmeddelande om value längre än 4000 tecken
            else if (value.Length > 4000)
            {
                this.ValidationErrors.Add("ArticleContent", "Artikelns innehåll får inte vara längre än 4000 tecken");
            }
            // Sätter articleContent till ett trimmat värde om det inte är null
            this._articleContent = value != null ? value.Trim() : null;
        }
    }
    

    #endregion

    public Article()
	{
        this.Name = null;
        this.ArticleContent = null;
        this.Created = new DateTime();
        this.Cbool = null;
	}
    public Article(string name, DateTime created, string articleContent, string cbool)
    {
        this.Name = name;
        this.ArticleContent = articleContent;
        this.Created = created;
        this.Cbool = cbool;
    }
    public Article(int articleID, string name, DateTime created, string articleContent, string cbool)
    {
        this.ArticleID = articleID;
        this.Name = name;
        this.ArticleContent = articleContent;
        this.Created = created;
        this.Cbool = cbool;
    }
}
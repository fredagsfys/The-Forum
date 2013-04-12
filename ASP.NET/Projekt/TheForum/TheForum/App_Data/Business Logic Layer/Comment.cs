using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Comment
/// </summary>
[Serializable]
public class Comment : BusinessObjectBase
{
    #region Fält

    private string _commentContent;

    #endregion

    #region Egenskaper

    public int CommentID { get; set; }
    public int ArticleID { get; set; }
    public int PersonID { get; set; }
    public DateTime CommentDate { get; set; }
    public string Name { get; set; }


    public string CommentContent
    {
        get { return this._commentContent; }
        set
        {
            // Tar bort eventuella fel
            this.ValidationErrors.Remove("CommentContent");

            // Lägger till ett felmeddelande om value är null eller whitespace
            if (String.IsNullOrWhiteSpace(value))
            {
                this.ValidationErrors.Add("CommentContent", "Kommentar får inte vara tom");
            }

            // Lägger till ett felmeddelande om value är längre än 350 tecken
            else if (value.Length > 350)
            {
                this.ValidationErrors.Add("CommentContent", "Kommentarer får inte vara längre än 350 tecken");
            }
            // Sätter commentContent till ett trimmat värde om det inte är null
            this._commentContent = value != null ? value.Trim() : null;
        }
    }

    #endregion

    public Comment()
	{
        this.CommentContent = null;
        this.CommentDate = new DateTime();
	}
    public Comment(string commentContent, DateTime commentDate)
    {
        this.CommentContent = commentContent;
        this.CommentDate = commentDate;
    }
}
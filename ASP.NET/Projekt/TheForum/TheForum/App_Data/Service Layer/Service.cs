using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

/// <summary>
/// Summary description for Service
/// </summary>
[DataObject(true)]
public class Service
{
    #region Fält

    private ArticleDAL _articleDAL;
    private CommentDAL _commentDAL;
    private PersonDAL _personDAL;

    #endregion

    #region Egenskaper

    public ArticleDAL ArticleDAL
    {
        // Skapar och retunerar ett ArticleDAL objekt när det behövs för första gången
        get { return this._articleDAL ?? (this._articleDAL = new ArticleDAL()); }
    }

    public CommentDAL CommentDAL
    {
        // Skapar och retunerar ett CommentDAL objekt när det behövs för första gången
        get { return this._commentDAL ?? (this._commentDAL = new CommentDAL()); }
    }

    public PersonDAL PersonDAL
    {
        // Skapar och retunerar ett PersonDAL objekt när det behövs för första gången
        get { return this._personDAL ?? (this._personDAL = new PersonDAL()); }
    }

    #endregion

    #region Metoder

    public List<Article> GetArticles()
    {
        return ArticleDAL.GetArticles();
    }

    public Article GetArticle(int articleID)
    {
        return ArticleDAL.GetArticle(articleID);
    }

    public void UpdateArticle(Article article)
    {
        if (article.IsValid)
        {
            ArticleDAL.UpdateArticle(article);
        }
        else
        {
            throw new ApplicationException("Error in service");
        }
    }

    public int AddArticle(Article article)
    {
        if (article.IsValid)
        {
            return ArticleDAL.AddArticle(article);
        }
        else
        {
            throw new ApplicationException("Error in service");
        }
    }

    public void DeleteArticle(Article article)
    {
        ArticleDAL.DeleteArticle(article.ArticleID);
    }

    public List<Comment> GetComments(int articleID)
    {
        return CommentDAL.GetComments(articleID);
    }

    public int AddComment(Comment comment)
    {
        if (comment.IsValid)
        {
            return CommentDAL.AddComment(comment);
        }
        else
        {
            throw new ApplicationException("Error in service");
        }
    }

    public void DeleteComment(Comment comment)
    {
        CommentDAL.DeleteComment(comment.CommentID);
    }

    public void UpdateComment(Comment comment)
    {
        if (comment.IsValid)
        {
            CommentDAL.UpdateComment(comment);
        }
        else
        {
            throw new ApplicationException("Error in service");
        }
    }

    public Person GetPerson(Person person)
    {
        return PersonDAL.GetPerson(person.PersonID);
    }

    public Person GetPersonByLogin(string loginSTR)
    {
        return PersonDAL.GetPersonByLogin(loginSTR);
    }

    public int AddPerson(Person person)
    {
        if (person.IsValid)
        {
            return PersonDAL.AddPerson(person);
        }
        else
        {
            throw new ApplicationException("Error in service");
        }
    }

    public void AddLoginToPerson(int personID, string loginSTR)
    {
        var person = PersonDAL.GetPerson(personID);

        if (person.IsValid)
        {
            PersonDAL.AddLoginToPerson(personID, loginSTR);
        }
        else
        {
            throw new ApplicationException("Error in service");
        }
    }

    #endregion
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

/// <summary>
/// Hanterar alla CRUD metoder gällande Article klassen
/// </summary>
public class ArticleDAL : DALBase
{
    #region Metoder
    // Metod för att lägga till en artikel
    public int AddArticle(Article article)
    {
        using (var conn = CreateConnection())
        {
            // Skapar en anslutning och ett SqlCommand objekt och använder sig utav den lagrade proceduren
            // usp_AddArticle med relevanta parametrar och får tillbaka ett ID som används
            try
            {
                var cmd = new SqlCommand("app.usp_AddArticle", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@PersonID", SqlDbType.Int, 4).Value = article.PersonID;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = article.Name;
                cmd.Parameters.Add("@Created", SqlDbType.DateTime, 10).Value = article.Created;
                cmd.Parameters.Add("@ArticleContent", SqlDbType.VarChar, 4000).Value = article.ArticleContent;
                cmd.Parameters.Add("@Cbool", SqlDbType.VarChar, 5).Value = article.Cbool;

                cmd.Parameters.Add("@ArticleID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                conn.Open();

                cmd.ExecuteNonQuery();

                article.ArticleID = (int)cmd.Parameters["@ArticleID"].Value;

                return article.ArticleID;

            }
            catch
            {
                throw new ApplicationException("Error in DAL");
            }
        }
    }
    // Metod för att ta bort en artikel
    public void DeleteArticle(int articleID)
    {
        // Skapar en anslutning och ett SqlCommand objekt som använder sig utav den lagrade proceduren
        // usp_RemoveArticle för att ta bort artikeln med det articleID som ID
        using (var conn = CreateConnection())
        {
            try
            {
                var cmd = new SqlCommand("app.usp_RemoveArticle", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ArticleID", SqlDbType.Int, 4).Value = articleID;

                conn.Open();

                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw new ApplicationException("Error in DAL");
            }
        }
    }
    // Metod för att hämta alla artiklar
    public List<Article> GetArticles()
    {
        // Skapar ett list objekt som vars kapacitet sätts till 100, skapar ett SqlCommand objekt
        // Kör en reader som tar reda på index för att de olika kolumnerna och sedan skapar ett Article objekt med de relevanta värdena
        // Article objekten i sin tur läggs till i List objektet som retuneras när Read() retunerar null
        var articles = new List<Article>(100);

        using (var conn = CreateConnection())
        {
            try
            {
                var cmd = new SqlCommand("app.usp_GetArticles", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    var articleIDIndex = reader.GetOrdinal("ArticleID");
                    var nameIndex = reader.GetOrdinal("Name");
                    var createdIndex = reader.GetOrdinal("Created");
                    var articleContentIndex = reader.GetOrdinal("ArticleContent");
                    var cboolIndex = reader.GetOrdinal("Cbool");
                    var authorIndex = reader.GetOrdinal("Author");

                    while (reader.Read())
                    {
                        articles.Add(new Article 
                        {
                            ArticleID = reader.GetInt32(articleIDIndex),
                            Name = reader.GetString(nameIndex),
                            Created = reader.GetDateTime(createdIndex),
                            ArticleContent = reader.GetString(articleContentIndex),
                            Cbool = reader.GetString(cboolIndex),
                            Author = reader.GetString(authorIndex)
                        });
                    }
                }

                articles.TrimExcess();

                return articles;
            }
            catch
            {
                throw new ApplicationException("Error in DAL");
            }
        }
    }
    // Metod för att hämta en specifik artikel
    public Article GetArticle(int articleID)
    {
        // Skapar en anslutning och ett SqlCommand objekt som använder sig utav den lagrande proceduren
        // usp_GetArticle för hämta de olika egenskaperna som behövs och fyller dessa i ett Article objekt
        // som skapas, sedan retuneras det
        var article = new Article();

        using (var conn = CreateConnection())
        {
            try
            {
                var cmd = new SqlCommand("app.usp_GetArticle", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("ArticleID", SqlDbType.Int, 4).Value = articleID;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    var articleIDIndex = reader.GetOrdinal("ArticleID");
                    var nameIndex = reader.GetOrdinal("Name");
                    var createdIndex = reader.GetOrdinal("Created");
                    var articleContentIndex = reader.GetOrdinal("ArticleContent");
                    var cboolIndex = reader.GetOrdinal("Cbool");
                    var authorIndex = reader.GetOrdinal("Author");

                    while (reader.Read())
                    {
                        article.ArticleID = reader.GetInt32(articleIDIndex);
                        article.Name = reader.GetString(nameIndex);
                        article.Created = reader.GetDateTime(createdIndex);
                        article.ArticleContent = reader.GetString(articleContentIndex);
                        article.Cbool = reader.GetString(cboolIndex);
                        article.Author = reader.GetString(authorIndex);
                    }
                }

                return article;
            }
            catch
            {
                throw new ApplicationException("Error in DAL");
            }
        }
    }
    // Metod för att uppdatera en artikel
    public void UpdateArticle(Article article)
    {
        // Skapar en anslutning och ett SqlCommand objekt som använder sig utav den lagrande proceduren
        // usp_AlterArticle med relevanta parametrar för att ändra artikeln med article.ArticleID
        using (var conn = CreateConnection())
        {
            try
            {
                var cmd = new SqlCommand("app.usp_UpdateArticle", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ArticleID", SqlDbType.Int, 4).Value = article.ArticleID;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = article.Name;
                cmd.Parameters.Add("@Created", SqlDbType.Date, 10).Value = DateTime.Now;
                cmd.Parameters.Add("@ArticleContent", SqlDbType.VarChar, 4000).Value = article.ArticleContent;
                cmd.Parameters.Add("@Cbool", SqlDbType.VarChar, 5).Value = article.Cbool;

                conn.Open();

                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw new ApplicationException("Error in DAL");
            }
        }
    }

    #endregion
}
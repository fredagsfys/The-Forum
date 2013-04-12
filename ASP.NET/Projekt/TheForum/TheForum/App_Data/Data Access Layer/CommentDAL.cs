using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Hanterar alla CRUD metoder gällande Comment klassen
/// </summary>
public class CommentDAL : DALBase
{
    #region Metoder
    // Metod för att hämta alla kommentar på en specifik artikel
    public List<Comment> GetComments(int articleID)
    {
        // Skapar ett list objekt som vars kapacitet sätts till 100, skapar ett SqlCommand objekt
        // Kör en reader som tar reda på index för att de olika kolumnerna och sedan skapar Comment objekt med de relevanta värdena
        // Comment objekten i sin tur läggs till i List objektet som retuneras när Read() retunerar null
        var comments = new List<Comment>(100);

        using (var conn = CreateConnection())
        {
            try
            {
                var cmd = new SqlCommand("app.usp_GetComments", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ArticleID", SqlDbType.Int, 4).Value = articleID;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    var commentIDIndex = reader.GetOrdinal("CommentID");
                    var articleIDIndex = reader.GetOrdinal("ArticleID");
                    var personIDIndex = reader.GetOrdinal("PersonID");
                    var commentDateIndex = reader.GetOrdinal("CommentDate");
                    var commentContentIndex = reader.GetOrdinal("CommentContent");
                    var nameIndex = reader.GetOrdinal("Name");

                    while (reader.Read())
                    {
                        comments.Add(new Comment
                        {
                            CommentID = reader.GetInt32(commentIDIndex),
                            ArticleID = reader.GetInt32(articleIDIndex),
                            PersonID = reader.GetInt32(personIDIndex),
                            CommentDate = reader.GetDateTime(commentDateIndex),
                            CommentContent = reader.GetString(commentContentIndex),
                            Name = reader.GetString(nameIndex)
                        });
                    }
                }

                comments.TrimExcess();

                return comments;
            }
            catch
            {
                throw new ApplicationException("Error in DAL");
            }
        }
    }
    // Metod för att lägga till en kommentar
    public int AddComment(Comment comment)
    {
        using (var conn = CreateConnection())
        {
            try
            {
                // Skapar ett SqlCommand objekt och använder sig av den lagrande proceduren usp_AddComment
                // Och med lämpliga parmetrar lägger till kommentaren på gällande artikel
                var cmd = new SqlCommand("app.usp_AddComment", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ArticleID", SqlDbType.Int, 4).Value = comment.ArticleID;
                cmd.Parameters.Add("@PersonID", SqlDbType.Int, 4).Value = comment.PersonID;
                cmd.Parameters.Add("@CommentDate", SqlDbType.SmallDateTime, 20).Value = comment.CommentDate;
                cmd.Parameters.Add("@CommentContent", SqlDbType.VarChar, 350).Value = comment.CommentContent;

                cmd.Parameters.Add("@CommentID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                conn.Open();

                cmd.ExecuteNonQuery();

                comment.CommentID = (int)cmd.Parameters["@CommentID"].Value;

                return comment.CommentID;

            }
            catch
            {
                throw new ApplicationException("Error in DAL");
            }
        }
    }
    // Metod för att ta bort en kommentar
    public void DeleteComment(int commentID)
    {
        // Skapar en anslutning, ett SqlCommand objekt och med hjälp av parametern CommentID tar bort rätt kommentar
        using (var conn = CreateConnection())
        {
            try
            {
                var cmd = new SqlCommand("app.usp_RemoveComment", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CommentID", SqlDbType.Int, 4).Value = commentID;

                conn.Open();

                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw new ApplicationException("Error in DAL");
            }
        }
    }
    // Metod för att uppdatera en kommentar
    public void UpdateComment(Comment comment)
    {
        // Skapar en anslutning, ett SqlCommand objekt och alla relevanta parametrar läggs till i SqlCommand objektets Parameter lista
        // Proceduren körs och uppgifterna ändras på det CommentID som angivits om det uppfyller kraven i databasen
        using (var conn = CreateConnection())
        {
            try
            {
                var cmd = new SqlCommand("app.usp_UpdateComment", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CommentID", SqlDbType.Int, 4).Value = comment.CommentID;
                cmd.Parameters.Add("@CommentDate", SqlDbType.SmallDateTime, 20).Value = comment.CommentDate;
                cmd.Parameters.Add("@CommentContent", SqlDbType.VarChar, 350).Value = comment.CommentContent;

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
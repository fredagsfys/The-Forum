using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.ComponentModel;

/// <summary>
/// Summary description for DALBase
/// </summary>
[DataObject(false)]
public abstract class DALBase
{
    #region Fält

    private static string _connectionString;

    #endregion

    #region Metoder

    protected static SqlConnection CreateConnection()
    {
        // Skapar ett SQL anslutningsobjekt med hjälp av fältet _connectionString
        return new SqlConnection(_connectionString);
    }

    static DALBase()
    {
        // Använder sig utav fältet _connectionString och tilldelar detta en ConnectionString ifrån web.config filen
        _connectionString = WebConfigurationManager.ConnectionStrings["ArticleConnectionString"].ConnectionString;
    }

    #endregion
}
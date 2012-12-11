using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

/// <summary>
/// Summary description for DALBase
/// </summary>
public abstract class DALBase
{
    private static string _connectionString;

    protected SqlConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
	static DALBase()
	{
        _connectionString = WebConfigurationManager.ConnectionStrings["ApplicationServiceConnectionString"].ConnectionString;
	}
}
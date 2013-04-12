using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for PersonDAL
/// </summary>
public class PersonDAL : DALBase
{
    #region Metoder

    public int AddPerson(Person person)
    {
        using (var conn = CreateConnection())
        {
            // Skapar en anslutning och ett SqlCommand objekt och använder sig utav den lagrade proceduren
            // usp_AddPerson med relevanta parametrar och får tillbaka ett ID som används
            try
            {
                var cmd = new SqlCommand("app.usp_AddPerson", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 15).Value = person.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 30).Value = person.LastName;
                cmd.Parameters.Add("@AddressF", SqlDbType.VarChar, 30).Value = person.AddressF;
                cmd.Parameters.Add("@PostalCode", SqlDbType.VarChar, 6).Value = person.PostalCode;
                cmd.Parameters.Add("@City", SqlDbType.VarChar, 25).Value = person.City;

                cmd.Parameters.Add("@PersonID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                conn.Open();

                cmd.ExecuteNonQuery();

                person.PersonID = (int)cmd.Parameters["@PersonID"].Value;

                return person.PersonID;

            }
            catch
            {
                throw new ApplicationException("Error in DAL");
            }
        }
    }

    public Person GetPerson(int personID)
    {
        // Skapar en anslutning och ett SqlCommand objekt som använder sig utav den lagrande proceduren
        // usp_GetPerson för hämta de olika egenskaperna som behövs och fyller dessa i ett Person objekt
        // som skapas, sedan retuneras det
        var person = new Person();

        using (var conn = CreateConnection())
        {
            try
            {
                var cmd = new SqlCommand("app.usp_GetPerson", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@PersonID", SqlDbType.Int, 4).Value = personID;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    var personIDIndex = reader.GetOrdinal("PersonID");
                    var firstNameIndex = reader.GetOrdinal("FirstName");
                    var lastNameIndex = reader.GetOrdinal("LastName");
                    var addressfIndex = reader.GetOrdinal("AddressF");
                    var postalCodeIndex = reader.GetOrdinal("PostalCode");
                    var cityIndex = reader.GetOrdinal("City");
                    var loginSTRIndex = reader.GetOrdinal("LoginSTR");

                    while (reader.Read())
                    {
                        person.PersonID = reader.GetInt32(personIDIndex);
                        person.FirstName = reader.GetString(firstNameIndex);
                        person.LastName = reader.GetString(lastNameIndex);
                        person.AddressF = reader.GetString(addressfIndex);
                        person.PostalCode = reader.GetString(postalCodeIndex);
                        person.City = reader.GetString(cityIndex);
                        person.LoginSTR = reader.GetString(loginSTRIndex);
                    }
                }

                return person;
            }
            catch
            {
                throw new ApplicationException("Error in DAL");
            }
        }
    }

    public Person GetPersonByLogin(string loginSTR)
    {
        // Skapar en anslutning och ett SqlCommand objekt som använder sig utav den lagrande proceduren
        // usp_GetPersonByLogin för hämta de olika egenskaperna som behövs och fyller dessa i ett Person objekt
        // som skapas, sedan retuneras det
        var person = new Person();

        using (var conn = CreateConnection())
        {
            try
            {
                var cmd = new SqlCommand("app.usp_GetPersonByLogin", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@LoginSTR", SqlDbType.VarChar, 20).Value = loginSTR;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    var personIDIndex = reader.GetOrdinal("PersonID");
                    var firstNameIndex = reader.GetOrdinal("FirstName");
                    var lastNameIndex = reader.GetOrdinal("LastName");
                    var addressfIndex = reader.GetOrdinal("AddressF");
                    var postalCodeIndex = reader.GetOrdinal("PostalCode");
                    var cityIndex = reader.GetOrdinal("City");
                    var loginSTRIndex = reader.GetOrdinal("LoginSTR");

                    while (reader.Read())
                    {
                        person.PersonID = reader.GetInt32(personIDIndex);
                        person.FirstName = reader.GetString(firstNameIndex);
                        person.LastName = reader.GetString(lastNameIndex);
                        person.AddressF = reader.GetString(addressfIndex);
                        person.PostalCode = reader.GetString(postalCodeIndex);
                        person.City = reader.GetString(cityIndex);
                        person.LoginSTR = reader.GetString(loginSTRIndex);
                    }
                }

                return person;
            }
            catch
            {
                throw new ApplicationException("Error in DAL");
            }
        }
    }

    public void AddLoginToPerson(int personID, string loginSTR)
    {
        using (var conn = CreateConnection())
        {
            // Skapar en anslutning och ett SqlCommand objekt och använder sig utav den lagrade proceduren
            // usp_AddLoginToPerson med relevanta parametrar
            try
            {
                var cmd = new SqlCommand("app.usp_AddLoginToPerson", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@PersonID", SqlDbType.Int, 4).Value = personID;
                cmd.Parameters.Add("@LoginSTR", SqlDbType.VarChar, 30).Value = loginSTR;

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
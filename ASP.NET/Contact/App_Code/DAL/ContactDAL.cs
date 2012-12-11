using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

/// <summary>
/// Summary description for ContactDAL
/// </summary>
public class ContactDAL : DALBase
{
    public void DeleteContact(int contactId)
    {
        using (SqlConnection conn = CreateConnection())
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Person.uspRemoveContact", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ContactId", SqlDbType.Int, 4).Value = contactId;

                conn.Open();

                cmd.ExecuteNonQuery();
            }
            catch
            {
                // Kastar ett eget undantag om ett undantag kastas.
                throw new ApplicationException("An error occured in the data access layer.");
            }
        }
    }
    public Contact GetContactById(int contactId)
    {
        using (SqlConnection conn = CreateConnection())
        {
            try
            {

                SqlCommand cmd = new SqlCommand("Person.uspGetContact", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int ContactIdIndex = reader.GetOrdinal("ContactId");

                        return new Contact
                        {
                            ContactId = reader.GetInt32(ContactIdIndex)
                        };
                    }
                }
                return null;
            }
            catch
            {
                // Kastar ett eget undantag om ett undantag kastas.
                throw new ApplicationException("An error occured in the data access layer.");
            }
        }
    }
    public List<Contact> GetContacts()
    {
        using (var conn = CreateConnection())
        {
            try
            {
                var contacts = new List<Contact>(100);

                var cmd = new SqlCommand("Person.uspGetContacts", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    var FirstNameIndex = reader.GetOrdinal("FirstName");
                    var LastNameIndex = reader.GetOrdinal("LastName");
                    var EmailAdressIndex = reader.GetOrdinal("EmailAddress");
                    var ContactIdIndex = reader.GetOrdinal("ContactId");


                    while (reader.Read())
                    {
                        contacts.Add(new Contact
                        {
                            FirstName = reader.GetString(FirstNameIndex),
                            LastName = reader.GetString(LastNameIndex),
                            EmailAdress = reader.GetString(EmailAdressIndex),
                            ContactId = reader.GetInt32(ContactIdIndex)
                        });
                    }
                }

                contacts.TrimExcess();

                return contacts;
            }
            catch
            {
                throw new ApplicationException("An error occured in the data access layer.");
            }
        }
    }
    public void InsertContact(Contact contact)
    {
        // Skapar och initierar ett anslutningsobjekt.
        using (SqlConnection conn = CreateConnection())
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Person.uspAddContact", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = contact.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = contact.LastName;
                cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = contact.EmailAdress;


                cmd.Parameters.Add("@ContactId", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                conn.Open();

                cmd.ExecuteNonQuery();

                contact.ContactId = (int)cmd.Parameters["@ContactId"].Value;
            }
            catch
            {
                // Kastar ett eget undantag om ett undantag kastas.
                throw new ApplicationException("An error occured in the data access layer.");
            }
        }
    }
    public void UpdateContact(Contact contact)
    {
        using (SqlConnection conn = CreateConnection())
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Person.uspUpdateContact", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = contact.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = contact.LastName;
                cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = contact.EmailAdress;

                cmd.Parameters.Add("@ContactId", SqlDbType.Int, 4).Value = contact.ContactId;

                conn.Open();

                cmd.ExecuteNonQuery();
            }
            catch
            {
                // Kastar ett eget undantag om ett undantag kastas.
                throw new ApplicationException("An error occured in the data access layer.");
            }
        }
    }
}
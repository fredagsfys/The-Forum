using System.Collections.Generic;
using System.ComponentModel;
using System;

/// <summary>
/// Summary description for Service
/// </summary>
[DataObject(true)]
public class Service
{
    private ContactDAL _contactDAL;
    ContactDAL ContactDAL
    {
        get
        {
            return this._contactDAL ?? (this._contactDAL = new ContactDAL());
        }
    }
    public void DeleteContact(Contact contact)
    {
        ContactDAL.DeleteContact(contact.ContactId);
    }
    public Contact GetContact(int contactId)
    {
        return ContactDAL.GetContactById(contactId);
    }
    public List<Contact> GetContacts()
    {
        return ContactDAL.GetContacts();
    }
    public void SaveContact(Contact contact)
    {
        if (contact.IsValid)
        {
            if (contact.ContactId == 0)
            {
                ContactDAL.InsertContact(contact);
            }
            else
            {
                ContactDAL.UpdateContact(contact);
            }
        }
        else
        {
            ApplicationException ex = new ApplicationException(contact.Error);
            ex.Data.Add("Contact", contact);
            throw ex;
        }
    }
}
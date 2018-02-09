using System;
using System.Collections.Generic;

namespace AddressBook.Models
{
  public class Contact
  {
    public static List<Contact> _instances = new List<Contact>();
    
    private int _id;
    private string _name;
    private string _number;
    private Address _address;
    
    public Contact(string name, string number, Address address)
    {
      _name = name;
      _number = number;
      _address = address;
      
      save();
    }
    
    public int GetId()
    {
      return _id;
    }
    
    public string GetName()
    {
      return _name;
    }
    
    public string GetNumber()
    {
      return _number;
    }
    
    public Address GetAddress()
    {
      return _address;
    }
    
    public bool Contains(string searchString)
    {
      return _name.ToLower().Contains(searchString) || _number.ToLower().Contains(searchString) || _address.Contains(searchString);
    }
    
    private void save()
    {
      int idx = 0;
      while (idx < _instances.Count && String.Compare(_instances[idx]._name, _name, true) < 1)
      {
        idx++;
      }
      _instances.Insert(idx, this);
      
      for (int i = 0; i < _instances.Count; i++)
      {
        _instances[i]._id = i;
      }
    }
    
    public static List<Contact> Search(string searchString)
    {
      searchString = searchString.ToLower();
      List<Contact> results = new List<Contact>();
      foreach(Contact contact in _instances)
      {
        if (contact.Contains(searchString))
        {
          results.Add(contact);
        }
      }
      return results;
    }
    
    public static List<Contact> GetAll()
    {
      return _instances;
    }
    
    public static Contact Find(int idx)
    {
      return _instances[idx];
    }
    
    public static void Remove(int idx)
    {
      _instances.RemoveAt(idx);
      for (int i = 0; i < _instances.Count; i++)
      {
        _instances[i]._id = i;
      }
    }
    
    public static void Clear()
    {
      _instances.Clear();
    }
  }
}
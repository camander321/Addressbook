using System;

namespace AddressBook.Models
{
  public class Address
  {
    
    private string _address;
    private string _city;
    private string _state;
    private string _zip;
    
    public Address(string address, string city, string state, string zip)
    {
      _address = address;
      _city = city;
      _state = state;
      _zip = zip;
    }
    
    public bool Contains(string searchstring)
    {
      return _address.Contains(searchstring) || _city.Contains(searchstring) || _state.Contains(searchstring) || _zip.Contains(searchstring);
    }
  }
}
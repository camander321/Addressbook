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
    
    public string GetAddress()
    {
      return _address;
    }
    
    public string GetCity()
    {
      return _city;
    }
    
    public string GetState()
    {
      return _state;
    }
    
    public string GetZip()
    {
      return _zip;
    }
    
    public bool Contains(string searchstring)
    {
      return _address.ToLower().Contains(searchstring) || _city.ToLower().Contains(searchstring) || _state.ToLower().Contains(searchstring) || _zip.ToLower().Contains(searchstring);
    }
  }
}
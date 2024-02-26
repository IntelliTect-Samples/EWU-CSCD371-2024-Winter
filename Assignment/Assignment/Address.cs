namespace Assignment;

public class Address : IAddress
{
    public Address(string streetAddress, string city, string state, string zip)
    {
        StreetAddress = streetAddress;
        City = city;
        State = state;
        Zip = zip;
    }
    public void Deconstruct(out string StreetAddress, out string City, out string State, out string Zip)
    {
        StreetAddress = this.StreetAddress;
        City = this.City;
        State = this.State;
        Zip = this.Zip;
    }
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
}

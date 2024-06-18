using DocumentArchive.Domain.Common;

namespace DocumentArchive.Domain.CustomerAggregator
{
    public class Address : ValueObject<Address>
    {
        public string Street { get; set; }
        public string City { get; set; }
        //public string State { get; set; }
        public string PostalCode { get; set; }
        public override IEnumerable<object> GetEqualityComponents()
        {
          
            yield return City;
            yield return Street;
            yield return PostalCode;
        }


        public static Address Create( string city, string street, string postalCode)
        {
            return new Address
            {
                City = city,
          
                Street = street,
                PostalCode = postalCode
            };
        }


        public override string ToString()
        {
            return $"{Street}, {City},  {PostalCode}";
        }
    }
}

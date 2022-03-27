using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyLog.Domain
{

    public interface IAddress
    {
        int Id { get; set; }
        public Guid Guid { get; set; }
        string StreetNumber { get; set; }
        string Street { get; set; }
        string Suburb { get; set; }
        string Postcode { get; set; }
        string Country { get; set; }
        int EntityRelationId { get; set; }
    }

    public class Address : IAddress
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public int EntityRelationId { get; set; }

    }
}

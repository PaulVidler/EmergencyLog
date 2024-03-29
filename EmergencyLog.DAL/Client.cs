﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyLog.DAL
{
    public class Client : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string ImageSmall { get; set; }
        public string ImageLarge { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public EmergencyContact EmergencyContact { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace RealmApp3
{
    public class Company : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string WorkerCount { get; set; }
    }
}

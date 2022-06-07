using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRUD2._0
{
    public class Clients
    {
            public Int64 Id { get; set;  }
            public string Name { get; set; }
            public string LastName { get; set; }
            public string Treatment{ get; set; }
            public string Phone { get; set;  }

        public Clients () { }

        public Clients(Int64 pId , string pName , string pLastName , string pTreatment, string pPhone)
        {
            this.Id = pId;
            this.Name = pName;
            this.LastName = pLastName;
            this.Treatment = pTreatment;
            this.Phone = pPhone;
        }     
    }
}

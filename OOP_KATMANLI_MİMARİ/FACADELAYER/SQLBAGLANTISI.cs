using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FACADELAYER
{
    public class SQLBAGLANTISI
    {
        public static SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-2JVKJTR\SQLEXPRESS;Initial Catalog=DBTESTKATMAN;Integrated Security=True");
    }
}

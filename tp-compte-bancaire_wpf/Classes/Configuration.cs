using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_compte_bancaire_wpf.Classes
{
    public class Configuration
    {
        public static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\coursSql;Integrated Security=True");
    }
}

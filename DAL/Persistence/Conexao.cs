﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL.Persistence
{
   public class Conexao
    {
       protected SqlConnection Con;
       protected SqlCommand Cmd;
       protected SqlDataReader Dr;

       protected void OpenConnection()
       {
           Con = new SqlConnection(ConfigurationManager.ConnectionStrings["Banco"].ConnectionString);
           Con.Open();
       }
       protected void CloseConnection()
       {
           Con.Close();
       }

    }
}

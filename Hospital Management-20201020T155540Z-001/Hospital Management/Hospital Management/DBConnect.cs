﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Hospital_Management_System
{
    public class DBConnect
    {

        public static bool connectiontest;
        public static MySqlConnection connectToDb()
        {

            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=hospital_management;username='root';password=";
            cnn = new MySqlConnection(connetionString);
            try
            {
                cnn.Open();

                return cnn;
            }
            catch (Exception)
            {
                return null;
            }

        }


    }
}

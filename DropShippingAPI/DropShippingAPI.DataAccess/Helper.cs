using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DropShippingAPI.DataAccess
{
    public static class Helper
    {
        public static int GetColumnOrder(MySqlDataReader reader,string name)
        {
            int columnOrdinal = reader.GetOrdinal(name);
            return columnOrdinal;
        }
        public static T GetValue<T>(this MySqlDataReader sqlDataReader, string columnName)
        {
            var value = sqlDataReader[columnName];

            return value == System.DBNull.Value ? default(T) : (T)value;
        }
        public static string GetMD5HashData(string data)
        {
            //create new instance of md5
            MD5 md5 = MD5.Create();

            //convert the input text to array of bytes
            byte[] hashData = md5.ComputeHash(Encoding.Default.GetBytes(data));

            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            // return hexadecimal string
            return returnValue.ToString();

        }

        public static bool ValidateMD5HashData(string inputData, string storedHashData)
        {
            //hash input text and save it string variable
            string getHashInputData = GetMD5HashData(inputData);

            if (string.Compare(getHashInputData, storedHashData) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}


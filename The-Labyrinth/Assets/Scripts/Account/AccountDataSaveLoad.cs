using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Account
{
    public class AccountDataSaveLoad
    {
        /// <summary>
        /// Provides a means of storing account data to a file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="account_data"></param>
        public static void SaveAccountData(String path, Account.AccountData account_data)
        {
            if (account_data != null)
            {
                Debug.Log("Saving Useer Data to " + path);

                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(path, FileMode.OpenOrCreate);

                bf.Serialize(file, account_data);

                file.Close();
            }
            else
            {
                Debug.Log("No Account Data to save to " + path);
            }
        }

        /// <summary>
        /// Provides a means for loading account data from file consisting of registered user data
        /// </summary>
        /// <param name="path"></param>
        /// <param name="account_data"></param>
        public static void LoadAccountData(String path, ref Account.AccountData account_data)
        {
            if (File.Exists(path))
            {
                Debug.Log("Loading Account Data from " + path);

                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(path, FileMode.Open);

                account_data = bf.Deserialize(file) as Account.AccountData;

                file.Close();
            }
            else
            {
                Debug.Log("Error: Missing Account File at " + path);
            }
        }
    }
}

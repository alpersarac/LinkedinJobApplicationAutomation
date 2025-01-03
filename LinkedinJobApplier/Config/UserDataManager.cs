﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LinkedinJobApplier.Config
{
    
    public class UserDataManager
    {
        private static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "userdata.txt");

        public string Username { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string SalaryExpectation { get; set; }
        public string NoticePeriodInDays { get; set; }
        public bool Status { get; set; }
        public List<string> Locations { get; set; }
        public List<string> Keywords { get; set; }
        public int cbxDatePostedIndex { get; set; }
        public int cbxVisaSponsorIndex { get; set; }
        public int cbxCommutingIndex { get; set; }
        public bool RememberMe { get; set; }

        public UserDataManager()
        {
            Locations = new List<string>();
            Keywords = new List<string>();
        }

        public void SaveUserData()
        {
            string dataToSave = $"{Username}|{Password}|{Status}|{string.Join(",", Locations)}|{string.Join(",", Keywords)}|{cbxDatePostedIndex}|{RememberMe}|{City}" +
                $"|{SalaryExpectation}|{cbxVisaSponsorIndex}|{cbxCommutingIndex}|{NoticePeriodInDays}";
            File.WriteAllText(FilePath, dataToSave);
        }

        public void LoadUserData()
        {
            if (File.Exists(FilePath))
            {
                string data = File.ReadAllText(FilePath);
                string[] parts = data.Split('|');
                if (parts.Length != 12)
                {
                    throw new InvalidDataException("Invalid data format in the file.");
                }

                Username = parts[0];
                Password = parts[1];
                Status = bool.Parse(parts[2]);
                Locations = new List<string>(parts[3].Split(','));
                Keywords = new List<string>(parts[4].Split(','));
                cbxDatePostedIndex = int.Parse(parts[5]);
                RememberMe = bool.Parse(parts[6]);
                City = parts[7];
                SalaryExpectation = parts[8];
                cbxVisaSponsorIndex = int.Parse(parts[9]);
                cbxCommutingIndex = int.Parse(parts[10]);
                NoticePeriodInDays = parts[11];
            }
        }
    }

}

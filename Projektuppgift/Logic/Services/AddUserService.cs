﻿using Logic.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Logic.Entities;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Logic.Services
{
    public class AddUserService
    {
        public static List<User> usersList = new List<User>();

        public const string userpath = @"C:\Users\julia\Documents\GitHub\Newton-OOP1-\Projektuppgift\Logic\DAL\User.json";
    }
}
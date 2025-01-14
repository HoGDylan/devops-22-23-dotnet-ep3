﻿using Ardalis.GuardClauses;
using Domain.Common;
using Domain.Users;
using Domain.VirtualMachines.VirtualMachine;
using Domain.Utility;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Domain.Server
{
    public class FysiekeServer : Entity
    {

        private readonly List<VirtualMachine> _vms = new(); //only contains active VMs running on this server

        private string _name;
        private string _serverAddress;
        private Hardware _hardWare;


        public int Id { get; set; }
        public String Naam { get { return _name; } private set { _name = Guard.Against.NullOrEmpty(value, nameof(_name)); } }
        public String ServerAddress { get { return _serverAddress; } private set { _serverAddress = Guard.Against.NullOrEmpty(value, nameof(_serverAddress)); } }
        public Hardware HardWare { get { return _hardWare; } private set { _hardWare = Guard.Against.Null(value, nameof(_hardWare)); } }
        public Hardware HardWareAvailable { get; set; }  //dit zou weg mogen
        public List<VirtualMachine> VirtualMachines { get; private set; }


        public FysiekeServer(string naam, Hardware hw, string s_adres)
        {

            this.Naam = naam;
            this.HardWare = hw;
            this.ServerAddress = s_adres;
            this.HardWareAvailable = hw;
            this.VirtualMachines = new();
        }


        public void AddConnection(VirtualMachine vm)
        {
            string pass = PasswordGenerator.Generate(RandomNumberGenerator.GetInt32(10) + 20, RandomNumberGenerator.GetInt32(5) + 1, RandomNumberGenerator.GetInt32(5) + 1, RandomNumberGenerator.GetInt32(5) + 1, RandomNumberGenerator.GetInt32(3) + 1);





            vm.Connection = new VMConnection(ServerAddress, GetRandomIpAddress(), "admin", pass);
            vm.Mode = VirtualMachineMode.READY;
        }



        //IP om te connecteren met de VM
        public IPAddress GetRandomIpAddress()
        {
            var random = new Random();
            string ip = $"{random.Next(1, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}.{random.Next(0, 255)}";


            return IPAddress.Parse(ip);

        }

    }
}
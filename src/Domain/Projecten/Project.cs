﻿using Ardalis.GuardClauses;
using Domain.Common;
using Domain.Users;
using Domain.VirtualMachines;

namespace Domain.Projecten
{

    public class Project : Entity
    {

        private List<VirtualMachine> _vms = new();
        private string _name;
        private Klant _klant;


        public int Id { get; set; }
        public String Name { get { return _name; } set {Guard.Against.NullOrEmpty(_name, nameof(_name)); } }
        public Klant Klant { get { return _klant; } set { Guard.Against.Null(_klant, nameof(_klant));} }


        public Project(string name, Klant k) {
            this.Name = name;
            this.Klant = k;
        }


        public List<VirtualMachine> GetVirtualMachines()
        {
            return _vms;
        }
        public VirtualMachine GetVirtualMachineById(int id)
        {
            return _vms.First(e => e.Id == id);
        }
        
        // name = substring dus meerdere mogelijkheden 
        public List<VirtualMachine> GetVirtualMachineByName(string name)
        {
            return _vms.FindAll(e => e.Name.ToLower().Contains(name));

        }
        public void AddVirtualMachine(VirtualMachine vm)
        {
            _vms.Add(vm);
        }
        public void RemoveVirtualMachine(VirtualMachine vm)
        {
            _vms.Remove(vm);
        }
    }
}
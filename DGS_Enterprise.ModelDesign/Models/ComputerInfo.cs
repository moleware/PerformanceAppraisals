//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DGS_Enterprise.ModelDesign.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ComputerInfo
    {
        public int ComputerID { get; set; }
        public string Computer { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Type { get; set; }
        public string ServiceTag { get; set; }
        public string Processor { get; set; }
        public string Clock { get; set; }
        public string Bios { get; set; }
        public string Memory { get; set; }
        public string HardDisks { get; set; }
        public string RemovableDisks { get; set; }
        public string CDROM { get; set; }
        public string VideoCard { get; set; }
        public string SoundCard { get; set; }
        public string NetworkCards { get; set; }
        public string OperatingSystem { get; set; }
        public string Booted { get; set; }
        public string Uptime { get; set; }
        public string LoginID { get; set; }
        public Nullable<System.DateTime> Warranty { get; set; }
        public Nullable<bool> GoldService { get; set; }
        public Nullable<int> UsageStatus { get; set; }
        public Nullable<bool> CompleteCare { get; set; }
        public Nullable<int> AssetTagID { get; set; }
    }
}
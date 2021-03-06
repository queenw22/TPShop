using System;


namespace Core.Entity
{
    public class Service : BaseEntity
    {
        public string Name { get; set; }
        public long Number { get; set; }
        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }
        public DateTime DateOfService { get; set; }
        public DateTime? Time { get; set; }
        public int CommTypeId { get; set; }
        public CommType CommType { get; set; }
        public int DesignOptionsId { get; set; }
        public DesignOption DesignOptions { get; set; }
        public string Address { get; set; }
        public bool? FacePainter { get; set; }
        public string Theme { get; set; }
        public bool? RushOrder { get; set; }
        public decimal Price { get; set; }
    }
}
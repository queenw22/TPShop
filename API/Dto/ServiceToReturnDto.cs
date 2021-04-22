using System;
using System.ComponentModel.DataAnnotations;
using Core.Entity;

namespace API.Dto
{
    public class ServiceToReturnDto : BaseEntity 
    {
        public string Name { get; set; }
        public long Number { get; set; }
        public string ServiceType { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:MM-dd-yyyy}")]

        public DateTime DateOfService { get; set; }

        [DisplayFormat(DataFormatString="{0:HH:mm}")]
        public DateTime? Time { get; set; }
        public string CommType { get; set; }
        public string DesignOptions { get; set; }
        public string Address { get; set; }
        public bool? FacePainter { get; set; }
        public string Theme { get; set; }
        public bool? RushOrder { get; set; }
        public decimal Price { get; set; }
    }
}
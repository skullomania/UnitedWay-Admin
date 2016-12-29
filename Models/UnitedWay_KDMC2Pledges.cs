namespace UWA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UnitedWay_KDMC2Pledges
    {
        public int id { get; set; }

        [Required]
        public string EmpID { get; set; }

        [Required]
        public string Fname { get; set; }

        [Required]
        public string Lname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string CostCenter { get; set; }

        [Required]
        public string Manager { get; set; }

        [Required]
        public string VP { get; set; }

        [Required]
        public string DateEntered { get; set; }

        public bool FirstTime { get; set; }

        [Required]
        public string ProcessLevel { get; set; }

        [Required]
        public string PrizeCriteria { get; set; }

        [Required]
        public string PayType { get; set; }

        [Required]
        public string PerPay { get; set; }

        [Required]
        public string PayPeriods { get; set; }

        [Required]
        public string AnnualPayroll { get; set; }

        [Required]
        public string GrandTotal { get; set; }

        [Required]
        public string County { get; set; }

        [Required]
        public string Agency { get; set; }

        [Required]
        public string DonationYear { get; set; }

        public string Logged { get; set; }

        public bool? GotPrize { get; set; }
    }
}

﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrderApiApp2.Models
{
    [Table("client")]
    public partial class Client
    {
        public Client()
        {
            Factura = new HashSet<Factura>();
            Orders = new HashSet<Orders>();
        }

        [Key]
        [Column("id_client")]
        public int IdClient { get; set; }
        [Required]
        [Column("client_name")]
        [StringLength(50)]
        public string ClientName { get; set; }

        [InverseProperty("IdClientNavigation")]
        public virtual ICollection<Factura> Factura { get; set; }
        [InverseProperty("IdClientNavigation")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
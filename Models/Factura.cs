﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrderApiApp2.Models
{
    [Table("factura")]
    public partial class Factura
    {
        [Key]
        [Column("id_factura")]
        public int IdFactura { get; set; }
        [Column("id_product")]
        public int? IdProduct { get; set; }
        [Column("id_order")]
        public int? IdOrder { get; set; }
        [Required]
        [Column("product_name")]
        [StringLength(50)]
        public string ProductName { get; set; }
        [Required]
        [Column("articul")]
        [StringLength(50)]
        public string Articul { get; set; }
        [Column("qantity")]
        public int Qantity { get; set; }
        [Column("id_client")]
        public int? IdClient { get; set; }

        [ForeignKey("IdClient")]
        [InverseProperty("Factura")]
        public virtual Client IdClientNavigation { get; set; }
        [ForeignKey("IdOrder")]
        [InverseProperty("Factura")]
        public virtual Orders IdOrderNavigation { get; set; }
        [ForeignKey("IdProduct")]
        [InverseProperty("Factura")]
        public virtual Product IdProductNavigation { get; set; }
    }
}
﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrderApiApp2.Models
{
    [Table("product")]
    public partial class Product
    {
        public Product()
        {
            Factura = new HashSet<Factura>();
        }

        [Key]
        [Column("id_product")]
        public int IdProduct { get; set; }
        [Required]
        [Column("product_name")]
        [StringLength(50)]
        public string ProductName { get; set; }
        [Required]
        [Column("articul")]
        [StringLength(50)]
        public string Articul { get; set; }
        [Column("cost")]
        public double Cost { get; set; }
        [Column("prod_pic")]
        [StringLength(900)]
        public string ProdPic { get; set; }

        [Required(ErrorMessage ="Choose the Profile Fhoto")]
        [Display(Name ="Profile Photo")]
        []
        [InverseProperty("IdProductNavigation")]
        public virtual ICollection<Factura> Factura { get; set; }
    }
}
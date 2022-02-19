using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Products.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        

        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Please Enter Product Name")]
        public string ProductName { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Please Enter Rate")]
        public decimal Rate { get; set; }
        
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter Description")]
        public string Description { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter Category Name")]
        public string CategoryName { get; set; }

    }
}
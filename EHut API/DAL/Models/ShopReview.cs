﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ShopReview
    {
        public int ShopReviewId { get; set; }

        [Required(ErrorMessage = "Can't be empty")]
        public int ShopId { get; set; }



        [Required(ErrorMessage = "Can't be empty")]
        public int CustomerId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public string Comment { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public string Image { get; set; }



        [ForeignKey("ShopId")]
        public Shop Shop { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

    }
}

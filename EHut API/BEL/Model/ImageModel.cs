using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.Model
{
    public class ImageModel
    {
        public int ImageId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public int ProductId { get; set; }


        [Required(ErrorMessage = "Can't be empty")]
        public string ImageSource { get; set; }

    }
}

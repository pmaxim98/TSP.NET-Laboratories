using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP5Lab
{
    [Table("eCommerce", Schema = "TSP5Lab.Model1")]
    public class eCommerce : Business
    {
        public string URL { get; set; }
    }
}

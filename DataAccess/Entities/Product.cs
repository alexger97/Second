using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
   public class Product:Base.BaseIdEntity
    {
        [Required]
        [Column(TypeName ="nvarchar")]
        [Index("Ux_Product_Name_ProductTypeId",IsUnique = true, Order =1)]
        [MaxLength(2000)]
        public string Name { get; set; }


        [Required]
        public double Cost { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(2000)]
        public string Description { get; set; }


        [Required]
        [Index("Ux_Product_Name_ProductTypeId", IsUnique = true, Order = 2)]
        public int ProductTypeId { get; set; }


        [ForeignKey("ProductTypeId")]
        public virtual ProductType ProductType { get; set; }
         

    }
}

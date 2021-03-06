﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities.Base;

namespace DataAccess.Entities
{
    [Table("Role")]
    public class Role
        : BaseIdEntity
    {
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(2000)]
        [Index("UX_Role_Name", Order = 1, IsUnique = true, IsClustered = false)]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar")]
        [MaxLength(2000)]
        public string DisplayName { get; set; }
    }
}
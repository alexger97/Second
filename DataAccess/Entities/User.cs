using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities.Base;

namespace DataAccess.Entities
{
    [Table("User")]
    public class User
        : BaseIdEntity
    {
        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(2000)]
        [Index("UX_User_Login_GroupId", Order = 1, IsUnique = true, IsClustered = false)]
        public string Login { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(2000)]
        public string Password { get; set; }

        [Required]
        [Index("UX_User_Name_GroupId", Order = 2, IsUnique = true, IsClustered = false)]
        public int GroupId { get; set; }

        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }
    }

    public class UserEntityConfiguration
        : EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {
            //HasKey(x => x.Id);
            //Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //HasRequired(x => x.Group);

            //ToTable("User");

            //HasMany(x => x.Login)
            //    .WithMany(x => x.)
            //    .Map(m =>
            //    {
            //        m.MapLeftKey("").MapRightKey("").ToTable("");
            //    });
        }
    }
}
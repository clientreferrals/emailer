using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetMail.Entity
{
    [Table("Setting")]
    public class Setting
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column("Key")]
        public string Key { get; set; }

        [Column("Value")]
        public string Value { get; set; }
    }
}
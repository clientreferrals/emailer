using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirectEmailResults.Entity
{
    [Table("BlackListEmails")]
    public class BlackListEmails
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column("EmailAddress")]
        public string EmailAddress { get; set; }
    }
}

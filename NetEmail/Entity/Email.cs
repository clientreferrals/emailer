using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetEmail.Entity
{
    [Table("Email")]
    public class Email
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column("Host")]
        public string Host { get; set; }

        [Column("Port")]
        public int Port { get; set; }

        [Column("Address")]
        public string Address { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("FromAddress")]
        public string FromAddress { get; set; }

        [Column("FromAlias")]
        public string FromAlias { get; set; }

        [Column("DailyLimit")]
        public int DailyLimit { get; set; }
        [Column("PopHost")]
        public string PopHost { get; set; }
        [Column("PopPort")]
        public int PopPort { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetEmail.Entity
{
    [Table("EmailQueueLog")]
    public class EmailQueueLog
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column("Campaign")]
        public string Campaign { get; set; }

        [Column("Template")]
        public string Template { get; set; }

        [Column("Customer")]
        public string Customer { get; set; }

        [Column("From")]
        public string From { get; set; }

        [Column("To")]
        public string To { get; set; }

        [Column("Date")]
        public string Date { get; set; }

        [Column("Mail")]
        public string Mail { get; set; }

        [Column("ErrorLog")]
        public string ErrorLog { get; set; }

    }
}

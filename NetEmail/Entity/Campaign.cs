using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetEmail.Entity
{
    [Table("Campaign")]
    public class Campaign
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("IsActive")]
        public int IsActive { get; set; }

        [Column("TemplateId")]
        public int TemplateId { get; set; }

        [Column("MailSubject")]
        public string MailSubject { get; set; }
    }
}

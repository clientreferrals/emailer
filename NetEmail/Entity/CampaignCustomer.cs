using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetEmail.Entity
{
    [Table("CampaignCustomer")]
    public class CampaignCustomer
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column("CampaignId")]
        public int CampaignId { get; set; }

        [Column("CustomerId")]
        public int CustomerId { get; set; }

        [Column("IsSent")]
        public int IsSent { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetEmail.Entity
{
    [Table("Customer")]
    public class Customer
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("PhoneNo")]
        public string PhoneNo { get; set; }

        [Column("Tags")]
        public string Tags { get; set; }

        [Column("Email")]
        public string Email { get; set; }
        [Column("Website")]
        public string Website { get; set; }
        [Column("City")]
        public string City { get; set; }
        [Column("State")]
        public string State { get; set; }

    }
}

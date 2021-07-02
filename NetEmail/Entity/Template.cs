using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetEmail.Entity
{
    [Table("Template")]
    public class Template
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Content")]
        public string Content { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NhatSim.Model.Abstract;

namespace NhatSim.Model.Models
{
    [Table("SimNetworks")]
    public class SimNetwork : Auditable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Required, MaxLength(255)]
        public string Name { set; get; }

        [Required, Column(TypeName = "varchar"), MaxLength(255)]
        public string Alias { set; get; }

        public string Image { set; get; }

        [Column(TypeName = "ntext")]
        public string Description { set; get; }

        [Required]
        public bool HomeFlag { set; get; }

        public virtual IEnumerable<FirstNumber> FirstNumbers { set; get; }

        public virtual IEnumerable<SimStore> SimStores { set; get; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace HairSalon.Models {
    public class Stylist {
        [Key]
        public int stylist_id {get; set;}
        public string name {get; set;}
    }
}
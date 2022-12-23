using System.ComponentModel.DataAnnotations;

namespace HairSalon.Models {
    public class Client {
        [Key]
        public int client_id {get; set;}
        public int stylist_id {get; set;}
        public string name {get; set;}
    }
}
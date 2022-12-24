using System.ComponentModel.DataAnnotations;

namespace HairSalon.Models {
    public class Appointment {
        [Key]
        public int appointment_id {get; set;}
        public int client_id {get; set;}
        public int stylist_id {get; set;}
        public string date {get; set;}
        public double price {get; set;}
    }
}
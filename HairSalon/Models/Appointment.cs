using System;
namespace HairSalon.Models
{
    public class Appointment
    {
        public int AppointmentId {get;set;}
        public Client Client {get;set;}
        public int ClientId {get;set;}
        public Stylist Stylist {get;set;}
        public int StylistId {get;set;}
        public DateTime Time {get;set;}
        public string Description {get;set;}
    }
}
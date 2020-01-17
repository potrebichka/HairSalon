namespace HairSalon
{
    public class Client
    {
        public int ClientId {get;set;}
        public string Name {get;set;}
        public string Details {get;set;}
        public int StylistId {get;set;}
        public Stylist Stylist {get;set;}
    }
}
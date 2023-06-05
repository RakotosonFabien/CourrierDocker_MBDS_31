namespace CourrierDocker_MBDS_31.modeles.courrier
{
    public class Statut
    {
        public int Id { get; set; }
        public string Val { get; set; }
        public string? Desc { get; set; }
        public Statut() { }

        public Statut(string val, string? desc)
        {
            Val = val;
            Desc = desc;
        }
        public Statut(int id, string val, string? desc)
        {
            Id = id;
            Val = val;
            Desc = desc;
        }
    }
}

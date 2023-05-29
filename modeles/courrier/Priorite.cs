namespace CourrierDocker_MBDS_31.modeles.courrier
{
    public class Priorite
    {
        public int Id { get; set; }
        public string Val { get; set; }
        public string? Desc { get; set; }
        public Priorite() { }

        public Priorite(string val, string? desc)
        {
            Val = val;
            Desc = desc;
        }
    }
}

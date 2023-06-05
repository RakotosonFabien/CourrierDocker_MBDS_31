namespace CourrierDocker_MBDS_31.modeles.structure
{
    public class Poste
    {
        public int Id { get; set; }
        public string? Val { get; set; }
        public string? Desc { get; set; }
        public Poste() { }
        public Poste(String val)
        {
            Val = val;
        }
        public Poste(int id, String val)
        {
            Id = id;
            Val = val;
        }
    }
}

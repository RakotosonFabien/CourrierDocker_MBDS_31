namespace CourrierDocker_MBDS_31.modeles.structure
{
    public class Departement
    {
        public int Id { get; set; }
        public string? Val { get; set; }
        public string? Desc { get; set; }
        public Departement() { }
        public Departement(String val)
        {
            Val = val;
        }
        public Departement(int id, String val)
        {
            Id = id;
            Val = val;
        }
    }
}

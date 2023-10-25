namespace LastResume.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Actions { get; set; }
        public DateTime startDate { get; set; }
        public DateTime finishDate { get; set; }
        public string  WebSite { get; set; }
        public List<Departments> departments { get; set; }
    }
}

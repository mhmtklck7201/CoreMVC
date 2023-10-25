namespace LastResume.Models
{
    public class Person
    {
        private string birthDate;
        public int Id { get; set; }
        public string FirstName { get; set; }
 
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string  Nationality { get; set; }
        public string Age
        {
            get
            {
                return birthDate;
            }
            set
            {
                if (value != null)
                {
                    var now = DateTime.Now.Year;
                    var past=DateTime.Parse(value).Year;
                    birthDate = (now - past).ToString();
                }

            }
        }
        public string Address { get; set; }
        public string EduUniversity { get; set; }
        public string EduDescription { get; set; }
        public string startEducation { get; set; }
        public string endEducation { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public List<Skills> Skills { get; set; }

    }
}

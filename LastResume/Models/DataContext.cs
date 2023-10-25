namespace LastResume.Models
{
    public class DataContext
    {
        public List<Company> GetWorks(int count)
        {
            List<Company> companies = new List<Company>()
            {
                new Company(){Actions="İyi",CompanyName="Magiclick",Description="İyi",startDate=DateTime.Now,finishDate=DateTime.Now,WebSite="www.magiclick.com",Id=1,
                    departments=new List<Departments>(){
                    new Departments(){Name="Jr.Sharepoint Developer",Description="İlk",Duration=2,Id=1},
                    new Departments(){Name="Mid.Sharepoint Developer",Description="ikinciis",Duration=2,Id=2}
                    } },
                new Company(){Actions="İyi",CompanyName="Magiclick",Description="İyi",startDate=DateTime.Now,finishDate=DateTime.Now,WebSite="www.magiclick.com",Id=1,
                    departments=new List<Departments>(){
                    new Departments(){Name="Jr.Sharepoint Developer",Description="İlk",Duration=2,Id=1},
                    new Departments(){Name="Mid.Sharepoint Developer",Description="ikinciis",Duration=2,Id=2}
                    } } };
            return companies;
        }
        public Person GetUserInfo()
        {
            Person person = new Person()
            {
                Id = 1,
                FirstName = "Mehmet",
                LastName = "Kalçık",
              
                Address = "Istanbul",
                Email = "mhmtklck7201@gmail.com",
                Age = DateTime.Parse("1992/01/01").ToString(),
                Phone = "905456278572",
                EduUniversity = "Çukurova University",
                EduDescription = "In Adana",
                startEducation = DateTime.Parse("2012/09/10").ToString("dd/MM/yyyy"),
                endEducation = DateTime.Parse("2016/06/20").ToString("dd/MM/yyyy"),
                LongDescription = "I'm a software & sharepoint developer",
                Nationality="Turkish",
                Skills = GetSkills()
            };
            return person;
        }
        public List<Skills> GetSkills()
        {
            List<Skills> skills = new List<Skills>()
            {
               new Skills(){SkillName="Sharepoint ON PREM",SkillAvarage=100},
               new Skills(){SkillName="Sharepoint Online",SkillAvarage=70},
              new Skills(){SkillName="ASP.Net",SkillAvarage=75},
               new Skills(){SkillName="ADO .Net",SkillAvarage=80},
               new Skills(){SkillName="Linq",SkillAvarage=80},
                new Skills(){SkillName="MongoDB",SkillAvarage=30},
              new Skills(){SkillName="C#",SkillAvarage=100},
              new Skills(){SkillName="MVC",SkillAvarage=80},
              new Skills(){SkillName=".NET CORE",SkillAvarage=40},
              new Skills(){SkillName="EF CORE",SkillAvarage=40},
               
               new Skills(){SkillName="MSSQL",SkillAvarage=80},
               new Skills(){SkillName="ANGULAR",SkillAvarage=30},
               new Skills(){SkillName="TFS,GIT",SkillAvarage=40},
                new Skills(){SkillName="JIRA",SkillAvarage=40}
            };
            return skills;
        }
        public List<ProjectDetails> GetPortfolios()
        {

            List<ProjectDetails> skills = new List<ProjectDetails>()
            {
                new ProjectDetails(){ProjectId=1, ImgURL=$"/img/portfolio/odeabank.png",Category="Sharepoint,.Net",Client="Odebank",ProjectDate="2020",ProjectName="Odeabank",ProjectURL="https://www.odeabank.com.tr",ProjectDetail="Bu bir sharepoint projesidir"},
                 new ProjectDetails(){ProjectId=2,ImgURL=$"/img/portfolio/isbankasi.jpg",Category="Sharepoint,.Net",Client="Iş Bankası",ProjectDate="2020",ProjectName="İş Bank",ProjectURL="https://www.isbank.com.tr",ProjectDetail="Bu bir sharepoint projesidir"},
                  new ProjectDetails(){ProjectId=3,ImgURL=$"/img/portfolio/is-yatirim.jpg",Category="Sharepoint,.Net",Client="Iş Yatırım",ProjectDate="2020",ProjectName="İş Yatırım",ProjectURL="https://www.isyatirim.com.tr",ProjectDetail="Bu bir sharepoint projesidir"},
                   new ProjectDetails(){ProjectId=4,ImgURL=$"/img/portfolio/denizbank.jpg",Category="Sharepoint,.Net",Client="DenizBank",ProjectDate="2020",ProjectName="DenizBank",ProjectURL="https://www.denizbank.com.tr",ProjectDetail="Bu bir sharepoint projesidir"},
                     new ProjectDetails(){ProjectId=5,ImgURL=$"/img/portfolio/maximum.jpg",Category="Sharepoint,.Net",Client="Maximum",ProjectDate="2020",ProjectName="Maximum",ProjectURL="https://www.maximum.com.tr",ProjectDetail="Bu bir sharepoint projesidir"}
            };
            return skills;
        }
        public ProjectDetails GetPortfolioDetail(int id)
        {
            var portfolio = GetPortfolios().SingleOrDefault(s => s.ProjectId == id);
            return portfolio;
        }
    }
}

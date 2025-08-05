namespace Proyecto.Models.Colaborador
{
    public class CollaboratorModel
    {
        private string id;
        private string name;
     
        private int year;
       

        public StudentModel(string name, string lastName, int year)
        {
            Guid guid = Guid.NewGuid();

            this.id = guid.ToString();
            this.name = name;
            this.lastName = lastName;
            this.year = year;
            this.dateReg = DateTime.Now;
        }

        public string GetId() { return id; }

        public string GetName() { return name; }

        public string GetLastName() { return lastName; }

        public int GetYear() { return year; }

        public DateTime GetDateReg() { return dateReg; }


        public void SetYear(int year) { this.year = year; }
    }
}

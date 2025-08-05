namespace Proyecto.Models.Colaborador
{
    public class CollaboratorModel
    {
        private string id;
        private string name;
       
      

        public CollaboratorModel(string name)
        {
            Guid guid = Guid.NewGuid();
            this.id = guid.ToString();
            this.name = name;
        }

        public string GetId() { return id; }
        public string GetName() { return name; }  
    }
}

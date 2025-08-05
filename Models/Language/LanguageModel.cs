namespace Proyecto.Models.Language
{
    public class LanguageModel
    {
        private string id;
        private string name;
       

        public LanguageModel(string name)
        {
            Guid guid = Guid.NewGuid();
            this.id = guid.ToString();
            this.name = name;         
        }

        public string GetId() { return id; }

        public string GetName() { return name; }

       
}
}

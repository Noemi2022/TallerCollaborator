namespace Proyecto.Models.Language
{
    public class LanguageModel
    {
        public string languageid { get; set; }
        public string name { get; set; }

        public LanguageModel(string name)
        {
            Guid guid = Guid.NewGuid();
            this.languageid = guid.ToString();
            this.name = name;
           
        }
        public string GetLanguageid() {  return languageid; }
        public string Getname() { return name; }
    }
}

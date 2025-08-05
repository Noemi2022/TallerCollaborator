namespace Proyecto.Models.Language
{
    public class LanguageAllResponse
    {
        public string id { get; set; }
        public string name { get; set; }
       

        public string GetId()   // This is the getter
        {
            return id;
        }
        public void SetId(string newid)   // This is the setter, new value
        {
            id = newid;
        }
    }
}

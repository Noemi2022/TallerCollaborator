using Proyecto.Models.Colaborador;
using Proyecto.Models.Language;
using Proyecto.Models.Proyecto;

namespace Proyecto.Repository
{
    public class LanguageRepository
    {
        static List<LanguageModel> lenguages = new List<LanguageModel>();

        public List<LanguageModel> GetListLanguages()
        {
            return lenguages;
        }

      


        public LanguageModel? GetLastLanguage()
        {
            int countLanguages = lenguages.Count();
            if (countLanguages == 0) return null;
            return lenguages[countLanguages - 1];
        }

        public bool AddNewLanguage(LanguageModel model)
        {
            lenguages.Add(model);

            return true;
        }


        public LanguageModel? GetLanguagesById(string id)
      {
          return lenguages.FirstOrDefault((model) => model.GetLanguageid() == id);
      }
        public LanguageModel? GetLanguageByName(string name)
        {
            return lenguages.FirstOrDefault((model) => model.Getname() == name);
        }
        public bool RemoveLanguage(string id)
        {
            LanguageModel? model = GetLanguagesById(id);
            if (model == null) return false;
            return lenguages.Remove(model);
        }


        
        //public bool RemoveStudent(string id)
        //{
        //    CollaboratorModel? model = GetStudentsById(id);
        //    if (model == null) return false;
        //    return students.Remove(model);
        //}
    }
}

using System.Collections.Generic;
using System.Reflection;
using Proyecto.Helpers.Models;
using Proyecto.Models.Colaborador;
using Proyecto.Models.Collaborator;
using Proyecto.Models.Language;
using Proyecto.Models.Proyecto;
using Proyecto.Models.ProyectoColaborador;
using Proyecto.Repository;
using Proyecto.Helpers.Vars;

namespace Proyecto.Bll.Project
{
    public class LanguageBll
    {
        LanguageRepository repository = new LanguageRepository();

        public List<LanguageAllResponse> GetLanguages()
        {
            if (repository.GetListLanguages().Count() == 0) 
            {
                LanguageModel Language1 = new LanguageModel("Ingles");
                repository.AddNewLanguage(Language1);
                LanguageModel Language2 = new LanguageModel("Español");
                repository.AddNewLanguage(Language2);

            }
            //obtener lista de LanguageResponse 
            List<LanguageAllResponse> list = new List<LanguageAllResponse>();
            //RECORRER LA LISTA DE respositorio de lenguage
            foreach (LanguageModel model in repository.GetListLanguages())
            {
                //LanguageAllResponse response = ModelToResponse(model);
                LanguageAllResponse response = new LanguageAllResponse();
                response.languageid = model.GetLanguageid();
                response.name = model.Getname();

                list.Add(response);
            }
            return list;


        }

        public ResponseGeneralModel<List<LanguageModel>> AddLanguages(LanguageAddRequest request)
        {
            LanguageModel modelR = repository.GetLanguageByName(request.name);
            if (modelR == null)
            {
                LanguageModel model = new LanguageModel(request.name);

                bool isAdd = repository.AddNewLanguage(model);

                return new ResponseGeneralModel<List<LanguageModel>>(isAdd ? 200 : 500, null, isAdd ? Message.addLanguagesOk : Message.addLanguagesError);
            }
            else
            {
                return new ResponseGeneralModel<List<LanguageModel>>(400, null, Message.addLanguageDuplicado);
            }
        }


       
    }
}

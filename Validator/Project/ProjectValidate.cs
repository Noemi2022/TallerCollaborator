using System.Collections.Generic;
using System.Collections.Generic;
using Proyecto.Helpers.Helper;
using Proyecto.Helpers.Models;
using Proyecto.Helpers.Vars;
using Proyecto.Models.Project;
using Proyecto.Models.Proyecto;
using Proyecto.Models.Language;
namespace Proyecto.Validator.Proyecto

{
    public class ProjectValidate
    {
        public ResponseGeneralModel<List<ProjectModel>> AddProject(ProjectAddRequest model)
        {
            ValidateHelper<List<ProjectModel>> validaH = new ValidateHelper<List<ProjectModel>>();

            ResponseGeneralModel<List<ProjectModel>> valName = validaH.ValidResp(model.name, "name", Min: 4, Max: 30, ListRegExp: new List<string>() { VarHelper.regExParamString });
            if (valName.code != 200) return valName;

            return new ResponseGeneralModel<List<ProjectModel>>(200, "");
        }


        public ResponseGeneralModel<List<LanguageModel>> AddLanguagess(LanguageAddRequest model)
        {
            ValidateHelper<List<LanguageModel>> validaHel = new ValidateHelper<List<LanguageModel>>();

            ResponseGeneralModel<List<LanguageModel>> valName = validaHel.ValidResp(model.name, "name", Min: 4, Max: 12, ListRegExp: new List<string>() { VarHelper.regExParamString });
            if (valName.code != 200) return valName;


            return new ResponseGeneralModel<List<LanguageModel>>(200, "");
        }
    }
}

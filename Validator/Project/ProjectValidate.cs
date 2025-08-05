using System.Collections.Generic;
using System.Collections.Generic;
using Proyecto.Helpers.Helper;
using Proyecto.Helpers.Models;
using Proyecto.Helpers.Vars;
using Proyecto.Models.Project;
using Proyecto.Models.Proyecto;
namespace Proyecto.Validator.Proyecto

{
    public class ProjectValidate
    {
        public ResponseGeneralModel<List<ProjectModel>> AddClassroom(ProjectAddRequest model)
        {
            ValidateHelper<List<ProjectModel>> validaH = new ValidateHelper<List<ProjectModel>>();

            ResponseGeneralModel<List<ProjectModel>> valName = validaH.ValidResp(model.name, "name", Min: 4, Max: 12, ListRegExp: new List<string>() { VarHelper.regExParamString });
            if (valName.code != 200) return valName;


            //if (model.year < 2000 || model.year > 3000)
            //{
            //    return new ResponseGeneralModel<List<ClassroomModel>>(400, null, Message.ErrorParamsGeneral, Message.validateParamYearClassroom);
            //}

            return new ResponseGeneralModel<List<ProjectModel>>(200, "");
        }
    }
}

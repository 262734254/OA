
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL.Matter
{
   public interface IExamineService
    {

       int AddExamine(Examine e);
       IList<Examine> SearchExamineByType(string type);
       Examine GetExaminById(int id);
       
       //根据状态和类型获取所有申请信息
       IList<Pending> SearchPending(string state, string type);
       //根据审批类型和ID终结申请
       void ModifyApplicationById(string type, int id);

       //根据审批记录ID删除一项审批记录
       void DeleteEXamine(int id);

    }
}

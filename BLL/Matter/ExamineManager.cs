using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL.Matter;
using OAFactory;
using IDAL.Car;
using Model;

namespace BLL.Matter
{
    public  class ExamineManager
    {
        private static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();

        private static IExamineService examineService = factory.CreateExamineService();


        public static int AddExamine(Examine e)
        {
          return  examineService.AddExamine(e);

        
        }
         /// <summary>
        /// 终结申请
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        public static void ModifyApplicationById(string type, int id)
        {
            examineService.ModifyApplicationById(type,id);
        }
      /// <summary>
        /// 根据审批类型查询审批记录
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IList<Examine> SearchExamineByType(string type)
        {
            return examineService.SearchExamineByType(type);
        }
         /// <summary>
        /// 根据ID查询一条审批记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Examine GetExaminById(int id)
        {
            return examineService.GetExaminById(id);
        }
        /// <summary>
        /// 根据状态和类型获取所有申请信息
        /// </summary>
        /// <param name="state"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IList<Pending> SearchPending(string state, string type)
        {
            return examineService.SearchPending(state, type);
        }
        /// <summary>
        /// 根据审批记录ID删除一项审批记录
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteEXamine(int id)
        {
            examineService.DeleteEXamine(id);
        }
    }
}

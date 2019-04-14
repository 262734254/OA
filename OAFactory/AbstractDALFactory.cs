using System;
using System.Collections.Generic;
using System.Text;

using System.Configuration;

using IDAL.Car;
using IDAL.Power;
using IDAL.Target;
using IDAL.WorkHelper;
using IDAL.Meeting;
using IDAL.Resource;
using IDAL.Matter;
namespace OAFactory
{
    public abstract class AbstractDALFactory
    {
        //对工厂进一步抽象,接口为最高抽象
        //车辆管理接口
        public abstract ICarBuyApplyService CreateCarBuyApplyService();
        public abstract ICarDavnoteService CreateCarDavnoteService();
        public abstract ICarEnterService CreateCarEnterService();
        public abstract ICarsService CreateCarService();
        public abstract ICarTypeService CreateCarTypeService();
        public abstract ICarUserInfoService CreateCarUserInfoService();
        public abstract IServicesService CreateServiceService();
        public abstract IDisobeyRecordService CreateDisobeyRecordService();
        public abstract ICostSuperviseService CreateCostSuperviseService();
        public abstract ICheerService CreateCheerService();
        public abstract ICarByapplyService CreateCarByapplyServcie();
        

        //会议管理接口
        public abstract IMeetingApplicationService CreateMeetingApplicationService();
        public abstract IMeetingSummaryService CreateMeetingSummaryService();
        public abstract IRoomArrageService CreateRoomArrageService();
        public abstract IRoomInfoService CreateRoomInfoService();
 


        //待办事宜管理接口

        public abstract IExamineService CreateExamineService();


        //资源管理接口
        public abstract IApplicationResourseService CreateApplicationResourseServcie();
        public abstract IBorrowApplicationService CreateBorrowApplicationService();
        public abstract IProviderInfoService CreateProviderInfoService();
        public abstract IResourceRestoreService CreateResourceRestoreServcie();
        public abstract IResourceStoreService CreateResourceStoreService();
        public abstract IResourceTypeService CreateResourceTypeService();
        public abstract IResourceInfoService CreateResourceInfoService();
        public abstract ISpoilageRegisterService CreateSpoilageRegisterService();
        public abstract IStockApplicationService CreateStockApplicationService();


        //权限管理接口
        public abstract IDepartmentService CreateDepartmentService();
        public abstract IUserInfoService CreateUserInfoService();
        public abstract IRolePowerService CreateRolePowerServcice();




        //办公助手管理接口
        public abstract ICalendarService CreateCalendarService();
        public abstract ILeaveWordService CreateLeaveWordService();
        public abstract IAddressService CreateAddressServcive();
        public abstract IMessageType CreateMessageType();

        //重点任务目标管理接口
        public abstract ITaskService CreateTaskService();
     



        //创建工厂的选择应该用反射实现
        //便于学员理解这里用开关语句实现
        public static AbstractDALFactory ChooseFactory()
        {
        
            AbstractDALFactory factory = null;
            string dbType = ConfigurationManager.AppSettings["DBType"].ToString();

            switch (dbType)
            {
                case "SqlServer": //实例化 SQL Server工厂对象
                    factory = new SqlDALFactory();
                    break;
               
            }
            return factory;
        }
       
    }
}

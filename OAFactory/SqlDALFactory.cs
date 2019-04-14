using System;
using System.Collections.Generic;
using System.Text;

using DAL.Car;
using DAL.Power;
using DAL.Target;
using DAL.WorkHelper;
using DAL.Matter;
using DAL.Resource;
using DAL.Meeting;

using IDAL.Car;
using IDAL.Power;
using IDAL.Target;
using IDAL.WorkHelper;
using IDAL.Meeting;
using IDAL.Resource;
using IDAL.Matter;
namespace OAFactory
{
    public class SqlDALFactory : AbstractDALFactory   //����ʵ�ֶ�̬
    {
        //�����ӣѣ� Serverʵ���Ʒ

        #region  ��������ģ��ӿ�

        public override ICarBuyApplyService CreateCarBuyApplyService()
        {
            return new CarBuyApplyService();
        }

        public override ICarDavnoteService CreateCarDavnoteService()
        {
            return new CarDavnoteService();
        }

        public override ICarEnterService CreateCarEnterService()
        {
            return new CarEnterService();
        }

        public override ICarsService CreateCarService()
        {
            return new CarsService();
        }

        public override ICarTypeService CreateCarTypeService()
        {
            return new CarTypeService();
        }

        public override ICarUserInfoService CreateCarUserInfoService()
        {
            return new CarUserInfoService();
        }
        public override IServicesService CreateServiceService()
        {
            return new ServicesService();
        }

        public override IDisobeyRecordService CreateDisobeyRecordService()
        {
            return new DisobeyRecordService();
        }

        public override ICostSuperviseService CreateCostSuperviseService()
        {
            return new CostSuperviseService();
        }

        public override ICheerService CreateCheerService()
        {
            return new CheerService();
        }

        public override ICarByapplyService CreateCarByapplyServcie()
        {
            return new CarByapplyService();
        }
        #endregion  ��������ģ��ӿڽ���

        #region    Ȩ�޹���ģ��ӿ�
        public override IDepartmentService CreateDepartmentService()
        {
            return new DepartmentService();
        }

        public override IUserInfoService CreateUserInfoService()
        {
            return new UserInfoService();
        }

        public override IDAL.Power.IRolePowerService CreateRolePowerServcice()
        {
            return new RolePowerService();
        }

        #endregion Ȩ�޹���ģ��ӿڽ���


        #region   �칫����ģ��ӿ�
        public override ICalendarService CreateCalendarService()
        {
            return new CalendarService();
        }
        public override ILeaveWordService CreateLeaveWordService()
        {
            return new LeaveWordService();
        }


        public override IAddressService CreateAddressServcive()
        {
            return new AddressService();
        }

        public override IMessageType CreateMessageType()
        {
            return new MessageTypeService();
        }
        #endregion  �칫����ģ��ӿڽ���




        #region   �ص�����Ŀ�����ģ��ӿ�
        public override ITaskService CreateTaskService()
        {
            return new TaskService();
        }

        #endregion  �ص�����Ŀ�����ģ��ӿڽ���


        #region      ��Դ����ģ��ӿ�
        public override IApplicationResourseService CreateApplicationResourseServcie()
        {
            return new ApplicationResourseService();
        }

        public override IBorrowApplicationService CreateBorrowApplicationService()
        {
            return new BorrowApplicationService();
        }

        public override IProviderInfoService CreateProviderInfoService()
        {
            return new ProviderInfoService();
        }

        public override IResourceRestoreService CreateResourceRestoreServcie()
        {
            return new ResourceRestoreService();
        }

        public override IResourceStoreService CreateResourceStoreService()
        {
            return new ResourceStoreService();
        }

        public override IResourceTypeService CreateResourceTypeService()
        {
            return new ResourceTypeService();
        }

        public override IResourceInfoService CreateResourceInfoService()
        {
            return new ResourceInfoService();
        }

        public override ISpoilageRegisterService CreateSpoilageRegisterService()
        {
            return new SpoilageRegisterService();
        }

        public override IStockApplicationService CreateStockApplicationService()
        {
            return new StockApplicationService();
        }
        #endregion   ��Դ����ģ��ӿڽ���

        #region   �������ģ��ӿ�
        public override IMeetingApplicationService CreateMeetingApplicationService()
        {
            return new MeetingApplicationService();
        }


        public override IMeetingSummaryService CreateMeetingSummaryService()
        {
            return new MeetingSummaryService();
        }

        public override IRoomArrageService CreateRoomArrageService()
        {
            return new RoomArrageService();
        }

        public override IRoomInfoService CreateRoomInfoService()
        {
            return new RoomInfoService();
        }
        #endregion   �������ģ��ӿڽ���



        #region  ��������ģ��ӿ�
        public override IExamineService CreateExamineService()
        {
            return new ExamineService();
        }
        #endregion  ��������ģ��ӿڽ���


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;
namespace IDAL.Car
{
    public interface IDisobeyRecordService
    {
         IList<DisobeyRecord> getAllDisobeyRecord(string statime, string endtime, string dr_CarType, string carMark);
         int addDisobeyRecord(DisobeyRecord dr);
         int updateDisobeyRecord(DisobeyRecord dr);
         DisobeyRecord getDisobeyRecordById(int DR_Id);
         int delDisobeyRecordById(int DR_Id);
         IList<DisobeyRecord> getDisobeyRecordByMark();
    }
}

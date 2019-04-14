using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   /// <summary>
	/// 实体类Car_Cars 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Car_Cars
	{
		public Car_Cars()
		{}
		#region Model
		private int car_id;
		private string carmark;
		private int seating;
		private Car_Type typeid =new Car_Type();
		private DateTime buydata;
		private decimal buymoney;
		private string buywork;
		private string state;
		private string remark;
		private string expand;
		/// <summary>
		/// 
		/// </summary>
        public int Car_Id
        {
            set { car_id = value; }
            get { return car_id; }
        }
		
		/// <summary>
		/// 
		/// </summary>
		public string CarMark
		{
			set{ carmark=value;}
			get{return carmark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Seating
		{
			set{ seating=value;}
			get{return seating;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Car_Type Typeid
		{
			set{ typeid=value;}
			get{return typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime BuyData
		{
			set{ buydata=value;}
			get{return buydata;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal BuyMoney
		{
			set{ buymoney=value;}
			get{return buymoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Buywork
		{
			set{ buywork=value;}
			get{return buywork;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string State
		{
			set{ state=value;}
			get{return state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReMark
		{
			set{ remark=value;}
			get{return remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ExPand
		{
			set{ expand=value;}
			get{return expand;}
		}
		#endregion Model

	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
	/// 实体类Car_BuyApply 。
	/// </summary>
	[Serializable]
	public class Car_BuyApply
	{
		public Car_BuyApply()
		{}
		#region Model
		private int buyapplyid;
        private Department dept=new Department();
		private DateTime applytime;
		private Car_Type buytype=new Car_Type();
		private decimal buyprice;
		private string couse;
		private string remark;
		private string state;
		private string expand;
		/// <summary>
		/// 
		/// </summary>
		public int BuyApplyId
		{
			set{ buyapplyid=value;}
			get{return buyapplyid;}
		}
		/// <summary>
		/// 
		/// </summary>
        public Department Dept
		{
			set{ dept=value;}
			get{return dept;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ApplyTime
		{
			set{ applytime=value;}
			get{return applytime;}
		}
		/// <summary>
		/// 
		/// </summary>
        public Car_Type buyType
        {
            set { buytype = value; }
            get { return buytype; }
        }
		
		/// <summary>
		/// 
		/// </summary>
		public decimal BuyPrice
		{
			set{ buyprice=value;}
			get{return buyprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Couse
		{
			set{ couse=value;}
			get{return couse;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ remark=value;}
			get{return remark;}
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
		public string ExPand
		{
			set{ expand=value;}
			get{return expand;}
		}
		#endregion Model

	}
}
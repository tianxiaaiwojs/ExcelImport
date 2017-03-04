using System;
namespace HotelManagement
{
	public class DataTableAttribute:Attribute
	{
		private string _tableName;
		public DataTableAttribute(string tableName)
		{
			this._tableName = tableName;
		}

		public string TableName{
			get{
				return this._tableName;
			}
			set{
				this._tableName = value;
			}
		}
	}
}

using System;
namespace HotelManagement
{
	public class DataColumnAttribute:Attribute
	{
		private string _sourceColumnName;
		private string _destColumnName;
		public DataColumnAttribute(string sourceColumnName, string destCoumnName)
		{
			this._sourceColumnName = sourceColumnName;
			this._destColumnName = destCoumnName;
		}

		public string SourceColumnName{
			get{
				return this._sourceColumnName;
			}
			set{
				this._sourceColumnName = value;
			}
		}

		public string DestColumnName{
			get{
				return this._destColumnName;
			}
			set{
				this._destColumnName = value;
			}
		}
	}
}

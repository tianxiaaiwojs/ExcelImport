using System;
using System.Linq;
using System.Text;
using GLib;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Reflection;
using Gdk;
namespace HotelManagement
{
	public class DatabaseHelper
	{
		private static DatabaseHelper _instance;
		protected DatabaseHelper()
		{
		}

		public void Insert<T>(IList<T> entities) where T:HotelBaseEntity{
			using(var conn = new MySqlConnection(XmlHelper.Instance.DataBaseConnectionString)){
				conn.Open();
				var properties = typeof(T).GetProperties();
				var tableNameAttr = (DataTableAttribute)typeof(T).GetCustomAttributes(typeof(DataTableAttribute), false).First();
				if(tableNameAttr ==null){
					throw new Exception("Can't find table name.");
				}
				var tableName = tableNameAttr.TableName;

				var sqlSB = new StringBuilder();
				//sqlSB.Append("set names utf8;");
				//sqlSB.Append(string.Format("INSERT INTO {0} VALUES (",tableName));
				try
				{
					foreach (var entity in entities)
					{
						var fieldPart = new List<string>();
						var valuePart = new List<string>();
						foreach (var item in properties)
						{
							var columnAttr = (DataColumnAttribute)item.GetCustomAttribute(typeof(DataColumnAttribute));
							if (columnAttr != null)
							{
								fieldPart.Add(columnAttr.DestColumnName);
								valuePart.Add("'" + item.GetValue(entity, null).ToString() + "'");
							}
						}
						sqlSB.Append(string.Format("INSERT INTO {0}({1}) VALUES ({2});", tableName, String.Join(",", fieldPart), String.Join(",", valuePart)));
					}



					var cmd = conn.CreateCommand();
					cmd.CommandText = sqlSB.ToString();
					cmd.ExecuteNonQuery();
				}catch(Exception ex){
					var xx = ex;
				}

				conn.Close();
				conn.Dispose();
			}

		}

		public List<T> Select<T>(PropertyInfo p, List<string> queryValuePart) where T:HotelBaseEntity, new(){
			
			var columnAttr = (DataColumnAttribute)p.GetCustomAttribute(typeof(DataColumnAttribute));
			var searchColumn = columnAttr.DestColumnName;
			var tableName = "";
			var list = new List<T>();
			var infos = new List<PropertyInfo>();

			for (int i = 0; i < queryValuePart.Count; i++)
			{
				queryValuePart[i] = "'" + queryValuePart[i] + "'";
			}

			var tableAttr = (DataTableAttribute)typeof(T).GetCustomAttribute(typeof(DataTableAttribute));
			tableName = tableAttr.TableName;

			var propertyInfos = typeof(T).GetProperties();
			infos = propertyInfos.ToList();

			using(var conn = new MySqlConnection(XmlHelper.Instance.DataBaseConnectionString)){
				conn.Open();
				var sqlSB = new StringBuilder();
				sqlSB.Append(string.Format("SELECT * FROM {0} WHERE {1} IN ({2})", tableName, searchColumn, string.Join(",", queryValuePart)));

				var cmd = conn.CreateCommand();
				cmd.CommandText = sqlSB.ToString();
				try
				{
					using (var reader = cmd.ExecuteReader(CommandBehavior.Default))
					{
						while (reader.Read())
						{
							var t = new T();
							foreach (var info in infos)
							{
								var currentName = ((DataColumnAttribute)info.GetCustomAttribute(typeof(DataColumnAttribute))).DestColumnName;
								info.SetValue(t, reader[currentName].ToString());
							}
							list.Add(t);
						}
					}
				}catch(Exception ex){
					var xx = ex;
				}

				conn.Close();
				conn.Dispose();
			}

			return list;
		}

		public static DatabaseHelper Helper{
			get{
				if(_instance == null){
					_instance = new DatabaseHelper();
				}
				return _instance;
			}
		}
	}
}

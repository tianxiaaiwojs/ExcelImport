using System;
using System.Collections.Generic;
using Gtk;
using LumenWorks.Framework.IO.Csv;
using System.Reflection;
namespace HotelManagement
{
	public class ExcelImportHelper
	{
		private static ExcelImportHelper _instance;
		protected ExcelImportHelper()
		{
		}

		public static ExcelImportHelper Helper
		{
			get{
				if(null == _instance){
					_instance = new ExcelImportHelper();
				}
				return _instance;
			}
		}

		public List<T> Import<T>(string filePath) where T:HotelBaseEntity, new(){
			var list = new List<T>();

			using(var textReader = System.IO.File.OpenText(filePath))
			using(var reader = new CsvReader(textReader, true)){
				var columnNames = reader.GetFieldHeaders();
				var properties = typeof(T).GetProperties();
				var enumlator = reader.GetEnumerator();

				while(enumlator.MoveNext()){
					var currentRow = enumlator.Current;

					var t = new T();
					foreach (var item in columnNames)
					{
						var index = reader.GetFieldIndex(item);
						foreach (var property in properties)
						{
							var columnAttr = (DataColumnAttribute)property.GetCustomAttribute(typeof(DataColumnAttribute));
							if(columnAttr ==null || columnAttr.SourceColumnName != item){
								continue;
							}

							property.SetValue(t,currentRow[index]);
						}
					}
					list.Add(t);
				}
			}

			return list;
		}
	}
}

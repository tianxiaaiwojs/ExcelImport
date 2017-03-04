using System;
using System.Collections.Generic;
namespace HotelManagement
{
	public class HotelBookDetailsImport:ExcelImportHelper
	{
		public HotelBookDetailsImport()
		{
		}

		public List<HotelBookDetails> Import(string path){
			return Helper.Import<HotelBookDetails>(path);
		}
	}
}

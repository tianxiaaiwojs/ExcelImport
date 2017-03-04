using System;
namespace HotelManagement
{
	public class HotelBookDetailController
	{
		private HotelBookDetailsImport _excelHelper;
		private HotelBookDetailsDataAccessor _dataAccessor;
		public HotelBookDetailController()
		{
			this._excelHelper = new HotelBookDetailsImport();
			this._dataAccessor = new HotelBookDetailsDataAccessor();
		}

		/// <summary>
		/// Imports the excel to database.
		/// </summary>
		/// <param name="filePath">File path.</param>
		public void ImportExcelToDatabase(string filePath){
			var list = this._excelHelper.Import(filePath);
			list.ForEach((obj) => {obj.ID = Guid.NewGuid().ToString();});
			this._dataAccessor.Insert(list);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using Glade;
namespace HotelManagement
{
	public class HotelBookDetailsDataAccessor:DatabaseHelper
	{
		public HotelBookDetailsDataAccessor()
		{
		}

		public void Insert(List<HotelBookDetails> entities){
			//check webReferenceId in database.
			var searchList = new List<string>();
			foreach (var item in entities)
			{
				searchList.Add(item.WebReferenceId);
			}

			var returnList = this.SelectByWebReferenceId(searchList);
			var needRemove = new List<HotelBookDetails>();
			foreach (var serverItem in returnList)
			{
				foreach (var clientItem in entities)
				{
					if(serverItem.WebReferenceId == clientItem.WebReferenceId){
						needRemove.Add(clientItem);
					}
				}
			}

			foreach (var item in needRemove)
			{
				entities.Remove(item);
			}
			Helper.Insert(entities);
		}

		public List<HotelBookDetails> SelectByWebReferenceId(List<string> referenceIds){
			//get webReferenceId propertyInfo
			var property = typeof(HotelBookDetails).GetProperty("WebReferenceId");
			return Helper.Select<HotelBookDetails>(property, referenceIds);
		}
	}
}

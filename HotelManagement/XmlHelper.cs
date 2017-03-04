using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.IO;
using System.Xml;
using System.Linq;
namespace HotelManagement
{
	public class XmlHelper
	{
		private string _basePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

		private string _configurationFileName = "Configuration.xml";
		private static XmlHelper _instance;

		private string _databaseConnectionString;
		private XmlDocument _xmlDocument;

		private string _databaseConnectionStringNodeName = "ConnectionString";


		private XmlHelper()
		{
			this.loadXml();
		}

		/// <summary>
		/// Loads the xml.
		/// </summary>
		private void loadXml(){
			var xmlContent = System.IO.File.ReadAllText(Path.Combine(_basePath, _configurationFileName));
			this._xmlDocument = new XmlDocument();
			this._xmlDocument.LoadXml(xmlContent);
		}

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static XmlHelper Instance{
			get{
				if(_instance == null){
					_instance = new XmlHelper();
				}
				return _instance;
			}
		}


		/// <summary>
		/// Gets the data base connection string.
		/// </summary>
		/// <value>The data base connection string.</value>
		public string DataBaseConnectionString{
			get{
				if(string.IsNullOrEmpty(this._databaseConnectionString)){
					this._databaseConnectionString = this.GetDataBaseConnection();
				}
				return this._databaseConnectionString;
			}
		}

		/// <summary>
		/// Gets the data base connection.
		/// </summary>
		/// <returns>The data base connection.</returns>
		private string GetDataBaseConnection(){
			var databaseConnectionStringNode = this._xmlDocument.GetElementsByTagName(this._databaseConnectionStringNodeName);
			return databaseConnectionStringNode.Count > 0 ? databaseConnectionStringNode[0].InnerText : "";
		}



	}
}

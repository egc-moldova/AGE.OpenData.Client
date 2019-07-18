using System.Web.Helpers;

namespace OpenDataManager
{
	class Program
	{
		static void Main(string[] args)
		{
			string uri = "http://testdate.gov.md/ckan/api/3/";
			string apiKey = "<INSERT-API-KEY-HERE>";
			AGE.OpenData.Client client = new AGE.OpenData.Client(uri, apiKey);

			// Create package if need.
			// Otherwise specify a package id were resource will be placed
			
			AGE.OpenData.Package package = new AGE.OpenData.Package();
			package.name = System.Guid.NewGuid().ToString();
			package.type = "dataset";
			package.url = "http://testdate.gov.md/ckan/dataset/" + package.name;

			string json = Json.Encode(package);
			System.Console.WriteLine("json = " + json);
			System.Console.WriteLine(client.package_create(json));

			// upload resource to server if need
			// create resource in package
		}
	}
}

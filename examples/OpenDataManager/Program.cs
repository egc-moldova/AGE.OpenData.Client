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
			AGE.OpenData.Package package = new AGE.OpenData.Package()
			{
				name = System.Guid.NewGuid().ToString(),
				type = "dataset",
				url = "http://testdate.gov.md/ckan/dataset/datasetname"
			};
			string json = Json.Encode(package);

			AGE.OpenData.PackageShow packageShow = Json.Decode<AGE.OpenData.PackageShow>(client.package_create(json));

			// upload resource to server if need
			// create resource in package
			if (packageShow.success)
			{
				AGE.OpenData.Resource resource = new AGE.OpenData.Resource
				{
					url = "http://google.com",
					package_id = packageShow.result.id
				};
				json = Json.Encode(resource);
				System.Console.WriteLine("result = " + client.resource_create(json));
			}
		}
	}
}

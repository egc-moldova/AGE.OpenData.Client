using System;
using Ckan;

namespace SimpleClient
{
	class Program
	{
		static void Main(string[] args)
		{
			string uri = "http://date.gov.md/ckan/api/3/";
			CkanClient client = new CkanClient(uri);
			// obtain names of first 10 packages
			Console.WriteLine(client.package_list(10));
		}
	}
}

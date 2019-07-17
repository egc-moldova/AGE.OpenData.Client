using System;
using System.Web.Helpers;

namespace YetAnotherClient
{
	class Program
	{
		static void Main(string[] args)
		{
			string uri = "http://date.gov.md/ckan/api/3/";
			AGE.OpenData.Client client = new AGE.OpenData.Client(uri);
			// obtain names of second 10 packages
			AGE.OpenData.PackageList packageList = Json.Decode<AGE.OpenData.PackageList>(client.package_list(10, 10));

			// if request was failed, show error message
			if (packageList.success == false)
			{
				Console.WriteLine("unknown error.");
				Console.WriteLine(packageList.help);
				return;
			}

			// show packages name
			foreach (var packageName in packageList.result)
			{
				Console.WriteLine("package name = " + packageName);
			}

			// show info about first selected package
			string package_name = "4784-date-statistice-privind-persoanele-anuntate-in-cautare-si-retinute-care-au-savirsit-infractiuni";
			AGE.OpenData.PackageShow package = Json.Decode<AGE.OpenData.PackageShow>(client.package_show(package_name));
			if (package.success == false)
			{
				Console.WriteLine("unknown error.");
				Console.WriteLine(package.help);
				return;
			}

			Console.WriteLine("package info:");
			Console.WriteLine("\tname:" + package.result.name);
			Console.WriteLine("\tmaintainer:" + package.result.maintainer);
			Console.WriteLine("\tpackage type:" + package.result.type);
			Console.WriteLine("\tresources:");
			foreach(var resource in package.result.resources)
			{
				Console.WriteLine("\t\tname: " + resource.name);
				Console.WriteLine("\t\tID: " + resource.id);
				Console.WriteLine("\t\ttype: " + resource.resource_type);
				Console.WriteLine("\t\tformat: " + resource.format);
				Console.WriteLine("\t\turl: " + resource.url);
				Console.WriteLine();
			}

		}
	}
}

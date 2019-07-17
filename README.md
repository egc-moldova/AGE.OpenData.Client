# AGE.OpenData.Client
## Description
C# client for date.gov.md

## Examples
Example of usage:
```c#
using System;
using Ckan;

namespace SimpleClient
{
	class Program
	{
		static void Main(string[] args)
		{
			// reference to CKAN service
			string uri = "http://date.gov.md/ckan/api/3/";
			Ckan.Client client = new Ckan.Client(uri);
			// obtain names of first 10 packages
			Console.WriteLine(client.package_list(10));
		}
	}
}
```

Common CKAN API is available on [CKAN project site](https://docs.ckan.org/en/latest/api/index.html#).

Ckan Client returns as responce JSON string. You can parse it:
```c#
string uri = "http://date.gov.md/ckan/api/3/";
Ckan.Client client = new Ckan.Client(uri);
// obtain names of second 10 packages
Ckan.PackageList packageList = Json.Decode<Ckan.PackageList>(client.package_list(10, 10));

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
Ckan.PackageShow package = Json.Decode<Ckan.PackageShow>(client.package_show(packageList.result[0]));
```
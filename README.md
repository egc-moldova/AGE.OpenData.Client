# AGE.OpenData.Client
## Description
C# client for [MDA Government Open Data](http://date.gov.md)
You can use any [CKAN](http://ckan.org) client as alternative.

## Examples
Example of usage:
```c#
static void Main(string[] args)
{
	// reference to service
	string uri = "http://date.gov.md/ckan/api/3/";
	AGE.OpenData.Client client = new AGE.OpenData.Client(uri);
	// obtain names of first 10 packages
	Console.WriteLine(client.package_list(10));
}
```

Common CKAN API is available on [CKAN project site](https://docs.ckan.org/en/latest/api/index.html#).

Ckan Client returns as responce JSON string. You can parse it:
```c#
static void Main(string[] args)
{
	string uri = "http://date.gov.md/ckan/api/3/";
	AGE.OpenData.Client client = new AGE.OpenData.Client(uri);
	// obtain names of second 10 packages
	AGE.OpenData.PackageList packageList = Json.Decode<AGE.OpenData.PackageList>(
		client.package_list(10, 10));

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
	AGE.OpenData.PackageShow package = Json.Decode<AGE.OpenData.PackageShow>(
		client.package_show(packageList.result[0]));
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
```
For data publishing first at all you need to have an API Key. It can be found in a profile of CKAN user (web page).
The scenario of data publishing is:
* create new dataset if need (new package of resources)
* identify dataset id were resource will be placed
* upload file to server (if need) 
* determine direct link to file
* create new resource into dataset

```c#
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

	AGE.OpenData.PackageShow packageShow = Json.Decode<AGE.OpenData.PackageShow>(
		client.package_create(json));

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
```

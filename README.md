# AGE.OpenData.Client
C# client for date.gov.md

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
			CkanClient client = new CkanClient(uri);
			// obtain names of first 10 packages
			Console.WriteLine(client.package_list(10));
		}
	}
}
```

Common CKAN API is available on [CKAN project site](https://docs.ckan.org/en/latest/api/index.html#).
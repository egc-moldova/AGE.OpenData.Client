using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AGE
{
	namespace OpenData
	{
		public class Client
		{
			//int api_version = 3;
			public string endpoint { get; set; }
			/// <summary>
			/// not implemented yet
			/// </summary>
			string authentication;
			private static readonly HttpClient client = new HttpClient();
			/// <summary>
			/// CKAN client constructor
			/// </summary>
			/// <param name="Endpoint"Reference to CKAN service</param>
			/// <param name="auth">Authentication key</param>
			public Client(string Endpoint, string auth = null)
			{
				endpoint = Endpoint;
				authentication = auth;
			}

			private string make_request(string method, string uri, string data = "")
			{
				Task<HttpResponseMessage> responseMesage = client.GetAsync(uri);
				Task<string> response = responseMesage.Result.Content.ReadAsStringAsync();
				return response.Result;
			}


			public bool site_read()
			{
				throw new NotImplementedException();
			}
			/// <summary>
			/// Return a list of the names of the site’s datasets (packages).
			/// </summary>
			/// <param name="limit">If given, the list of datasets will be broken into pages 
			/// of at most limit datasets per page and only one page will be returned at a time (optional)</param>
			/// <param name="offset">When limit is given, the offset to start returning packages from</param>
			/// <returns>List of strings.</returns>
			public string package_list(int limit = 20, int offset = 0)
			{
				return make_request("GET", endpoint + "action/package_list?limit=" + limit + "&offset=" + offset);
			}
			/// <summary>
			/// Return the metadata of a dataset (package) and its resources.
			/// </summary>
			/// <param name="id">The id or name of the dataset.</param>
			/// <returns>dictionary</returns>
			public string package_show(string id)
			{
				return make_request("GET", endpoint + "action/package_show?id=" + id);
			}
			/// <summary>
			/// Searches for packages satisfying a given search criteria. This action accepts solr search query 
			/// parameters, and returns a dictionary of results, including dictized datasets 
			/// that match the search criteria, a search count and also facet information.
			/// </summary>
			/// <see cref="https://docs.ckan.org/en/latest/api/index.html#ckan.logic.action.get.package_search"/>
			/// <param name="q"></param>
			/// <returns></returns>
			public string package_search(string q)
			{
				return make_request("GET", endpoint + "action/package_search?q=" + q);
			}
			/// <summary>
			/// Return the metadata of a resource.
			/// </summary>
			/// <param name="id">the id of the resource</param>
			/// <returns>dictionary</returns>
			public string resource_show(string id)
			{
				return make_request("GET", endpoint + "action/resource_show?id=" + id);
			}
			/// <summary>
			/// Searches for resources satisfying a given search criteria. It returns a dictionary 
			/// with 2 fields: <i>count</i> and <i>results</i>.The <i>count</i> field contains the total number of Resources 
			/// found without the limit or query parameters having an effect.The results field is a 
			/// list of dictized Resource objects.
			/// </summary>
			/// <param name="query">The search criteria. <see cref="https://docs.ckan.org/en/latest/api/index.html#ckan.logic.action.get.resource_search"/></param>
			/// <param name="offset">Apply an offset to the query.</param>
			/// <param name="limit">Apply a limit to the query.</param>
			/// <returns>A dictionary with a count field, and a results field.</returns>
			public string resource_search(string query, int offset, int limit)
			{
				throw new NotImplementedException();
			}
		}
	}
}

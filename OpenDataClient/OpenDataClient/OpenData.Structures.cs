using System;
using System.Collections.Generic;

namespace AGE
{
	namespace OpenData
	{
		public class TrackingSummary
		{
			public int total { get; set; }
			public int recent { get; set; }
		}

		public class Resource
		{
			public Resource()
			{
				//created = DateTime.Now;
			}
			public string package_id { get; set; }
			public string resource_group_id { get; set; }
			public DateTime? cache_last_updated { get; set; }
			public DateTime? revision_timestamp { get; set; }
			public DateTime? webstore_last_updated { get; set; }
			public bool datastore_active { get; set; }
			public string id { get; set; }
			public int? size { get; set; }
			public string date_from { get; set; }
			public string state { get; set; }
			public string hash { get; set; }
			public string description { get; set; }
			public string format { get; set; }
			public TrackingSummary tracking_summary { get; set; }
			public object last_modified { get; set; }
			public object url_type { get; set; }
			public string date_to { get; set; }
			public string mimetype { get; set; }
			public object cache_url { get; set; }
			public string name { get; set; }
			public DateTime? created { get; set; }
			public string url { get; set; }
			public object webstore_url { get; set; }
			public object mimetype_inner { get; set; }
			public int position { get; set; }
			public string revision_id { get; set; }
			public string resource_type { get; set; }
		}

		public class Tag
		{
			public object vocabulary_id { get; set; }
			public string display_name { get; set; }
			public string name { get; set; }
			public DateTime revision_timestamp { get; set; }
			public string state { get; set; }
			public string id { get; set; }
		}

		public class TrackingSummary2
		{
			public int total { get; set; }
			public int recent { get; set; }
		}

		public class Group
		{
			public string display_name { get; set; }
			public string description { get; set; }
			public string image_display_url { get; set; }
			public string title { get; set; }
			public string id { get; set; }
			public string name { get; set; }
		}

		public class Organization
		{
			public string description { get; set; }
			public DateTime created { get; set; }
			public string title { get; set; }
			public string name { get; set; }
			public DateTime revision_timestamp { get; set; }
			public bool is_organization { get; set; }
			public string state { get; set; }
			public string image_url { get; set; }
			public string revision_id { get; set; }
			public string type { get; set; }
			public string id { get; set; }
			public string approval_status { get; set; }
		}

		public class Extra
		{
			public string key { get; set; }
			public string value { get; set; }
		}

		public class Package
		{
			public Package()
			{
				groups = new System.Collections.Generic.List<AGE.OpenData.Group>();
				relationships_as_object = new System.Collections.Generic.List<object>();
				relationships_as_subject = new System.Collections.Generic.List<object>();
				resources = new System.Collections.Generic.List<AGE.OpenData.Resource>();
				extras = new System.Collections.Generic.List<AGE.OpenData.Extra>();
				tags = new System.Collections.Generic.List<AGE.OpenData.Tag>();
				type = "dataset";
				@private = false;
				isopen = true;
			}
			public string license_title { get; set; }
			public string maintainer { get; set; }
			public List<object> relationships_as_object { get; set; }
			public bool @private { get; set; }
			public string maintainer_email { get; set; }
			public DateTime? revision_timestamp { get; set; }
			public string id { get; set; }
			public DateTime? metadata_created { get; set; }
			public DateTime? metadata_modified { get; set; }
			public string author { get; set; }
			public object author_email { get; set; }
			public string state { get; set; }
			public object version { get; set; }
			public string creator_user_id { get; set; }
			public string type { get; set; }
			public List<Resource> resources { get; set; }
			public int num_resources { get; set; }
			public List<Tag> tags { get; set; }
			public TrackingSummary2 tracking_summary { get; set; }
			public List<Group> groups { get; set; }
			public string license_id { get; set; }
			public List<object> relationships_as_subject { get; set; }
			public int? num_tags { get; set; }
			public Organization organization { get; set; }
			public string name { get; set; }
			public bool isopen { get; set; }
			public string url { get; set; }
			public string notes { get; set; }
			public string owner_org { get; set; }
			public List<Extra> extras { get; set; }
			public string title { get; set; }
			public string revision_id { get; set; }
		}

		public class PackageShow
		{
			public string help { get; set; }
			public bool success { get; set; }
			public Package result { get; set; }
		}

		public class PackageList
		{
			public string help { get; set; }
			public bool success { get; set; }
			public List<string> result { get; set; }
		}

		public class ResourceShow
		{
			public string help { get; set; }
			public bool success { get; set; }
			public Resource result { get; set; }
		}
	}
}

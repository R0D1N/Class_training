using System;

namespace Class_training
{
	class Diploma
	{
		string orgName;
		public string OrgName
		{
			get
			{
				return orgName;
			}
			set
			{
				orgName = value;
			}
		}

		string qualifications;
		public string Qualifications
		{
			get
			{
				return qualifications;
			}
			set
			{
				qualifications = value;
			}
		}

		DateTime diplomeDateTime;
		public DateTime DiplomeDateTime
		{
			get
			{
				return diplomeDateTime;
			}
			set
			{
				diplomeDateTime = value;
			}
		}

		public Diploma(string orgName, string qualifications, DateTime diplomeDateTime)
		{
			this.orgName = orgName;
			this.qualifications = qualifications;
			this.diplomeDateTime = diplomeDateTime;
		}

		public Diploma()
		{
			orgName = "DNU";
			qualifications = "Tester";
			diplomeDateTime = DateTime.Now;
		}
	}

	class Doctor
	{
		Person()
		{

		}
	}

	class Program
	{
		static void Main()
		{
			
		}
	}

	enum Category { High, First, Second }
}
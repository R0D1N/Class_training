using System;

namespace Class_training
{

	class Person
	{
		private string name;
		private string surname;
		private System.DateTime bornDate;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string Surname
		{
			get { return surname; }
			set { surname = value; }
		}

		public System.DateTime BornDate
		{
			get { return bornDate; }
			set { bornDate = value; }
		}

		public int ChangeBornDate
		{
			get { return Convert.ToInt32(bornDate); }
			set { bornDate = Convert.ToDateTime(value); }
		}

		public Person (string name, string surname, System.DateTime bornDate)
		{
			this.name = name;
			this.surname = surname;
			this.bornDate = bornDate;
		}

		public Person()
		{
			name = "DefaultName";
			surname = "DefaultSurname";
			bornDate = DateTime.UtcNow;
		}

		public override string ToString()
		{
			return string.Format("name -  ім'я" +
				"surname -  прізвище" +
				"bornDate - датa народження");
		}
		public string ToShortString()
		{
			return name + " " + surname;
		}
	}

	class Diploma
	{

		public string orgName { get; set; }

		public string qualifications { get; set; }

		public DateTime diplomeDateTime { get; set; }
		


		public Diploma(string orgName, string qualifications, DateTime diplomeDateTime)
		{
			this.orgName = orgName;
			this.qualifications = qualifications;
			this.diplomeDateTime = diplomeDateTime;
		}

		public Diploma()
		{
			orgName = "DNU";
			qualifications = "default";
			diplomeDateTime = DateTime.UtcNow;
		}

		public override string ToString()
		{
			return string.Format("orgName - назвa організації, яка видала диплом (сертифікат)," +
				" qualifications -  отриманa кваліфікація," +
				" diplomeDateTime - датa видачі диплома ");
		}
	}



	class Doctor
	{
		private Person personalInformation { get; set; }

		private string specifacation { get; set; }

		private Category category { get; set; }

		private int workTime { get; set; }

		private Diploma aboutDiploma { get; set; }


		public Doctor(Person personalInformation, string specifacation, Category category, int workTime, Diploma aboutDiploma)
		{
			this.personalInformation = personalInformation;
			this.specifacation = specifacation;
			this.category = category;
			this.workTime = workTime;
			this.aboutDiploma = aboutDiploma;
		}

		public Doctor()
		{
			personalInformation = new Person();
			specifacation = "default";
			category = Category.High;
			workTime = 99;
			aboutDiploma = new Diploma();
		}


		//public Diploma getFirstDiploma
		//{
		//	get
		//	{
		//		if (true)
		//		{

		//		}
		//	}	
		//}

		//public void AddDiplomas(params Diploma[])
		//{

		//}

		public override string ToString()
		{
			return string.Format("personalInformation - данні лікаря," +
				"specifacation - спеціальність," +
				"category - категорія лікаря," +
				"workTime - стаж" +
				"aboutDiploma - поля зі списком дипломів і сертифікатів");
		}

		public string ToShortString()
		{
			return personalInformation + " " + specifacation + " " + category + " " + workTime + " " + aboutDiploma;
		}

	}




	class Program
	{
		static void Main()
		{
			Diploma diplomaDefault = new Diploma();
			Console.WriteLine(diplomaDefault.ToString());

			diplomaDefault.orgName = "KNU";
			diplomaDefault.qualifications = "magistr";
			diplomaDefault.diplomeDateTime = DateTime.Today;

			Doctor doctorSpec = new Doctor();
		}
	}

	enum Category { High, First, Second }
}
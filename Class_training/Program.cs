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
			return string.Format($"{name} -  имя \n" +
				$"{surname} -  фамилия \n" +
				$"{bornDate} - датa народження \n");
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
			return string.Format($"{orgName} - назвa організації, яка видала диплом (сертифікат) \n" +
				$"{qualifications} -  отриманa кваліфікація \n" +
				$"{diplomeDateTime} - датa видачі диплома \n ");
		}
	}

	class Doctor
	{
		private Person personalInformation;
		private string specifacation;
		private Category category;
		private int workTime;
		private Diploma[] aboutDiploma;


		public Person PersonalInformation
		{
			get { return personalInformation; }
			set { personalInformation = value; }
		}

		public string Specifacation
		{
			get { return specifacation; }
			set { specifacation = value; }
		}

		public Category Category
		{
			get { return category; }
			set { category = value; }
		}
		
		public int WorkTime
		{
			get { return workTime; }
			set { workTime = value; }
		}

		public Diploma[] AboutDiploma 
		{
			get { return aboutDiploma; }
			set { aboutDiploma = value; }
		}

		
		public Doctor(Person personalInformation, string specifacation, Category category, int workTime)
		{
			this.personalInformation = personalInformation;
			this.specifacation = specifacation;
			this.category = category;
			this.workTime = workTime;
			aboutDiploma = new Diploma[0];
		}

		public Doctor()
		{
			personalInformation = new Person();
			specifacation = "default";
			category = Category.High;
			workTime = 99;
			aboutDiploma = new Diploma[0];
		}


		public Diploma getFirstDiploma
		{
			get
			{
				System.DateTime firstDiplom = aboutDiploma[0].diplomeDateTime;
				for (int i = 0; i < aboutDiploma.Length; i++)
				{
					firstDiplom = 
				}
				return firstDiplom;
			}	
		}

		public void AddDiplomas(params Diploma[] aboutDiploma)
		{
			int len = this.aboutDiploma.Length + aboutDiploma.Length;
			int oldLen = this.aboutDiploma.Length; 

			Array.Resize(ref this.aboutDiploma, len);

			for (int i = 0; i < aboutDiploma.Length; i++)
			{
				this.aboutDiploma[oldLen + i] = aboutDiploma[i];
			}
		}

		public override string ToString()
		{
			for (int i = 0; i < aboutDiploma.Length /2; i++)
			{
				Console.WriteLine(aboutDiploma[i].ToString());
			}
			return string.Format($"{personalInformation} - данные врача \n" +
				$"{specifacation} - специальность \n" +
				$"{category} - категория врача \n" +
				$"{workTime} - стаж \n");
		}

		public string ToShortString()
		{
			return string.Format($"{personalInformation} - данные врача \n" +
				$"{specifacation} - специальность \n" +
				$"{category} - категория врача \n" +
				$"{workTime} - стаж \n");
		}

	}



	class Program
	{
		static void Main()
		{
			Doctor doctor = new Doctor();
			doctor.ToString();

			doctor.PersonalInformation = new Person("Kyrylo", "Rodin", new DateTime(20002, 08, 17));
			doctor.Specifacation = "NoneDefault";
			doctor.Category = Category.First;
			doctor.WorkTime = 15;
			doctor.AboutDiploma = new Diploma[0];

			doctor.ToShortString();

			Doctor doctor2 = new Doctor()

		}
	}

	enum Category { High, First, Second }
}
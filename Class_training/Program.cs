using System;
using System.Diagnostics;

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
			get { return bornDate.Year; }
			set
			{
				DateTime bornYear = new DateTime(value, bornDate.Month, bornDate.Day);
				bornDate = bornYear; 
			}
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
		public virtual string ToShortString()
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
			return string.Format($"{orgName} - назвaние организации, которая видала диплом (сертификат) \n" +
				$"{qualifications} -  полученая квалификация\n" +
				$"{diplomeDateTime} - датa получения диплома \n ");
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
				if (aboutDiploma == null)
				{
					System.DateTime firstDiplom = aboutDiploma[0].diplomeDateTime;
					int iMin = 0;
					for (int i = 0; i < aboutDiploma.Length; i++)
					{
						if (firstDiplom > aboutDiploma[i].diplomeDateTime)
						{
							firstDiplom = aboutDiploma[i].diplomeDateTime;
							iMin = i;
						}
					}
					return aboutDiploma[iMin];
				}
				else
					return null;
				
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
			return string.Format($"{personalInformation} - данные врача \n" +
				$"{specifacation} - специальность \n" +
				$"{category} - категория врача \n" +
				$"{workTime} - стаж \n");
		}

		public string ToShortString()
		{
			return string.Format($"{personalInformation}\n" +
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

			doctor.PersonalInformation = new Person("Kyrylo", "Rodin", new DateTime(2002, 08, 17));
			doctor.Specifacation = "NoneDefault";
			doctor.Category = Category.First;
			doctor.WorkTime = 15;
			doctor.AboutDiploma = new Diploma[0];

			Console.WriteLine(doctor.ToShortString()); 

			Doctor doctor2 = new Doctor(new Person(), "someSpec", Category.Second, 500);
			Console.WriteLine(doctor2.ToString());

			doctor2.AddDiplomas(new Diploma(), new Diploma("Univer", "Qvaul", new DateTime(2002, 2, 4)));
			Console.WriteLine(doctor2.ToString());

			Console.WriteLine(doctor2.getFirstDiploma);



			
			Console.WriteLine("Введите количество строк и столбцов через * ");
			string temp = Console.ReadLine();

			string[] number = temp.Split('*');

			int nrow = int.Parse(number[0]);
			int ncolumn = int.Parse(number[1]);

			Stopwatch stopWatch = new Stopwatch();

			
			Diploma[] array_1 = new Diploma[nrow * ncolumn];
			Diploma[,] array_2 = new Diploma[nrow, ncolumn];
			Diploma[][] array_3 = new Diploma[nrow][];
			for (int i = 0; i < nrow; i++)
			{
				array_3[i] = new Diploma[ncolumn];
				
			}


			stopWatch.Start();
			for (int i = 0; i < nrow * ncolumn; i++)
			{
				array_1[i] = new Diploma();
			}
			Console.WriteLine("Времени потрачано (одномерный) (мс) : " + stopWatch.ElapsedMilliseconds);
			long time = stopWatch.ElapsedMilliseconds;


			for (int i = 0; i < nrow; i++)
			{
				for (int j = 0; j < ncolumn; j++)
				{
					array_2[i, j] = new Diploma();
				}
			}
			long nextTimeOperation = stopWatch.ElapsedMilliseconds - time;
			Console.WriteLine("Времени потрачано (двумерный) (мс) : " + nextTimeOperation);



			for (int i = 0; i < nrow; i++)
			{
				for (int j = 0; j < ncolumn; j++)
				{
					array_3[i][j] = new Diploma();
				}
			}
			Console.WriteLine("Времени потрачано (зубчастый) (мс) : " + nextTimeOperation);

		}
	}

	enum Category { High, First, Second }
}
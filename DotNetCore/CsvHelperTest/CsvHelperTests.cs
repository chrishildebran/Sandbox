namespace DotNetCore.CsvHelperTest;

using System.Globalization;

using CsvHelper;

public class CsvHelperTests
{

	#region Methods

	public void ObjectWithListOfObjects()
	{
		// https: //stackoverflow.com/questions/59015885/csvhelper-create-a-classmapclassa-that-contains-a-property-as-list-items-to-wr#:~:text=CsvHelper%20create%20a%20ClassMap%3CClassA%3E%20that%20contains%20a%20property,Ask%20Question%20Asked%203%20years%2C%201%20month%20ago
		var records = new List<ClassA>
		{
			new()
			{
				Id   = 1,
				Name = "Chris",
				PropertyBs = new List<ClassB>
				{
					new()
					{
						PropertyD = "N",
						PropertyE = "H"
					},
					new()
					{
						PropertyD = "G",
						PropertyE = "J"
					}
				}
			},
			new()
			{
				Id   = 2,
				Name = "Christi",
				PropertyBs = new List<ClassB>
				{
					new()
					{
						PropertyD = "Y",
						PropertyE = "T"
					}
				}
			}
		};

		using (var csv = new CsvWriter(Console.Out, CultureInfo.InvariantCulture))

		{
			csv.Context.RegisterClassMap<ClassBMap>();

			csv.WriteHeader<ClassA>();
			csv.WriteHeader<ClassB>();
			csv.NextRecord();

			foreach (var record in records)
			{
				foreach (var item in record.PropertyBs)
				{
					csv.WriteRecord(record);
					csv.WriteRecord(item);
					csv.NextRecord();
				}
			}
		}

		Console.ReadKey();
	}

	#endregion

}
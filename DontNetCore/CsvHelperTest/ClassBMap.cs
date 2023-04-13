namespace TestingDotNetCore.CsvHelperTest;

using CsvHelper.Configuration;

public class ClassBMap : ClassMap<ClassB>
{

	#region Constructors

	private ClassBMap()
	{
		this.Map(m => m.PropertyE)
		    .Name("ClassB.PropertyE");

		this.Map(m => m.PropertyD)
		    .Name("ClassB.PropertyD");
	}

	#endregion

}

public class ClassAMap : ClassMap<ClassA>
{

	#region Constructors

	private ClassAMap()
	{
		this.Map(m => m.Name)
		    .Name("Name");

		this.Map(m => m.Id)
		    .Name("Id");
	}

	#endregion

}
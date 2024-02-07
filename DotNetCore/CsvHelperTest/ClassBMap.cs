namespace DotNetCore.CsvHelperTest;

using CsvHelper.Configuration;

public class ClassBMap : ClassMap<ClassB>
{

	private ClassBMap()
	{
		this.Map(m => m.PropertyE).Name("ClassB.PropertyE");

		this.Map(m => m.PropertyD).Name("ClassB.PropertyD");
	}

}

public class ClassAMap : ClassMap<ClassA>
{

	private ClassAMap()
	{
		this.Map(m => m.Name).Name("Name");

		this.Map(m => m.Id).Name("Id");
	}

}
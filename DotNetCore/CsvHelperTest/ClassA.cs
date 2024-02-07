namespace DotNetCore.CsvHelperTest;

public class ClassA
{

	public ClassA()
	{
		this.PropertyBs = new List<ClassB>();
	}

	public int Id{get;set;}

	public string Name{get;set;}

	public List<ClassB> PropertyBs{get;init;}

}
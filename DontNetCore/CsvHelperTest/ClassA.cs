namespace TestingDotNetCore.CsvHelperTest;

public class ClassA
{

    #region Constructors

    public ClassA()
    {
        this.PropertyBs = new List<ClassB>();
    }

    #endregion

    #region Properties



    public string Name { get; set; }
    public int Id { get; set; }
    public List<ClassB> PropertyBs { get; init; }

    #endregion

}
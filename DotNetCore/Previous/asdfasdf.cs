namespace DotNetCore.Previous;

using System.Collections;
using System.Reflection;

public class asdfasdf
{

    #region Constructors

    public asdfasdf()
    {
        this.Def1 = new ExternalParameterDefinitions();
        this.Def2 = new ExternalParameterDefinitions();
        this.Def3 = new ExternalParameterDefinitions();
        this.Def4 = new ExternalParameterDefinitions();
        this.Def5 = new ExternalParameterDefinitions();
        this.Def6 = new ExternalParameterDefinitions();
        this.Def7 = new ExternalParameterDefinitions();

        this.Def1.DefinitionName = "Alpha";
        this.Def2.DefinitionName = "Bravo";
        this.Def3.DefinitionName = "Charlie";
        this.Def4.DefinitionName = "Delta";
        this.Def5.DefinitionName = "Echo";
        this.Def6.DefinitionName = "Foxtrot";
        this.Def7.DefinitionName = "Golf";
    }

    #endregion

    #region Properties

    public ExternalParameterDefinitions Def1 { get; set; }

    public ExternalParameterDefinitions Def2 { get; set; }

    public ExternalParameterDefinitions Def3 { get; set; }

    public ExternalParameterDefinitions Def4 { get; set; }

    public ExternalParameterDefinitions Def5 { get; set; }

    public ExternalParameterDefinitions Def6 { get; set; }

    public ExternalParameterDefinitions Def7 { get; set; }

    public string name { get; set; }

    public int number { get; set; }

    #endregion

    #region Methods

    public void GetPropertyValues()
    {
        var t = this.GetType();
        Console.WriteLine("Type is: {0}", t.Name);
        var props = t.GetProperties();
        Console.WriteLine("Properties (N = {0}):", props.Length);

        foreach (var prop in props)
        {
            if (prop.GetIndexParameters()
                    .Length ==
                0)
            {
                Console.WriteLine("   {0} ({1}): {2}", prop.Name, prop.PropertyType.Name, prop.GetValue(this));
            }
            else
            {
                Console.WriteLine("   {0} ({1}): <Indexed>", prop.Name, prop.PropertyType.Name);
            }
        }
    }


    public void MethodName()
    {
        var propertyInfos = this.GetType()
                                .GetProperties()
                                .Where(t => t.PropertyType == typeof(ExternalParameterDefinitions));

        foreach (var propertyInfo in propertyInfos)
        {
            var propertyName = propertyInfo.Name;
            var propertyValue = propertyInfo.GetValue(this);

            var propertyType = propertyInfo.PropertyType;

            //Console.WriteLine($"{propertyName}={propertyValue}  |  Member Type={propertyType}\n");
            Console.WriteLine($"{propertyName}={propertyValue}\n");
        }
    }


    public void PerformReflectionOnPOCO(object o)
    {
        // https://gist.github.com/DeveloperUniversity/3adf12e6f9ad774d857a0dc26d9193ef
        PropertyInfo[] propertyInfos = null;

        propertyInfos = o.GetType()
                         .GetProperties();

        // PropertyInfo = metadata about the property
        // propertyInfo.GetType() = retrieves the actual data type
        // PropertyValue = the actual value the property is holding

        foreach (var propertyInfo in propertyInfos)
        {
            var propertyValue = propertyInfo.GetValue(o);

            // Is the item a value property
            if (propertyInfo.PropertyType == typeof(string))
            {
                Console.WriteLine($"STRING PROPERTY = {propertyInfo.Name} - {propertyValue}");
            }

            if (propertyInfo.PropertyType == typeof(DateTime))
            {
                Console.WriteLine($"DATE PROPERTY = {propertyInfo.Name} - {propertyValue}");
            }

            Console.WriteLine("");

            // Is the item a reference property?
            if (propertyInfo.GetType()
                            .IsClass &&
                !(propertyValue is IEnumerable) &&
                !(propertyInfo.PropertyType == typeof(DateTime)) &&
                !propertyInfo.PropertyType.IsEnum)
            {
                Console.WriteLine($"REFERENCE PROPERTY = {propertyInfo.Name} is of type {propertyValue}");
                Console.WriteLine($"   This instance of {propertyValue} has the following properties and values:");

                var properties = propertyValue.GetType()
                                              .GetProperties();

                foreach (var property in properties)
                {
                    Console.WriteLine($"      {property.Name} = {property.GetValue(propertyValue)}");
                }

                Console.WriteLine("");
            }

            if (propertyInfo.PropertyType.IsEnum)
            {
                Console.WriteLine($"ENUM PROPERTY = {propertyInfo.Name} - {propertyValue}");
                Console.WriteLine("");
            }

            if (propertyInfo.GetType()
                            .IsClass &&
                propertyValue is IEnumerable &&
                !(propertyValue is string))
            {
                // Is the item a generic collection?
                if (propertyValue.GetType()
                                 .Name ==
                    "List`1")
                {
                    Console.WriteLine($"LIST<T> PROPERTY - {propertyInfo.Name} is a List<{propertyValue.GetType().GenericTypeArguments[0].Name}>");
                    Console.WriteLine("");

                    foreach (object listItem in propertyValue as IEnumerable)
                    {
                        Console.WriteLine($"   This instance of {listItem.GetType().Name} has the following properties and values:");

                        // How can I get the VALUE of this property?
                        //Console.WriteLine("-- Name Property holds value: " + listitem.Name);

                        var properties = listItem.GetType()
                                                 .GetProperties();

                        foreach (var property in properties)
                        {
                            Console.WriteLine($"      {property.Name} = {property.GetValue(listItem)}");
                        }

                        Console.WriteLine("");
                    }
                }
            }
        }

        Console.WriteLine("Finished reflecting ...");
    }

    #endregion

}
namespace DotNetCore.DataMapperTEst;

public class Customer
{

	public Customer(int id, string name, bool isPremiumMember)
	{
		this.ID              = id;
		this.Name            = name;
		this.IsPremiumMember = isPremiumMember;
	}

	public int ID{get;set;}

	public bool IsPremiumMember{get;set;}

	public string Name{get;set;}

}
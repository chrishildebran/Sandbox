// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
// Company:...... J.H. Kelly
// Department:... Virtual Construction Services
// Website:...... http://www.jhkelly.com
// Solution:..... Sandbox
// Project:...... DotNetCore
// File:......... Customer.cs ✓✓
// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

namespace DesignPatternDemos.DataMapper;

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
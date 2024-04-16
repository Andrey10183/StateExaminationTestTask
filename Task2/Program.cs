using System.Reflection;
using Task2;

Type abstractType = typeof(Cat);

// Find a derived type 
Type derivedType = Assembly
    .GetExecutingAssembly()
    .GetTypes()
    .FirstOrDefault(t => t.IsSubclassOf(abstractType))!;

//This way you can get some field name info
FieldInfo nameFieldInfo = typeof(Cat).GetField("name", BindingFlags.Instance | BindingFlags.Public)!;

//Can't create abstract class - the only way to create derived class that is not abstract
//And cast it to base abstract class
Cat instance = (Cat)Activator.CreateInstance(derivedType)!;

//Here with this field you can set value to field
nameFieldInfo.SetValue(instance, "Fluffy");


Console.WriteLine($"Age field: {instance.age}");
Console.WriteLine($"Age tail count: {instance.tailCount}");
Console.WriteLine($"Age name: {instance.name}");


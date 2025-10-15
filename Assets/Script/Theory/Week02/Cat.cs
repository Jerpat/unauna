using UnityEngine;

public class Cat : Animal
{
    public string slave; // §«“¡§¡¢Õß‡≈Á∫·¡«
    public Cat(string name, int age, string slave) : base(name, age)
    {
        Debug.Log($"A new cat named {Name} was created.");
        this.slave = slave;
        Debug.Log($"My slave is {slave}");
    }
    public void Scratch(string target)
    {
        Debug.Log($"{Name} is scratching! {target}");
    }
    public override void MakeSound()
    {
        Debug.Log($"{Name} says Meow!");
    }
    
}

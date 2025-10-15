using UnityEngine;

public class Dog : Animal
{
    public string boss;
    public Dog(string name, int age, string boss) : base(name, age)
    {
        Debug.Log($"A new dog named {Name} was created.");
        this.boss = boss;
        Debug.Log($"My boss is {boss}");
    }
    public void Smell(string target)
    {
        Debug.Log($"{Name} is smell! {target}");
    }
    public override void MakeSound()
    {
        Debug.Log($"{Name} says Woof!");
    }
}

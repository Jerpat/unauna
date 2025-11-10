using UnityEngine;

public class AnimalGenerator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animal animal = new Animal("Generic Animal", 3);
        animal.Eat("grass");
        animal.MakeSound();

        Dog dog = new Dog("Bo", 5, "Boy");
        dog.Eat("dog food");
        dog.MakeSound();
        dog.Smell("sock");

        Cat cat = new("som",3,"Joy");
        cat.Eat("cat food");
        cat.MakeSound();
        cat.Scratch("couch");

    }
    
}

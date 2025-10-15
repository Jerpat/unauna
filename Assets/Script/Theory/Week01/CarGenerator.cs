using UnityEngine;

public class CarGenerator : MonoBehaviour
{
    public GameObject carPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject g = Instantiate(carPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Car tempDataCar = new Car("Toyota", Color.black, 3);
        Car myCar = g.GetComponent<Car>();
        myCar.Initialize(tempDataCar);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public string CarName;
    public Color CarColor;
    public float CarSpeed;

    public void Start()
    {
        SetUpCar();
    }

    public void SetUpCar()
    {
        gameObject.name = CarName;
        GetComponent<Renderer>().material.color = CarColor;
    }

    public Car() {
        CarName = "MyCar";
        CarColor = Color.red;
        CarSpeed = 1.0f;
        Debug.Log("Default car was be created.");
    }
    public Car(string _name,Color _color, float _speed)
    {
        CarName = _name;
        CarColor = _color;
        CarSpeed = _speed;
        Debug.Log($"custom car was be created name {CarName} color {CarColor} speed {CarSpeed}.");
    }
    public void Initialize(Car _classCar)
    {
        CarName = _classCar.CarName;
        CarColor = _classCar.CarColor;
        CarSpeed = _classCar.CarSpeed;

        SetUpCar();
        Debug.Log($"custom car was be Initialize name {CarName} color {CarColor} speed {CarSpeed}.");

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveForward();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Horn();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Turn();
        }
    }
    public void MoveForward() {
        transform.position += transform.forward * CarSpeed;
        Debug.Log(CarName + " is position " + transform.position);
    }
    public void Horn()
    {
        Debug.Log(CarName + " : horn");
    }
    public void Turn() {
        transform.Rotate(0, 45, 0);
        Debug.Log(CarName + " is rotation " + transform.rotation);
    }
}

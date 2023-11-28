using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverMonoBehavior : MonoBehaviour{

    // SPEEDS ARE EXPRESSED IN [km/h]
    
    public List<GameObject> carsObj;

    private float speed;
    private World world;

    private void contractCar(CarMonoBehaviour car){

        float car_length = car.getLength();

        float car_speed = this.world.getRelativeSpeed(
        
            this.speed,
            car.getSpeed()
        
        );

        var contr_param = this.world.contractSpace(
        
            car_speed,
            car_length
            
        );

        car.setScale(contr_param.scale);
        car.setShift(contr_param.shift);

    }

    void Start(){
        
        this.speed = 0;
        this.world = new World();

        CarMonoBehaviour car;

        foreach (GameObject car_obj in this.carsObj){

            car = car_obj.GetComponent<CarMonoBehaviour>();
            this.contractCar(car);

        }

    }

    void Update(){

        // transform.Translate(this.velocity * Time.deltaTime, Space.World);
        
    }
}

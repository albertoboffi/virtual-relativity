using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverMonoBehavior : MonoBehaviour{

    public List<GameObject> cars;

    void Start(){

        // CONSTRUCTOR

        NYC.World.addObject(this, 0.0f); // approximation of the observer as static

        // STARTING ROUTINE

        CarMonoBehaviour car;

        foreach (GameObject car_obj in this.cars){

            car = car_obj.GetComponent<CarMonoBehaviour>();
            NYC.World.contractSpace(this, car);

        }

    }

}

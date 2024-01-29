using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObserverMonoBehavior : MonoBehaviour{

    public List<GameObject> cars;

    void Start(){

        // CONSTRUCTOR

        NYC.World.addObject(this, 0.0f); // approximation of the observer as static

    }

    void Update(){

        CarMonoBehaviour car;

        foreach (GameObject car_obj in this.cars){

            car = car_obj.GetComponent<CarMonoBehaviour>();
            NYC.World.contractSpace(this, car);

        }

    }

}

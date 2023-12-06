using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMonoBehaviour : MonoBehaviour{

    // SPEEDS ARE EXPRESSED IN [km/h]

    private int carsCount;

    // car's information

    public int ID; // id of each individual car

    private float speed; // speed relative to the world
    private Vector3 direction; // direction of motion
    private float waitingTime; // car current waiting time before start

    public CarMonoBehaviour(){

        this.carsCount = 7;

        this.speed = 35.0f;
        this.direction = new Vector3(1, 0, 0); // cars move along the x-direction in the world space
        this.waitingTime = 0.0f;

    }

    void Start(){
        
        // set starting position

        float start_queue = 154.0f; // x-coordinate of the start of the queue
        float cars_distance = 9.5f; // distance between each car along the x-axis

        float car_order = (this.carsCount - 1) - this.ID; // cars are arrenged in ascending order of their ID

        float x_pos = start_queue + cars_distance * car_order; // cars are ordered by their id

        this.transform.position = new Vector3(
            
            x_pos,
            40.3f,
            -54.5f
        
        );

    }

    void Update(){

        float cars_delay = 6.0f; // delay between each car
        float starting_time = cars_delay * this.ID; // cars start in order of their id

        Vector3 velocity = this.speed * this.direction;

        if (this.waitingTime < starting_time){ // wait to start until it's your turn

            this.waitingTime += Time.deltaTime;

        }

        else{   // move when it's your turn

            this.transform.Translate(
            
                velocity * Time.deltaTime,
                Space.World

            );

        }
        
    }

    public void setScale(float scale){

        // the contraction happens in local coordinates, i.e. along the z-axis
        // the scaling factor takes into consideration previous scaling of the object

        this.transform.localScale = Vector3.Scale(
        
            this.transform.localScale,
            new Vector3(1, 1, scale)

        );

    }

    public void setShift(float shift){

        Vector3 adjustment = shift * this.direction * (-1); // the shift is in the opposite direction to the motion
        
        this.transform.Translate(
            
            adjustment,
            Space.World
        
        );

    }

    public float getSpeed(){
        
        return this.speed;

    }

    public float getLength(){

        MeshRenderer renderer = this.GetComponent<MeshRenderer>();
        Vector3 size = renderer.bounds.size;

        // the bounds are measured in world space, so the length is taken along the x-axis
        return size.x;

    }
}

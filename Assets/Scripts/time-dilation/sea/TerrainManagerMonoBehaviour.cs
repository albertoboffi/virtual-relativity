using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManagerMonoBehaviour : MonoBehaviour{
    
    /*

    public GameObject seedObj;          // basic GameObject of the terrain

    private List<GameObject> terrains;
    private int currTerrIdx;               // id of the current terrain

    private void addTerrain(GameObject old_terrain){

        Vector3 displacement = new Vector3(400, 0, 0);

        GameObject new_terrain = Instantiate(old_terrain);
        new_terrain.transform.position = old_terrain.transform.position + displacement;

        if (this.currTerrIdx > 0) new_terrain.transform.position -= new Vector3(2, 0, 0);

        new_terrain.transform.localScale = Vector3.Scale(
    
            old_terrain.transform.localScale,
            new Vector3(-1, 1, 1)

        );

        this.terrains.Add(new_terrain);
        this.currTerrIdx += 1;

    }

    void Start(){

        this.terrains =  new List<GameObject>{};
        this.terrains.Add(this.seedObj);

        this.currTerrIdx = 0;

        this.addTerrain(seedObj);

    }

    void Update(){
        
        GameObject curr_terrain = this.terrains[this.currTerrIdx];

        float pos = curr_terrain.transform.position.x;
        
        if (pos <= 0){
    
            if (this.currTerrIdx > 0) Destroy(this.terrains[this.currTerrIdx - 1]);
            this.addTerrain(curr_terrain);

        }

    }

    */
}

using UnityEngine;

public class SCProbe{
    
    private static World world = new World(45.0f);

    public static World World{

        get { return world; }
        set { world = value; }
    
    }

}
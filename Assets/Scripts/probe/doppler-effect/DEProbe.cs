using UnityEngine;

public class DEProbe{
    
    private static World world = new World(350.0f);

    public static World World{

        get { return world; }
        set { world = value; }
    
    }

}
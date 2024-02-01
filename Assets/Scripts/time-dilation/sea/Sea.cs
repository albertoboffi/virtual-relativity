using UnityEngine;

public class Sea{
    
    private static World world = new World(25.0f);

    public static World World{

        get { return world; }
        set { world = value; }
    
    }

}
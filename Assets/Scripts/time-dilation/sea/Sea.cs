using UnityEngine;

public class Sea{
    
    private static World world = new World(35.5f);

    public static World World{

        get { return world; }
        set { world = value; }
    
    }

}
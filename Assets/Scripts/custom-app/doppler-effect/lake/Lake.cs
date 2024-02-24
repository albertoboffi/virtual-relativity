using UnityEngine;

public class Lake{
    
    private static World world = new World(350f);

    public static World World{

        get { return world; }
        set { world = value; }
    
    }

}
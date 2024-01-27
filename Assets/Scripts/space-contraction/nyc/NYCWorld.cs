using UnityEngine;

public class NYCWorld{
    
    private static World nyc_world = new World(45.0f);

    public static World NYCWorld{

        get { return nyc_world; }
        set { nyc_world = value; }
    
    }

}
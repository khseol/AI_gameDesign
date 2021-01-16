using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBurst : MonoBehaviour
{
    //the script is to help have each explosion prefab have an independent timer when they are instantiated.
    //this script will also help in realizing the appropriate formation of when the breaker sets off:
    //in accordance to game objects with specific tags, explosion will essentially do the same thing of NOT HAVING A 
    //PREFAB INSTANTIATED OR SHOW ON THE WHEN THE PREFAB COLLIDES WITH A GAME OBJECT OF CERTAIN TAGS

    public float countdown; //left so that the timing can be changed in the inspector
    
    void Update()
    {
       
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            //Debug.Log("countdown reached 0");
            Destroy(gameObject);
        }
    }

    
    
}

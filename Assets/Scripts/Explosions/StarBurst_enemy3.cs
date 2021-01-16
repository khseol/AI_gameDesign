using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBurst_enemy3 : MonoBehaviour
{

    public GameObject burst;

    public void Burst(GameObject type)
    {

        if (type.name == "LR_Breaker_enemy3(Clone)")
        {

            //center
            Vector3 center = type.transform.position;
            //right
            Vector3 right = new Vector3(type.transform.position.x + 1f, type.transform.position.y, type.transform.position.z);
            //left
            Vector3 left = new Vector3(type.transform.position.x - 1f, type.transform.position.y, type.transform.position.z);
            //up
            Vector3 up = new Vector3(type.transform.position.x, type.transform.position.y + 1f, type.transform.position.z);
            //down
            Vector3 down = new Vector3(type.transform.position.x, type.transform.position.y - 1f, type.transform.position.z);

            //each instantiated prefab will have their own independent timer whenever they are instantiated.
            //very much like this script, when the spawner script spawns the breaker prefabs.
            GameObject burstLR_center = Instantiate(burst, center, Quaternion.identity);
            GameObject burstLR_right = Instantiate(burst, right, Quaternion.identity);
            GameObject burstLR_left = Instantiate(burst, left, Quaternion.identity);
            GameObject burstLR_up = Instantiate(burst, up, Quaternion.identity);
            GameObject burstLR_down = Instantiate(burst, down, Quaternion.identity);

        }

        if (type.name == "SR_Breaker_enemy3(Clone)")
        {
            //center
            Vector3 center = type.transform.position;
            //right
            Vector3 right2 = new Vector3(type.transform.position.x + 2f, type.transform.position.y, type.transform.position.z);
            Vector3 right = new Vector3(type.transform.position.x + 1f, type.transform.position.y, type.transform.position.z);
            //left
            Vector3 left2 = new Vector3(type.transform.position.x - 2f, type.transform.position.y, type.transform.position.z);
            Vector3 left = new Vector3(type.transform.position.x - 1f, type.transform.position.y, type.transform.position.z);
            //up
            Vector3 up2 = new Vector3(type.transform.position.x, type.transform.position.y + 2f, type.transform.position.z);
            Vector3 up = new Vector3(type.transform.position.x, type.transform.position.y + 1f, type.transform.position.z);
            //down
            Vector3 down2 = new Vector3(type.transform.position.x, type.transform.position.y - 2f, type.transform.position.z);
            Vector3 down = new Vector3(type.transform.position.x, type.transform.position.y - 1f, type.transform.position.z);

            GameObject burstLR_center = Instantiate(burst, center, Quaternion.identity);

            GameObject burstLR_right = Instantiate(burst, right, Quaternion.identity);
            GameObject burstLR_right2 = Instantiate(burst, right2, Quaternion.identity);

            GameObject burstLR_left = Instantiate(burst, left, Quaternion.identity);
            GameObject burstLR_left2 = Instantiate(burst, left2, Quaternion.identity);

            GameObject burstLR_up = Instantiate(burst, up, Quaternion.identity);
            GameObject burstLR_up2 = Instantiate(burst, up2, Quaternion.identity);

            GameObject burstLR_down = Instantiate(burst, down, Quaternion.identity);
            GameObject burstLR_down2 = Instantiate(burst, down2, Quaternion.identity);


        }

    }
}

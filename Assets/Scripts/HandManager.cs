using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public float speed;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
        pos= transform.position;
    }

    // Update is called once per frame
    void Update() // movement through WASD keys
    {
        
        pos.x+= Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        pos.y+= Input.GetAxis("Vertical") * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -15f, 15f); // restricting the mouse point movement on the screen  
        pos.y = Mathf.Clamp(pos.y, -12f, 12f);
        transform.position = pos;
    }
}

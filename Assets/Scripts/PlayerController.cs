using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float speed = 5.0f;
    public float padding = 0.00000000000000000000000000000001f;
    private float horizontalInput;
    private float xmin;
    private float xmax;
  

    // Use this for initialization
    void Start () {

        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + padding; 
        xmax = rightmost.x - padding;
    }
	
	// Update is called once per frame
	void Update () {
        horizontalInput = Input.GetAxis("Horizontal");
            if (Mathf.Abs(horizontalInput) > 0f)
            {
                transform.position += Vector3.right * speed * horizontalInput * Time.deltaTime;
            }

        //restrict the player to our gamespace
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
}

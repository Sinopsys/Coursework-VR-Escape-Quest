using UnityEngine;

public class Rotater : MonoBehaviour
{
    public float xSpeed = 1F;
    public float ySpeed = 1F;
    public float zSpeed = 1F;
    public bool manual = false;

    void Start() { }

    public void Update()
    {
        if (!manual)
        {
            transform.RotateAround(transform.position, Vector3.right, ySpeed * Time.deltaTime);
            transform.RotateAround(transform.position, Vector3.up, xSpeed * Time.deltaTime);
            transform.RotateAround(transform.position, Vector3.forward, zSpeed * Time.deltaTime);
        }
        else
        {
            if (Input.GetAxis("Horizontal") != 0F)
                transform.RotateAround(transform.position, Vector3.up, Input.GetAxis("Horizontal") * xSpeed * Time.deltaTime);

            if (Input.GetAxis("Vertical") != 0F)
                transform.RotateAround(transform.position, Vector3.right, Input.GetAxis("Vertical") * ySpeed * Time.deltaTime);
        }

    }
}


// EOF

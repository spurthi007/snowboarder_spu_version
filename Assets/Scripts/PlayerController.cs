using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rg2d;
    [SerializeField] float torqueAmount=1f;
    [SerializeField] float boostSpeed=25f;
    [SerializeField] float baseSpeed=18f;
    SurfaceEffector2D surfaceEffector2D;
    // Start is called before the first frame update
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        RespondToBoost();
    }

    void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed=boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed=baseSpeed;

        }
    }

    void RotatePlayer()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rg2d.AddTorque(torqueAmount);
        }

        else if(Input.GetKey(KeyCode.RightArrow))
        {
            rg2d.AddTorque(-torqueAmount);
        }
    }

}

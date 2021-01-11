using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    [SerializeField] private float angle;
    private float MoveDelta => speed * Time.deltaTime;
    

    private Camera cam;
    private float xAxis;
    private float zAxis;

    private float clampX_Min;
    private float clampX_Max;
    private float clampZ_Min;
    private float clampZ_Max;
    void Awake()
    {
        cam = Camera.main;
        Vector3 screenBoundary = new Vector3(Screen.width, 0, Screen.height);

        clampX_Min = -(cam.ScreenToWorldPoint(screenBoundary).x - .5f);
        clampX_Max = cam.ScreenToWorldPoint(screenBoundary).x - .5f;
        clampZ_Min = cam.ScreenToWorldPoint(screenBoundary).z + .5f;
        clampZ_Max = -(cam.ScreenToWorldPoint(screenBoundary).z * 2);

    }
    private void Update()
    {
        Fire();
    }
    void FixedUpdate()
    {
        Move();
        Rotate();
    }

    protected override void Move()
    {
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");

        Vector3 pos = new Vector3(Mathf.Clamp(transform.position.x + xAxis * MoveDelta, clampX_Min, clampX_Max), 0,
            Mathf.Clamp(transform.position.z + zAxis * MoveDelta, clampZ_Min, clampZ_Max));
        rb.MovePosition(pos);
    }

    void Rotate()
    {
        if (xAxis != 0)
        {
            rb.rotation = Quaternion.Euler(0, 0, angle * -xAxis);
        }
    }

    protected override void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(bulletArray[0], bulletSpawn.position, Quaternion.Euler(-90, 0, 0));
    }

}
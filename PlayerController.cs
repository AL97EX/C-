/*Контроллер игрока (движение, стрельба, бег (когда энергия полна), прыжки, движение камеры за игроком)
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float gravity=-10;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance=0.1f;
    [SerializeField] private float heightJump;

    [SerializeField] private Transform cam;
    [SerializeField] private float camZoom;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform bulletPref;
    [SerializeField] private Transform bulletPos;
    [SerializeField] private EnergyFull energyFull;

    [SerializeField] private int dust;
    [SerializeField] private GameObject speedMagic;
    [SerializeField] private Transform speedMagicPlace;

    [SerializeField] private Transform explosionPlace;
    [SerializeField] GameObject explosion;

    private GameObject cloneExplosion;
    private bool isGround;
    private GameObject cloneSpeedMagic;
    private Vector2 moveHorizontal;
    private Vector2 velocity;

    public List<Transform> lifeList;
    public int speed = 10;
    public int moveSide { get; set; }
    void Start()
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            lifeList.Add(parent.GetChild(i));
        }
    }

    void Update()
    {
        //isGround Check
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGround && velocity.y < 0)
        {
            velocity.y = -0.5f;
        }
        if (isGround && dust == 0)
        {
            cloneExplosion = Instantiate(explosion, explosionPlace.position, Quaternion.identity);
            Destroy(cloneExplosion, 1.5f);
            dust++;
        }

        //Fire
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPref, bulletPos.position, Quaternion.LookRotation(-bulletPos.right));
        }
        if (moveSide==-1)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if (moveSide == 1)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        moveHorizontal = Vector2.right * moveSide * speed * Time.deltaTime;
        controller.Move(moveHorizontal);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    private void LateUpdate()
    {
        cam.position = new Vector3(transform.position.x, transform.position.y + 3, camZoom);
    }
    void Running()
    {
        if (energyFull.enabled)
        {
            speed = 15;
            cloneSpeedMagic = Instantiate(speedMagic, speedMagicPlace.position, Quaternion.identity);
            Destroy(cloneSpeedMagic, 1.5f);
        }
    }
    public void Jump()
    {
        if (isGround) {
            dust = 0;
            velocity.y = Mathf.Sqrt(heightJump * -2 * gravity);
        }
    }
    public void Fire()
    {
        Instantiate(bulletPref, bulletPos.position, Quaternion.LookRotation(-bulletPos.right));
    }

    
}

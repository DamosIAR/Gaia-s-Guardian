using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePos;
    public GameObject spear;
    public Transform spearTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotarion = mousePos - transform.position;
        float rotz = Mathf.Atan2(rotarion.y, rotarion.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotz);

        if(!canFire )
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring )
            {
                canFire = true;
                timer = 0;
            }
        }

        if(Input.GetMouseButtonDown(0) && canFire)
        {
            canFire = false;
            Instantiate(spear, spearTransform.position, Quaternion.identity);
        }
        

    }
}

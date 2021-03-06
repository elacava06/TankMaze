﻿using UnityEngine;
using System.Collections;

public class DestroyBlocks : MonoBehaviour
{

    public float drillRange;
    public float drillTime;
    public float drillCooldown;
    private bool drillingCooldown = false;
    public bool drilling = false;
    private bool alreadyHit = false;
    // Use this for initialization
    private Transform drillHead;
    public Vector3 originalPosition;
    public float drillDamage;
    private float damageCounter;
    public int teamNumber;
    public string drillAxis;
    private int controllerNumber;
    public GameObject gameStateManager;
    private GameState gameManager;

    void Awake()
    {
        gameStateManager = GameObject.Find("GameManager");
        gameManager = gameStateManager.GetComponent<GameState>();
        drillHead = transform.GetChild(0);
        originalPosition = drillHead.localPosition;
    }
    void Start()
    {
        teamNumber = GetComponentInParent<TankInfo>().teamNumber;
    }
    void OnEnable()
    {
        drillHead.localPosition = originalPosition;
        drillingCooldown = false;
        drilling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.currentGameState == GameState.gameState.play)
        {
            if (Input.GetAxis(drillAxis) != 0 && !drillingCooldown)
            {
                StartCoroutine(drill());
            }
        }
    }

    IEnumerator drill()
    {
        //Debug.Log("drill called");
        drilling = true;
        drillingCooldown = true;
        damageCounter = 0;

        //Debug.Log(originalPosition);
        float fireTime = Time.time;
        while (Time.time < (fireTime + drillTime))
        {
            drillHead.localPosition += Vector3.up * drillRange / drillTime * Time.deltaTime;
            yield return null;
        }
        drilling = false;
        alreadyHit = false;


        fireTime = Time.time;
        while (Time.time < (fireTime + drillCooldown))
        {
            drillHead.localPosition -= Vector3.up * drillRange / drillCooldown * Time.deltaTime;
            yield return null;
        }
        //transform.Translate(transform.rotation * Vector3.up * drillRange);
        drillHead.localPosition = originalPosition;
        drillingCooldown = false;

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (drilling && !alreadyHit)
        {
            if (other.tag == "tank")
            {
                if (other.GetComponent<TankInfo>().teamNumber != teamNumber)
                {
                    alreadyHit = true;
                    damageTank(other.transform);
                }
            }
        }
        if (other.tag == "drill")
        {
            Debug.Log("drills can sense touching!!!");
        }
    }

    void damageTank(Transform other)
    {

        int damageToDeal = Mathf.RoundToInt(drillDamage - damageCounter);
        //should never deal zero damage;
        if (damageToDeal < 1)
        {
            damageToDeal = 1;
        }
        other.GetComponentInChildren<HealthBar>().loseHealth(damageToDeal);
        other.GetComponentInChildren<TankBody>().loseHealth(damageToDeal);
        
    }

    void updateDrillDamage()
    {
        damageCounter++;
    }

    public bool hasHitTank()
    {
        return alreadyHit;
    }

    public void setControllerNumber(int number)
    {
        controllerNumber = number;
        drillAxis = "drill" + controllerNumber;
    }





}

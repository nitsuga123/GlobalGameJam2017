using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : MonoBehaviour {

    private static AttackBehaviour instance;
    public static AttackBehaviour Instance
    {
        get
        {
            return instance;
        }
    }

    public Transform attackSpawn;
    public GameObject[] waves = new GameObject[3];

    private Vector3 startScale;
    private WaveMovement[] movements = new WaveMovement[3];

    //Unity functions

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            DestroyImmediate(gameObject);

        startScale = waves[0].transform.localScale;
        foreach (GameObject wave in waves)
            wave.SetActive(false);
        for (int i = 0; i < waves.Length; i++) {
            movements[i] = waves[i].GetComponent<WaveMovement>();
        }
    }

	void Start ()
    {
        foreach (WaveMovement waveMove in movements)
            waveMove.enabled = false;
    }

    //Red

    public void AttackRed()
    {
        waves[0].SetActive(true);
        movements[0].enabled = true;
    }

    public void EndRed()
    {
        waves[0].SetActive(false);
        waves[0].transform.localScale = startScale;
        movements[0].enabled = false;
        //waves[0].transform.position = attackSpawn.position;
    }

    //Blue

    public void AttackBlue()
    {
        waves[1].SetActive(true);
        movements[1].enabled = true;
    }

    public void EndBlue()
    {
        waves[1].SetActive(false);
        waves[1].transform.localScale = startScale;
        movements[1].enabled = false;
     //   waves[1].transform.position = attackSpawn.position;
    }

    //Yellow

    public void AttackYellow()
    {
        waves[2].SetActive(true);
        movements[2].enabled = true;
    }

    public void EndYellow()
    {
        waves[2].SetActive(false);
        waves[2].transform.localScale = startScale;
        movements[2].enabled = false;
       // waves[2].transform.position = attackSpawn.position;
    }
}
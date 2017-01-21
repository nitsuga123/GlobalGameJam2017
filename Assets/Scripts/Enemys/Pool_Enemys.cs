using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_Enemys : MonoBehaviour {

    private static Pool_Enemys pool_Enemys;

    public static Pool_Enemys pool_enemys
    {
        get
        {
            return pool_Enemys;
        }
    }

    [SerializeField]
    private float min_high;

    [SerializeField]
    private float max_high;

    [SerializeField]
    private GameObject[] bat_enemy;

    [SerializeField]
    private int enemys_Amount;

    [SerializeField]
    private GameObject spawn;

    private List<GameObject> bat_list;

    private void Awake()
    {
        if (pool_Enemys == null)
        {
            pool_Enemys = this;

            Prepare();
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Prepare()
    {
        bat_list = new List<GameObject>();
        for (int i = 0; i < enemys_Amount; i++){
            CreateBat();

        }

    }

    private void CreateBat()
    {
 
        GameObject bat = Instantiate(bat_enemy[Random.Range(0,bat_enemy.Length)], new Vector3(spawn.transform.position.x, Random.Range(min_high,max_high)), Quaternion.identity);
        bat.gameObject.SetActive(false);
        bat_list.Add(bat);

    }

    public GameObject ObtainBat()
    {
        if (bat_list.Count == 0)
        {
            CreateBat();

        }
        return BatAmount();
    } 

    private GameObject BatAmount()
    {
        GameObject bat = bat_list[bat_list.Count - 1];
        bat_list.RemoveAt(bat_list.Count - 1);
        bat.gameObject.SetActive(true);
        return bat;


    }

    public void DesactiveBat(Collider2D bat)
    {
        bat.transform.position = new Vector3(spawn.transform.position.x, Random.Range(min_high, max_high));
        bat.gameObject.SetActive(false);
        bat_list.Add(bat.gameObject);

    }









}

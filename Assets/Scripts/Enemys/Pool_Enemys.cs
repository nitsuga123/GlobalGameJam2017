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

    //[SerializeField]
    private float min_high;

   //[SerializeField]
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
        SetBounds();
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

    private void SetBounds()
    {
        max_high = Camera.main.transform.position.y + Camera.main.orthographicSize - 1.7f;
        min_high = Camera.main.transform.position.y - Camera.main.orthographicSize + 1.7f;
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
        int batIndex = Random.Range(0, bat_list.Count-1);

        GameObject bat = bat_list[batIndex];
        bat_list.RemoveAt(batIndex);
        bat.transform.rotation = spawn.transform.rotation;
        bat.gameObject.SetActive(true);
        return bat;
    }

    public void DesactiveBat(Collider2D bat)
    {
        bat.transform.position = new Vector3(spawn.transform.position.x, Random.Range(min_high, max_high));
        bat.gameObject.SetActive(false);
        bat_list.Add(bat.gameObject);
        SpriteRenderer batRen = bat.GetComponentInChildren<SpriteRenderer>();
        batRen.color = new Color(batRen.color.r,batRen.color.g,batRen.color.b,1f);
    }
}

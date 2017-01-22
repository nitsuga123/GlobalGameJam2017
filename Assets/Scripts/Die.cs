using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour {

    [SerializeField]
    private Collider2D colider;

    [HideInInspector]
    public int hitCount;
    [SerializeField]
    private float timeToDie;
    [SerializeField]
    private float time;

    [Header("AudioSources")]

	[SerializeField]
	private AudioSource MusicLevel;
    [SerializeField]
	private AudioSource MusicGameOver;
    [SerializeField]
    private AudioSource damage1;
    [SerializeField]
    private AudioSource damage2;
    [SerializeField]
    private AudioSource damage3;

    //Unity functions

    void Start()
    {
        hitCount = 0;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (!CharacterController.hit && time>0.7f)
        {
            CharacterController.hit = true;
            time = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Red") || other.CompareTag("Blue") || other.CompareTag("Yellow"))
        {
            Debug.Log("1");

            int i = Random.Range(0, 3);

            if (i == 0)
            {
                Debug.Log("Entro1");
                damage1.Play();
            }

            else if (i == 1)
            {
                Debug.Log("Entro2");
                damage2.Play();
            }

            else if (i == 2)
            {
                Debug.Log("Entro3");
                damage3.Play();
            }

            CharacterController.anim.SetInteger("Action", 2);
            GameManager.Instance.hearts[hitCount].gameObject.SetActive(false);
            hitCount++;

            CharacterController.hit = false;
            time = 0;

            Animator batAnim = other.gameObject.GetComponent<Animator>();

            batAnim.SetTrigger("BatDie");

            if (hitCount == 3)
            {
                CharacterController.anim.SetInteger("Action", 3);
                StartCoroutine(GameOver());
				StartCoroutine (FadeOut(MusicLevel, 3f));
				StartCoroutine (Fadein(MusicGameOver, 4.2f, 0.26f));
                colider.enabled = false;
                this.GetComponent<Shoot>().enabled = false;
                CharacterController.die = false;
            }
            else
            {
                CharacterController.die = true;
            }
        }
    }

    //Other functions

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds (timeToDie);


        //SceneManager.LoadScene(0);
    }

    //Fades

	public IEnumerator FadeOut(AudioSource a,float Fadetime)
    {
		float StartVolume = a.volume;

		while (a.volume > 0) {
			a.volume -= StartVolume * Time.deltaTime / Fadetime;
			yield return null;
		}

		a.Stop();
		a.volume = StartVolume;
	}

    public IEnumerator Fadein(AudioSource a, float Fadetime,float volumenMax)
	{
		float StartVolume = volumenMax;
		a.Play();

		while (a.volume < volumenMax)
		{
			a.volume += StartVolume * Time.deltaTime / Fadetime;
			yield return null;
		}

		a.volume = StartVolume;
	}
}
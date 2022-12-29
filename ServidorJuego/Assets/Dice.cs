using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    public static Dice instance;
    [SerializeField] private Sprite[] diceSides;
    private SpriteRenderer rend;
    private bool coroutineAllowed = true;

	// Use this for initialization
	private void Start () {
        instance = this;
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = diceSides[Random.Range(0,6)];
	}

    private void OnMouseDown()
    {
        /*if (!GameControl.gameOver && coroutineAllowed)
            StartCoroutine("RollTheDiceCoroutine");*/
    }

    public void RollTheDice(int number) {
        StartCoroutine(RollTheDiceCoroutine(number));
    }
    public IEnumerator RollTheDiceCoroutine(int randomDiceSide)
    {
        coroutineAllowed = false;
        for (int i = 0; i <= 20; i++)
        {
            rend.sprite = diceSides[Random.Range(0, 6)];
            yield return new WaitForSeconds(0.05f);
        }
        rend.sprite = diceSides[randomDiceSide];
        coroutineAllowed = true;
    }
}

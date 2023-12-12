using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public List<string> FoodList = new List<string>( new string[] { "딸기", "떡꼬치" });
    public List<Sprite> FoodSprites = new List<Sprite>();
    public string Tag;

    private void Start()
    {
        Tag = FoodList[Random.Range(0, 2)];

        if (Tag == "딸기")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = FoodSprites[0];
        }
        else if (Tag == "떡꼬치")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = FoodSprites[1];
        }
    }

    private void Update()
    {
        if(transform.position.x > 5 || transform.position.x < -5)
        {
            Destroy(gameObject);
        }
    }
}

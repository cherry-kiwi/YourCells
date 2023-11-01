using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public List<string> FoodList = new List<string>( new string[] { "��", "����", "����ġ" });
    public List<Sprite> FoodSprites = new List<Sprite>();
    public string Tag;

    private void Start()
    {
        Tag = FoodList[Random.Range(0, 3)];

        if (Tag == "��")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = FoodSprites[0];
        }
        else if (Tag == "����")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = FoodSprites[1];
        }
        else if (Tag == "����ġ")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = FoodSprites[2];
        }
    }

    private void Update()
    {
        if(transform.position.x > 5 || transform.position.x < -5 || transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
}

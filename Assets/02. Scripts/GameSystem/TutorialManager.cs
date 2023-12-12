using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;

    public GameObject mainCam;
    public GameObject TutoCell;
    public GameObject TouchGuard;

    public int index;

    [Header("Tutorials items")]
    public GameObject[] items;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (GameManager.instance.isTutorial)
        {
            StartCoroutine(TutorialCutScene());
        }
    }

    public IEnumerator TutorialCutScene()
    {
        if (GameManager.instance.isTutorial)
        {
            if (index == 0)
            {
                TutoCell.GetComponent<Animator>().SetInteger("mod", 0);

                yield return new WaitForSeconds(1);

                items[0].SetActive(true);

                yield return new WaitForSeconds(3);

                if (index < 1)
                {
                    index = 1;
                }
            }
            else if (index == 1)
            {
                TutoCell.GetComponent<Animator>().SetInteger("mod", 2);

                //TutoCell.GetComponent<Animator>().Play("HandShake");

                while (true)
                {
                    mainCam.transform.position = Vector3.Lerp(mainCam.transform.position,
                                                        TutoCell.transform.position,
                                                        Time.deltaTime * 0.1f);

                    if (mainCam.GetComponent<Camera>().orthographicSize > 2.3f)
                    {
                        mainCam.GetComponent<Camera>().orthographicSize -= Time.deltaTime * 0.2f;
                    }
                    else
                    {
                        break;
                    }

                    yield return null;
                }

                yield return new WaitForSeconds(1);

                if (index < 2)
                {
                    index = 2;
                }
            }
            else if (index == 2)
            {
                items[0].SetActive(false);
                TutoCell.GetComponent<Animator>().SetInteger("mod", 0);

                //TutoCell.GetComponent<Animator>().Play("Idle");

                if (index < 3)
                {
                    index = 3;
                }
            }
            else if (index == 3 && items[1].activeSelf == false)
            {
                items[1].SetActive(true);
            }
            else if (index == 4)
            {
                items[2].SetActive(true);
            }
            else if (index == 5)
            {
                items[3].SetActive(true);
            }
            else if (index == 6)    //Opening
            {
                items[4].SetActive(true);
            }
            else if (index == 7)
            {
                for (int i = 0; i < GameManager.instance.mainUI.Count; i++)
                {
                    GameManager.instance.mainUI[i].SetActive(true);
                }

                while (true)
                {
                    mainCam.transform.position = Vector3.Lerp(mainCam.transform.position,
                                                        new Vector3(0, 0, -10),
                                                        Time.deltaTime * 0.1f);

                    if (mainCam.GetComponent<Camera>().orthographicSize < 5f)
                    {
                        mainCam.GetComponent<Camera>().orthographicSize += Time.deltaTime * 0.2f;
                    }
                    else
                    {
                        mainCam.transform.position = new Vector3(0, 0, -10);
                        break;
                    }

                    yield return null;
                }

                items[5].SetActive(true);
            }
            else if (index == 8)
            {
                items[6].SetActive(true);
            }
            else if (index == 9)
            {
                items[7].SetActive(true);
            }
            else if (index == 10)
            {
                items[8].SetActive(true);
            }
            else if (index == 11)
            {
                items[9].SetActive(true);
            }
            else if (index == 12)
            {
                items[10].SetActive(true);
            }
            else if (index == 13)   //Build
            {
                items[11].SetActive(true);
            }
            else if (index == 14)
            {
                items[12].SetActive(true);
            }
            else if (index == 15)
            {
                items[13].SetActive(true);
            }
            else if (index == 16)
            {
                items[14].SetActive(true);
            }
            else if (index == 17)
            {
                items[15].SetActive(true);
            }
            else if (index == 18)
            {
                items[16].SetActive(true);
            }
            else if (index == 19)
            {
                items[17].SetActive(true);
            }
            else if (index == 20)
            {
                items[18].SetActive(true);
            }
            else if (index == 21)
            {
                items[19].SetActive(true);
            }
            else if (index == 22)
            {
                items[20].SetActive(true);
            }
            else if (index == 23)
            {
                items[21].SetActive(true);
            }
            else if (index == 24)   //미니게임 스타트
            {
                items[22].SetActive(true);
            }
            else if (index == 25)
            {
                items[22].SetActive(false);
                items[23].SetActive(true);

                yield return new WaitForSeconds(1);

                if (index < 26)
                {
                    index = 26;
                }
            }
            else if (index == 26)
            {
                items[24].SetActive(true);
            }
            else if (index == 27)
            {
                items[25].SetActive(true);
            }
            else if (index == 28)
            {
                items[26].SetActive(true);
            }
            else if (index == 29)
            {
                items[27].SetActive(false);
                if (items[29].activeSelf == false)
                {
                    items[28].SetActive(true);
                }

                yield return new WaitForSeconds(5);

                items[28].SetActive(false);
                if (items[30].activeSelf == false)
                {
                    items[29].SetActive(true);
                }

                yield return new WaitForSeconds(1);

                if (index < 30)
                {
                    index = 30;
                }
            }
            else if (index == 30)
            {
                items[30].SetActive(true);
            }
            else if (index == 31)
            {
                items[31].SetActive(true);
            }
            else if (index == 32)
            {
                items[32].SetActive(true);
            }
            else if (index == 33)
            {
                items[32].SetActive(false);
                items[33].SetActive(true);
            }
            else if (index == 34)
            {
                GameManager.instance.isTutorial = false;
                StopCoroutine(TutorialCutScene());
            }
        }
    }

    public void ActiveNextIndex()
    {
        index++;
    }
}

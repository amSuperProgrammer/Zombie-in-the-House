using System.Collections;
using UnityEngine;

public class SceneAwake : MonoBehaviour
{
    [SerializeField] GameObject testObj;
    int posZ = 0;
    int posX = 1;
    int createdCartListNum = 0;
    int remainedCartNum = 134;

    string completedCartType = "";
    int cartTypeArrayNum = 0;

    GameObject[] createdCartList = new GameObject[134];
    string[] cartTypeArray = new string[]
    {
        "Zombie","Zombie","Zombie","Zombie","Zombie",
        "Zombie","Zombie","Zombie","Zombie","Zombie",
        "Zombie","Zombie","Zombie","Zombie","Zombie",
        "Zombie","Zombie",

        "Dogs","Dogs","Dogs","Dogs","Dogs",

        "Spider","Spider","Spider","Spider","Spider",

        "Boss",

        "Grenade","Grenade","Grenade","Grenade",

        "Knife","Crossbow","Axe","Pistol","Automate",
        "Shotgun","Launcher",

        "MedChest","MedChest","MedChest","MedChest",
        "MedChest","MedChest",

        "Board","Board","Board","Board","Board",
        "Board","Board","Board",

        "Canister","Key",

        "Sasha","Nastya","Nadya","Max","Borya"
    };
    

    private void Start()
    {
        Debug.Log(cartTypeArray.Length);
        StartCoroutine(instantiateCart());
    }

    IEnumerator instantiateCart()
    {

        posZ += 1;

        if (posZ == 13)
        {
            posZ = 1;
            posX += 1;
        }

        if ((posZ == 1 && posX == 1) || (posZ == 2 && posX == 1) || (posZ == 1 && posX == 2) || (posZ == 2 && posX == 2))
        {
            StartCoroutine(instantiateCart());
            yield break;
        }
        else if ((posZ == 11 && posX == 10) || (posZ == 12 && posX == 10) || (posZ == 11 && posX == 11) || (posZ == 12 && posX == 11))
        {
            StartCoroutine(instantiateCart());
            yield break;
        }

        if (posZ == 11 && posX == 12)
        {
            StartCoroutine(CartDeleter());
        }
        else
        {
            createdCartList[createdCartListNum] = Instantiate(testObj, new Vector3(posX, 0.6f, posZ), Quaternion.Euler(Vector3.zero));
            yield return new WaitForSeconds(0.01f);

            createdCartListNum++;
            StartCoroutine(instantiateCart());
        }
    }

    IEnumerator CartDeleter()
    {
        Debug.Log(remainedCartNum);

        if (remainedCartNum < 60)
        {
            CartChanger();
            yield break;
        }

        int num = Random.Range(0, 134);

        if (createdCartList[num] != null && Random.Range(0, 2) == 1)
        {
            Destroy(createdCartList[num]);
            createdCartList[num] = null;
            remainedCartNum--;
            yield return new WaitForSeconds(0.01f);
            StartCoroutine(CartDeleter());
        }
        else
        {
            StartCoroutine(CartDeleter());
            yield break;
        }
    }

    void CartChanger()
    {
        foreach(GameObject cart in createdCartList)
        {
            if(cart != null)
            {
                Debug.Log("is not null");

/*                do
                {
                    cartTypeArrayNum = Random.Range(0, 60);
                    Debug.Log(cartTypeArrayNum);

                    if (cartTypeArray[cartTypeArrayNum] != null)
                    {
                        Debug.Log("search complete");
                        completedCartType = cartTypeArray[cartTypeArrayNum];
                        cartTypeArray[cartTypeArrayNum] = null;
                    }

                } while (completedCartType != cartTypeArray[cartTypeArrayNum]);*/

                while (completedCartType != cartTypeArray[cartTypeArrayNum])
                {
                    cartTypeArrayNum = Random.Range(0, 60);
                    Debug.Log(cartTypeArray[cartTypeArrayNum]);

                    if (cartTypeArray[cartTypeArrayNum] != null)
                    {
                        Debug.Log("search complete");
                        completedCartType = cartTypeArray[cartTypeArrayNum];
                        cartTypeArray[cartTypeArrayNum] = null;
                    }
                }

                Debug.Log("get");
                cart.GetComponent<Cart>().cartType = completedCartType;
            }
        }
    }

}

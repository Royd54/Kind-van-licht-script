using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerSpirit : MonoBehaviour
{
    [SerializeField] private GameObject igniculusLight1;
    [SerializeField] private GameObject igniculusLight2;
    [SerializeField] private Image spiritUsageBar;

    public float distance = 10.0f;
    public bool useInitalCameraDistance = false;

    private float actualDistance;
    private double charge = 500;
    private float maxCharge = 500;

    // Use this for initialization
    void Start()
    {
        //calculates distance between cam and object
        if (useInitalCameraDistance)
        {
            Vector3 toObjectVector = transform.position - Camera.main.transform.position;
            Vector3 linearDistanceVector = Vector3.Project(toObjectVector, Camera.main.transform.forward);
            actualDistance = linearDistanceVector.magnitude;
        }
        else
        {
            actualDistance = distance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //places opject on the correct z acces and makes the object follow the mouse
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 22;
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);

        //checks if the charge is high enough to use powers
        if (Input.GetMouseButton(1) && charge > 0)
        {
            spiritUsageBar.fillAmount = (float)charge / maxCharge;
            charge -= 0.4;
            igniculusLight2.SetActive(true);
        }
        else
        {
            igniculusLight2.SetActive(false);
        }
    }

    //if the object triggers an collision and uses powers within a flower, hp and mana is added to the player
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButton(1) && collision.gameObject.tag == "plant" && charge > 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerCombat>().addRecourses(Random.Range(2, 5), Random.Range(1, 3));
        }

        if (Input.GetMouseButton(1) && collision.gameObject.tag == "enemy" && charge > 0)
        {
            GameObject.FindGameObjectWithTag("enemy").GetComponent<enemyCombat>().canAttack -= 1;
            Debug.Log(GameObject.FindGameObjectWithTag("enemy").GetComponent<enemyCombat>().canAttack);
        }
    }

    //returns the charge variable
    public double getCharge()
    {
        Debug.Log(charge);
         return charge;
    }
}

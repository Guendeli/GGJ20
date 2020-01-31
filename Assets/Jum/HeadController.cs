using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{

    public GameObject shortHead;
    public GameObject mediumHead;
    public GameObject longHead;
    int headID = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (headID < 4)
                headID++;
            else
                headID = 1;
        }

        if (headID == 1)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                shortHead.transform.Rotate(0, 20, 0);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                shortHead.transform.Rotate(0, -20, 0);
            }
        }

        else if (headID == 2)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                mediumHead.transform.Rotate(0, 20, 0);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                mediumHead.transform.Rotate(0, -20, 0);
            }
        }

        else if (headID == 3)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                longHead.transform.Rotate(0, 20, 0);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                longHead.transform.Rotate(0, -20, 0);
            }
        }
    }
}

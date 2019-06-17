using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAndTargetManager : MonoBehaviour
{
    public GameObject longBow1;
    public GameObject longBow2;
    public GameObject target1;
    public GameObject target2;
    public static BowAndTargetManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;

    }

    private void OnDestroy()
    {
        if (instance = this)
            instance = null;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}


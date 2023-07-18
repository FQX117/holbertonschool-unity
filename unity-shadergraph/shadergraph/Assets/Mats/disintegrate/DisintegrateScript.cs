using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DisintegrateScript : MonoBehaviour
{
    public MeshRenderer skinnedMesh;
    public float dissolveRate = 0.0125f;
    public float refreshRate = 0.025f;


    private Material[] materials;
    // Start is called before the first frame update
    void Start()
    {
        if(skinnedMesh != null)
            materials = skinnedMesh.materials;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.Space))
        {
            StartCoroutine(Disintegrate());
        }
    }

    IEnumerator Disintegrate ()
    {
        if (materials.Length > 0)
        {
            float counter = 0;

            while (materials[0].GetFloat("_disintegrateAmount") < 1)
            {
                counter += dissolveRate;
                for (int i = 0; i < materials.Length; i++) 
                {
                    materials[i].SetFloat("_disintegrateAmount", counter);
                }
                yield return new WaitForSeconds(refreshRate);
            }
        }
    }
}

using UnityEngine;
using System.Collections;

public class CircleRotateScript : MonoBehaviour {

    [SerializeField]
    private float rotationSpeed = 50f;

    private bool canRotate = false;

    private float angle;

    void Awake()
    {
        canRotate = true;
        StartCoroutine(ChangeRotation());
	}

    void Update()
    {
        if (canRotate)
        {
            RotateTheCircle();
        }
    }

    IEnumerator ChangeRotation()
    {
        yield return new WaitForSeconds(2f);

        if (Random.Range(0, 2) > 0)
        {
            rotationSpeed = -Random.Range(30, 100);
        }
        else {
            rotationSpeed = Random.Range(30, 100);
        }

        StartCoroutine(ChangeRotation());

    }

    void RotateTheCircle()
    {
        angle = transform.rotation.eulerAngles.z;
        angle += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShooter : MonoBehaviour
{
    public int timeLeft = 10;
    [SerializeField] Camera cam;

    public void Start()
    {
        StartCoroutine("LoseTime");
    }
    void Update()
    {
        if (timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            Application.Quit();
            timeLeft = 0;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Target target = hit.collider.gameObject.GetComponent<Target>();
                if (target != null)
                {
                    target.Hit();
                    FindObjectOfType<Score_Manager>().score += 1;
                    FindObjectOfType<Score_Manager>().PrintScore(); ;
                }
            }
        }
    }
    IEnumerable LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}

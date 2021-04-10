using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiamondScript : MonoBehaviour
{
    public Quaternion rotationAmount;
    public float floatAmount = 10.0f;
    public float floatingPower = 0.05f;
    public float timer = 0.0f;
    public int scoreValue = 100;
    public string moveToLevel = "LevelOne";
    public SeeColor colorToUnlock = SeeColor.NONE;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + floatAmount * Time.deltaTime, transform.position.z), floatingPower);
        transform.rotation *= rotationAmount;

        timer += Time.deltaTime;

        if (timer >= 1.0f)
        {
            timer = 0.0f;
            floatAmount *= -1.0f;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Diamond Hit");
        if(collider.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerController>().increaseScore(scoreValue);
            collider.gameObject.GetComponent<ColorManager>().unlockColor(colorToUnlock);
            SceneManager.LoadScene(moveToLevel);
            Destroy(gameObject);
        }
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class SceneLoader : MonoBehaviour
//{
//    public Rigidbody carsRB;
//    bool isDead = false;

//    void Update()
//    {
//        if (isDead = true)
//        {
//            StartCoroutine(LooseScene());
//        }
//        Loose();

//    }
//    void Reload()
//    {
//        Scene scene = SceneManager.GetActiveScene();
//        SceneManager.LoadScene(scene.name);
//    }

//    void WinScene()
//    {

//    }

//    void Loose()
//    {
//        if (carsRB.velocity.y < -10) { isDead = true; }
//        //Reload();
//        //isDead = false;
//    }

//    IEnumerator LooseScene()
//    {
//        yield return new WaitForSeconds(3);
//        SceneManager.LoadScene("Loose");
//        isDead = false;
//    }

//}

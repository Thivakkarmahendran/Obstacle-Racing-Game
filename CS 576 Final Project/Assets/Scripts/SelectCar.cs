using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectCar : MonoBehaviour
{
    // Start is called before the first frame update
    // 0 = Small, 1 = Normal, 2 = Big
    public void chooseCar(int carNum){
        // Store car choice in empty game object somewhere

        SceneManager.LoadScene(2); // Load Stage Select Scene
    }
}

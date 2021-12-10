using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectCar : MonoBehaviour
{
    // Start is called before the first frame update
    // 3 = Speed, 4 = Normal, 5 = Life

    public void chooseCar(int carNum){
        // Store car choice in empty game object somewhere

        SceneManager.LoadScene(carNum); // Load Stage Select Scene
    }
}

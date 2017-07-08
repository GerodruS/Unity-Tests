using UnityEngine;


public class SpriteSwitcher : MonoBehaviour
{
    Camera MainCamera;
    Factory Factory;
    
    void Awake()
    {
        MainCamera = Camera.main;
        Factory = GetComponent<Factory>();
    }
    
    void Update()
    {
//        print(Time.deltaTime);
        if (Input.GetMouseButtonUp(0))
        {
            var x = MainCamera.ScreenToViewportPoint(Input.mousePosition).x;
            if (x < 0.5f)
                Factory.Decrease();
            else
                Factory.Increase();
        }
    }
}
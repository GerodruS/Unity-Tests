using UnityEngine;


public class SpriteSwitcherForMover : MonoBehaviour
{
    Camera MainCamera;
    FactoryMover Factory;
    
    void Awake()
    {
        MainCamera = Camera.main;
        Factory = GetComponent<FactoryMover>();
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
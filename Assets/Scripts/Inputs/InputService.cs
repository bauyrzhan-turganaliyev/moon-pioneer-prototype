using UnityEngine;

namespace TheGame.Inputs
{
    public class InputService : MonoBehaviour
    {
        
        void Start()
        {
        
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                print("space key was pressed");
            }
        }
    }
}

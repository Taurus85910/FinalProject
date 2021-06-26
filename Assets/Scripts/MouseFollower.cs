using UnityEngine;

    public class MouseFollower : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                gameObject.transform.position =
                    new Vector3(Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, -15, 15),
                        Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -42, 22), 10);


            }
        }
    }

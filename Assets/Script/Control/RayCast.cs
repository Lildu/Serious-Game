using UnityEngine;
using Cinemachine;
using System.Collections;


public class RayCast : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    //[SerializeField] private string recuperableTag = "Recuperable";
    //private ItemsPickup itemsPickup;
      

    private Transform _selection;

    

    void Update()
    {
        if(_selection != null)
        {
            _selection = null;
        }

        if (Input.GetMouseButtonDown(0))
        {
            // création du raycast sur la caméra
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // contient l'objet touché par le raycast
            RaycastHit hit;
            // condition lu si touché par le raycast
            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                if (selection.CompareTag(selectableTag))
                {
                    CameraManager.SwitchCamera(selection.transform.GetComponentInChildren<CinemachineVirtualCamera>());
                    Touch.isSwipeActive = false;
                }
                _selection = selection;    
            }

            /*if (Physics.Raycast(ray, out hit, 10))
            {
                var selection = hit.transform;
                if (selection.CompareTag(recuperableTag))
                {
                    Debug.Log(itemsPickup);
                    itemsPickup.Pickup();
                }
                _selection = selection;
            }*/
        }
        

        
    }
}

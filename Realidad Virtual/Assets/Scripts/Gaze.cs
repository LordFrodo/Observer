using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Gaze : MonoBehaviour
{

    [SerializeField] private float interactableDistance = 10f;

    private GameObject _gazeObject;
    private PointerEventData _eventData;

    public static Action<GameObject> OnPointerEnter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateInteraction();
    }

    private void UpdateInteraction()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, interactableDistance))
        {
            if (_gazeObject != hit.transform.gameObject)
            {
                _gazeObject = hit.transform.gameObject;

                if (_gazeObject)
                {

                    _gazeObject.GetComponent<IPointerExitHandler>()?.OnPointerExit(_eventData);
                    _gazeObject = hit.transform.gameObject;
                    _gazeObject.GetComponent<IPointerEnterHandler>()?.OnPointerEnter(_eventData);
                }
            }
        }
        else if (_gazeObject)
        {
            _gazeObject.GetComponent<IPointerExitHandler>()?.OnPointerExit(_eventData);
            _gazeObject = null;
        }

    }
}
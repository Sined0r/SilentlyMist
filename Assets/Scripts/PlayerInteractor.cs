using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _hand;

    [SerializeField] private GameObject note;
    [SerializeField] private GameObject textNote;

    [SerializeField] private GameObject dialoge;

    public bool _isdialoge = false;
    public bool _lamp = false;
    public bool _all = false;


    private void Update()
    {
        Vector3 origin = _camera.transform.position;
        Vector3 direction = _camera.transform.forward;
        Debug.DrawRay(origin, direction * 1000);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(origin, direction, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Takable takable))
                {
                    TakeInHand(takable);
                    _lamp = true;
                }
                if (hit.collider.GetComponent<Note>())
                {
                    note.SetActive(true);
                    textNote.GetComponent<Text>().text = hit.collider.GetComponent<Note>().textNote;
                }
                if (hit.collider.GetComponent<Gribnik>())
                {
                    if (_isdialoge == false)
                    {
                        dialoge.SetActive(true);
                        _isdialoge = true;
                    }
                    if (_all == true)
                    {

                    }
                }
            }
        }

        if(_lamp == true && _isdialoge == true)
        {
            _all = true;
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            note.SetActive(false);
            textNote.GetComponent<Text>().text = "";
        }
    }

    private void Awake()
    {
        note.SetActive(false);
    }
    

    private void TakeInHand(Takable tackable)
    {
        tackable.gameObject.transform.parent = _hand;
        tackable.transform.localPosition = Vector3.zero;
        tackable.transform.localRotation = Quaternion.identity;
    }
}

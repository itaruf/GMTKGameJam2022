using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _startText;
    [SerializeField] private float _flickeringDuration = 0.5f;
    private bool _allowFlickering = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_allowFlickering)
        {
            StartCoroutine(DisableStartTextCoroutine());
        }
    }


    IEnumerator DisableStartTextCoroutine()
    {
        _allowFlickering = false;
        yield return new WaitForSeconds(_flickeringDuration);
        _startText.enabled = !_startText.enabled;
        _allowFlickering = true;
    }

    public void StartGame(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}

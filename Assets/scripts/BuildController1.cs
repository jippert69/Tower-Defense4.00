using UnityEngine;
using UnityEngine.InputSystem;

public class BuildController1 : MonoBehaviour
{
   private InputSystem_Actions input;
     public TorenManager torenManager; 

    private void Awake()
    {
        input = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        input.Player.Click.performed += OnClick;
        input.Player.Enable();
    }

    private void OnDisable()
    {
        input.Player.Click.performed -= OnClick;
        input.Player.Disable();
    }

    private void OnClick(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(torenManager.selectedTower == null)
            return;
        Ray ray = Camera.main.ScreenPointToRay(input.Player.Click.ReadValue<Vector2>());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            BuildSpot spot = hit.collider.GetComponent<BuildSpot>();
            if (spot != null && !spot.isBezet)
            {
                spot.Build(torenManager.selectedTower);
                torenManager.DeselectTower();
            }
        }
    }
}


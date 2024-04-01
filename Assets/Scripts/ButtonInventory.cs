using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;

[RequireComponent(typeof(InputData))]

public class ButtonInventory : MonoBehaviour
{
    private InputData _inputData;
    private bool _rightPrimaryButtonPressed = false;
    private bool _rightSecondaryButtonPressed = false;
    private int _currentWeaponIndex = 0; // Current index of the selected weapon
    private GameObject _currentWeaponInstance; // Reference to the current weapon instance

    public GameObject[] weapons; // Array for the prefabs

    public GameObject controllerobj; // Reference to the controller object
    

    private void Start()
    {
        _inputData = GetComponent<InputData>();
    }

    void Update()
    {
        // Check if right primary button was pressed and released
        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool rightPrimaryButton))
        {
            if (rightPrimaryButton && !_rightPrimaryButtonPressed)
            {
                _rightPrimaryButtonPressed = true;
            }
            else if (!rightPrimaryButton && _rightPrimaryButtonPressed)
            {
                _rightPrimaryButtonPressed = false;
                CycleWeapons(1); // Cycle forward through weapons array
            }
        }

        // Check if right secondary button was pressed and released
        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.secondaryButton, out bool rightSecondaryButton))
        {
            if (rightSecondaryButton && !_rightSecondaryButtonPressed)
            {
                _rightSecondaryButtonPressed = true;
            }
            else if (!rightSecondaryButton && _rightSecondaryButtonPressed)
            {
                _rightSecondaryButtonPressed = false;
                CycleWeapons(-1); // Cycle backward through weapons array
            }
        }

       
   
    }

    // Function to cycle through weapons array
    private void CycleWeapons(int direction)
    {
        // Destroy current weapon instance if exists
        if (_currentWeaponInstance != null)
        {
            Destroy(_currentWeaponInstance);
        }

        _currentWeaponIndex += direction;
        if (_currentWeaponIndex < 0)
        {
            _currentWeaponIndex = weapons.Length - 1; // Loop around to the end if index goes below 0
        }
        else if (_currentWeaponIndex >= weapons.Length)
        {
            _currentWeaponIndex = 0; // Loop around to the beginning if index goes beyond the length of the array
        }

        // Get the position of the controller object
        Vector3 controllerPosition = controllerobj.transform.position;
        
        // Instantiate new weapon at the controller's position
        _currentWeaponInstance = Instantiate(weapons[_currentWeaponIndex], controllerPosition, Quaternion.identity);

        Rigidbody weaponRigidbody = _currentWeaponInstance.GetComponent<Rigidbody>();
        if (weaponRigidbody != null)
        {
        weaponRigidbody.isKinematic = true;
         }
        
        Debug.Log("Selected Weapon Index: " + _currentWeaponIndex);
    }
}

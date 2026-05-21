using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PrimitiveStates
{
    Disabled = -1,
    Cube,
    Sphere,
    Capsule,
    Cylinder
}
public class Primitive : MonoBehaviour
{
    public GameObject[] variants;
    public PrimitiveStates desiredState = PrimitiveStates.Cube;
 
    [SerializeField]
    private PrimitiveStates _state = PrimitiveStates.Cube;
    public PrimitiveStates state
    {
        get
        {
            return _state;
        }
        set
        {
            SetAppearance(value);
        }
    }
    public void SetAppearance(int choice)
    {
        if (choice < (int)PrimitiveStates.Cylinder || choice > (int)PrimitiveStates.Cylinder)
            SetAppearance(PrimitiveStates.Disabled);
        else
            SetAppearance((PrimitiveStates)choice);
    }
    public void SetAppearance(PrimitiveStates choice)
    {
        _state = choice;
        desiredState = _state;
        foreach (GameObject go in variants)
            go.SetActive(false);
        if (choice != PrimitiveStates.Disabled)
            variants[(int)choice].SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        state = PrimitiveStates.Cube;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            state = (PrimitiveStates)(((int)state + 1) % ((int)PrimitiveStates.Cylinder + 1));
        }
        if (desiredState != state)
            state = desiredState;
    }
}
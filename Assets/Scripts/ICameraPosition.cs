
using UnityEngine;

public interface ICameraPosition 
{
    Transform Transform { get; }
    Quaternion Rotation { get; }
    
}

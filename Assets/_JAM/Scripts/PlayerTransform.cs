using UnityEngine;

public class PlayerTransform : MonoBehaviour
{
    private static Transform _playerTransform = null;

    public static Transform Get()
    {
        //This is the simplest solution for a small showcase project.
        //In case of a real one I would prefer using DI or at least the Service Locator pattern to get Player ref.
        if(_playerTransform == null)
            _playerTransform = FindAnyObjectByType<Player>().transform;

        return _playerTransform;
    }
}

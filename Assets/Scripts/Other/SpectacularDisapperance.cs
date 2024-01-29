using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class SpectacularDisapperance : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] _meshes;
    [SerializeField] [CanBeNull] private ParticleSystem _localPartSys;
    [SerializeField] private ParticleSystem _deathPartSys;
    [SerializeField] private float _delay;

    public void Disapperance()
    {
        _deathPartSys.Play();
        
        EventHandler.OnDisapperance?.Invoke(gameObject);

        foreach (var mesh in _meshes)
            mesh.enabled = false;

        if (_localPartSys != null)
            _localPartSys.Stop();

        StartCoroutine(DisableObj());
    }

    private IEnumerator DisableObj()
    {
        yield return new WaitForSeconds(_delay);

        gameObject.SetActive(false);
    }
}
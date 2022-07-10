using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheGame.Collect
{
    public class CollectableItem : MonoBehaviour
    {
        private bool _isCollected;
        private void OnTriggerEnter(Collider other)
        {
            if (_isCollected) return;

            if (other.TryGetComponent(out CollectionService collectionService))
            {
                _isCollected = true;
                collectionService.AddNewItem(transform);

            }
        }
    }
}

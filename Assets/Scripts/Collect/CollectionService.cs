using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace TheGame.Collect
{
    public class CollectionService : MonoBehaviour
    {
        [SerializeField] private Transform _playerSpineTransform;

        private int _holdingItemCount = 0;

        void Start()
        {

        }

        public void AddNewItem(Transform item)
        {
            item.DOMove(_playerSpineTransform.position + new Vector3(0, 0.25f * _holdingItemCount, 0), 0.2f).OnComplete(
             () =>
             {
                 item.SetParent(_playerSpineTransform, true);
                 item.localPosition = new Vector3(0, .25f * _holdingItemCount, 0);
                 item.localRotation = Quaternion.identity;
                 _holdingItemCount++;
             }
             );
        }
        public Transform GetItem()
        {
            if (_playerSpineTransform.childCount == 0) return null;
            return _playerSpineTransform.GetChild(_playerSpineTransform.childCount - 1);
        }

    }
}

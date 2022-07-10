using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TheGame.Collect;
using UnityEngine;

namespace TheGame.Depot
{
    public class DepotService : MonoBehaviour
    {
        [SerializeField] private CollectionService _collectionService;

        private bool _canTransfer;

        public void TransformItems(Transform newPlace)
        {
            _canTransfer = true;
            while (_canTransfer)
            {
                var item = _collectionService.GetItem();
                if (item == null) return;
                item.DOJump(newPlace.position, 1, 1, 0.2f).OnComplete(
                 () =>
                 {
                     item.SetParent(newPlace, true);
                     item.localPosition = new Vector3(0, .25f, 0);
                     item.localRotation = Quaternion.identity;
                 }
                 );
            }
        }

        public void StopTransfer()
        {
            _canTransfer = false;
        }
    }
}

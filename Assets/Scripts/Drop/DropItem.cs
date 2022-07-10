using System.Collections;
using System.Collections.Generic;
using TheGame.Depot;
using UnityEngine;

namespace TheGame.Drop
{
    public class DropItem : MonoBehaviour
    {
        [SerializeField] private DepotItem _depotZone;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out DepotService depotService))
            {
                depotService.TransformItems(_depotZone.transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out DepotService depotService))
            {
                depotService.StopTransfer();
            }
        }
    }
}

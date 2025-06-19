using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RejectingFear.Utils
{
    public static class RFUtils
    {
        public static Vector3 GetRandonDir()
        {
            return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        }


    }


}

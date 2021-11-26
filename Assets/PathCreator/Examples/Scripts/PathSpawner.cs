using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

namespace PathCreation.Examples {

    public class PathSpawner : MonoBehaviour {

        public PathCreator pathPrefab;
        public PathFollower followerPrefab;
        public int spawnNumber;
        public Transform[] spawnPoints;

        void Start () {
            foreach (Transform t in spawnPoints) {
                var path = Instantiate (pathPrefab, t.position, t.rotation);
                for (int i = 0; i < spawnNumber; i++)
                {
                    var follower = Instantiate (followerPrefab);
                    follower.pathCreator = path;
                    path.transform.parent = t;    
                }
                
                
            }
        }
    }

}
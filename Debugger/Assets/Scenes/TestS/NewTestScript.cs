using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayModeTest
    {
        // ENEMY MOVEMENT TEST
        // Passes if enemy moves
        // Fails if it does not
        [UnityTest]
        public IEnumerator EnemyMovementTest()
        {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Enemy1"));

            Transform enemyTransform = GameObject.Find("Enemy1(Clone)").transform;

            Vector3 previousPosition = enemyTransform.position;
            for (int i = 0; i < 100; i++)
            {
                yield return new WaitForSeconds(3);
                Vector3 position = enemyTransform.position;

                if (position.x < previousPosition.x)
                {
                    yield break;
                }
            }

            Assert.Fail();
        }


        // END GOAL DESTRUCT
        // Passes if enemy can destroy end goal
        // Fails if it does not
        [UnityTest]
        public IEnumerator EndGoalDestructTest()
        {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("End Goal"));

            for (int i = 0; i < 1000; i++)
            {
                MonoBehaviour.Instantiate(Resources.Load<GameObject>("Enemy1"));
                yield return new WaitForSeconds(1);

                if (GameObject.Find("End Goal(Clone)") == null)
                {
                    yield break;
                }
            }

            Assert.Fail();
        }

        // GAMEPLAY TEST
        [UnityTest]
        [Timeout(100000000)]
        public IEnumerator GameplayTest()
        {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Auto Player"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("End Goal"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Enemy1"));
            

            /*var target = GameObject.FindWithTag("Enemy").transform;
            var moveSpeed = 3;
            Transform playerTransform = GameObject.Find("Player(Clone)").transform;
            var distance = Vector3.Distance(playerTransform.position, target.position);
            playerTransform.position += playerTransform.forward * moveSpeed * Time.deltaTime;
            */
            while (GameObject.Find("End Goal(Clone)") != null)
            {/*
                Vector3 pos = new Vector3(3, 0.92F, Random.Range(-3, 4));
                for (int i = 0; i < 200; i++)
                {
                    var enemy = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Enemy1"), pos, Quaternion.Euler(0, 90, 0));
                    yield return new WaitForSeconds(5);
                }*/
                yield return new WaitForSeconds(5);
            }

            if (GameObject.Find("End Goal(Clone)") == null)
            {
                Assert.Pass();
            }

            else
            {
                Assert.Fail();
            }
        }

       

        [SetUp]
        public void LoadScenery()
        {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Scenery"));
        }

        [TearDown]
        public void ResetScene()
        {
            GameObject[] gameObjectList = GameObject.FindObjectsOfType<GameObject>();
            for(int i = 0; i < gameObjectList.Length; i++)
            {
                GameObject gameObject = gameObjectList[i];
                Component masterScript = gameObject.GetComponent("UnityEngine.TestTools.TestRunner.PlaymodeTestsController");
                if(masterScript != null)
                {
                    continue;
                }
                MonoBehaviour.DestroyImmediate(gameObject);
            }
        }

    }
}

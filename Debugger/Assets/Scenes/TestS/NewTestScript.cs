using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TestTools;
using System.IO;

namespace Tests
{
    public class PlayModeTest
    {
        protected StreamWriter writer;
        string dateandtime = System.DateTime.Now.ToString("yyyy MMM dd  HH.mm.ss");
        private string testOutputFile;


        // ENEMY MOVEMENT TEST
        // Passes if enemy moves
        // Fails if it does not
        [UnityTest]
        public IEnumerator a_EnemyMovementTest()
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

        // PLAYER CAN KILL
        // Passes if player kills enemies
        // Fails if it does not
        [UnityTest]
        public IEnumerator PlayerCanKillTest()
        {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Auto Player2"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Enemy1"));
            yield return new WaitForSeconds(5);
            
            if (GameObject.Find("Enemy1(Clone)") == null)
            {
                yield break;
            }

            Assert.Fail();
        }

        // ENEMY CAN KILL
        // Passes if enemy can kill player
        // Fails if it does not
        [UnityTest]
        public IEnumerator EnemyCanKillTest()
        {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Player"));

            for (int i = 0; i < 1000; i++)
            {
                MonoBehaviour.Instantiate(Resources.Load<GameObject>("Enemy1"));
                yield return new WaitForSeconds(1);

                if (GameObject.Find("Player(Clone)") == null)
                {
                    yield break;
                }
            }

            Assert.Fail();
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

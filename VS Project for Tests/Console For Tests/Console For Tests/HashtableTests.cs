using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Console_For_Tests
{
    
    struct UserInfo
    {
        public int userId;
        public string userName;
        public UserInfo(int id, string name)
        {
            userId = id;
            userName = name;
        }
    }

    public class HashtableTests
    {
        static Hashtable userInfoHash;
        static List<UserInfo> userInfoList;
        static Stopwatch sw;

        public static void userHash(){

            userInfoHash = new Hashtable();
            userInfoList = new List<UserInfo>();
            sw = new Stopwatch();

            //add
            for (int i = 0; i< 4000000; i++)
                {
                    userInfoHash.Add(i, "user" + i);
                    userInfoList.Add(new UserInfo(i, "user" + i));
                }

            //remove
            if (userInfoHash.ContainsKey(0))
            {
                userInfoHash.Remove(0);
            }

            //set or replace
            if (userInfoHash.ContainsKey(1))
            {
                userInfoHash[1] = "replaced";
            }

            //foreach (DictionaryEntry entry in userInfoHash)
            //{
            //    Console.WriteLine("Key: " + entry.Key + " / Value: " + entry.Value);
            //}

            //access elements
            Random randomUserGen = new Random();
            int randomUser = -1;

            sw.Start();
            float startTime = 0;
            float endTime = 0;
            float deltaTime = 0;

            int cycles = 5;
            int cycle = 0;
            string userName = string.Empty;

            while (cycle < cycles)
            {
                randomUser = randomUserGen.Next(3000000, 4000000);

                startTime = sw.ElapsedMilliseconds;
                // access from list
                userName = GetUserFromList(randomUser);
                endTime = sw.ElapsedMilliseconds;
                deltaTime = endTime - startTime;

                Console.WriteLine("Time taken " + userName + " from list took" + string.Format("{0:0.##}", deltaTime) + "ms");



                startTime = sw.ElapsedMilliseconds;
                //access from hash
                userName = (string)userInfoHash[randomUser];
                endTime = sw.ElapsedMilliseconds;
                deltaTime = endTime - startTime;

                Console.WriteLine("Time taken " + userName + " from hash took" + string.Format("{0:0.##}", deltaTime) + "ms");


                cycle++;
            }
        }

        static string GetUserFromList(int userId)
        {
            for (int i = 0; i < userInfoList.Count; i++)
            {
                if (userInfoList[i].userId == userId)
                {
                    return userInfoList[i].userName;
                }
            }
            return string.Empty;
        }


    }
}

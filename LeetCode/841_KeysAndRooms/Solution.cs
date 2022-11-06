/* https://leetcode.com/problems/keys-and-rooms/

There are n rooms labeled from 0 to n - 1 and all the rooms are locked except for room 0. Your goal is to visit all the rooms. However, you cannot enter a locked room without having its key.

When you visit a room, you may find a set of distinct keys in it. Each key has a number on it, denoting which room it unlocks, and you can take all of them with you to unlock the other rooms.

Given an array rooms where rooms[i] is the set of keys that you can obtain if you visited room i, return true if you can visit all the rooms, or false otherwise.

Example 1:

Input: rooms = [[1],[2],[3],[]]
Output: true
Explanation: 
We visit room 0 and pick up key 1.
We then visit room 1 and pick up key 2.
We then visit room 2 and pick up key 3.
We then visit room 3.
Since we were able to visit every room, we return true.

Example 2:

Input: rooms = [[1,3],[3,0,1],[2],[0]]
Output: false
Explanation: We can not enter room number 2 since the only key that unlocks it is in that room.

Constraints:
    n == rooms.length
    2 <= n <= 1000
    0 <= rooms[i].length <= 1000
    1 <= sum(rooms[i].length) <= 3000
    0 <= rooms[i][j] < n
    All the values of rooms[i] are unique.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _841_KeysAndRooms
{
    public class Solution
    {
        //there are 2 - 1000 rooms
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            HashSet<int> visited = new HashSet<int>();
            visited.Add(0); //we start at rooms[0]

            //add the keys we can gather from room 0
            Stack<int> keys = new Stack<int>();
            for (int i = 0; i < rooms[0].Count; i++)
            {
                keys.Push(rooms[0][i]);
            }

            while(keys.Count > 0)
            {
                int current = keys.Pop();
                if (visited.Contains(current)) continue; //we have already visited this room...
                //if (current >= rooms.Count) continue; //this key was useless... //check not necessary due to constraint: 0 <= rooms[i][j] < n

                visited.Add(current); //mark this room as visited

                for (int i = 0; i < rooms[current].Count; i++)
                {
                    keys.Push(rooms[current][i]); //add the keys from the current room we are in
                }
            }

            for(int i = 0; i < rooms.Count; i++)
            {
                //check if we visited this room or not
                if (!visited.Contains(i)) return false;
                
            }

            return true;
        }
    }
}
